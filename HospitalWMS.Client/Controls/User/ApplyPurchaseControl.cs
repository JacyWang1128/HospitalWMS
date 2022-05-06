using HospitalWMS.Model.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Client.Controls.User
{
    public partial class ApplyPurchaseControl : BaseDataControl
    {
        public ApplyPurchaseControl()
        {
            InitializeComponent();
        }


        private string ApplyUid = string.Empty;
        private List<ApplyOrderItem> items = null;

        public void FreshItems()
        {
            if (items == null)
            {
                dgvItem.DataSource = null;
                return;
            }
            dgvItem.DataSource = items.Select(x => new { 编号 = x.sort, 物资 = x.goods.name, 数量 = x.count, 仓库 = x.warehouse.name }).ToList();
        }
        public void FreshApply()
        {
            //var query = Service.Common.db.Queryable<Model.Entities.Apply>()
            //    .Mapper(x => x.applier, x => x.applierid)
            //    .Mapper(x => x.approver, x => x.approverid)
            //    //.Mapper(x => x.items, x => x.items.First().applyid)
            //    .Where(x => x.applierid == Service.Common.currentUser.id).ToList()
            //    .Select(x => new { 编号 = x.id, 申请时间 = x.applytime, 申请人 = x.applier.displayname,申请原因 = x.cause, 审批人 = x.approver == null ? "" : x.approver.displayname, 申请结果 = x.result.ToString() }).ToList();
            //dgvStock.DataSource = query;
            if (items != null && items.Count > 0)
            {
                List<ApplyOrderItem> OrderList = items;
                Expressionable<Stock> exp = new Expressionable<Stock>();
                foreach (var item in OrderList)
                {
                    exp.Or(it => it.warehouseid == item.warehouseid && it.goodsid == item.goodsid);
                }
                var stock = Service.Common.db.Queryable<Stock>()
                           .Mapper(x => x.warehouse, x => x.warehouseid)
                           .Mapper(x => x.goods, x => x.goodsid)
                           .Where(exp.ToExpression())
                           .ToList();
                //stocks = stock;
                var stocktable = stock.Select(x => new
                {
                    编号 = x.id,
                    仓库 = x.warehouse.name,
                    物资 = x.goods.name,
                    数量 = x.count,
                    单位 = x.goods.unit,
                    规格 = x.goods.specification,
                    物资类型 = x.goods.goodstype.ToString(),
                    //供应商 = x.goods.supplier.name,
                    单价 = x.goods.price,
                    总价 = (decimal)x.count * x.goods.price
                }).ToList();
                dgvStock.DataSource = stocktable;
            }
            cbWarehouse.DataSource = Service.Common.db.Queryable<Model.Entities.Warehouse>().ToDataTable();
            cbWarehouse.DisplayMember = "name";
            var goodids = items == null ? new List<long>() : items.Select(x => x.goodsid).Distinct().ToList();
            cbGoods.DataSource = Service.Common.db.Queryable<Model.Entities.Goods>().Where(x => !goodids.Contains(x.id)).ToDataTable();
            cbGoods.DisplayMember = "name";
        }
        public override void FreshData()
        {
            FreshItems();
            FreshApply();
        }

        private Model.Entities.ApplyOrder SetValue(Model.Entities.ApplyOrder entity)
        {
            entity.uuid = ApplyUid;
            entity.result = Model.Enums.ApplyResult.未审批;
            entity.applierid = Service.Common.currentUser.id;
            entity.applytime = DateTime.Now;
            return entity;
        }
        private Model.Entities.ApplyOrderItem SetValue(Model.Entities.ApplyOrderItem entity)
        {
            entity.applyid = ApplyUid;
            entity.count = Convert.ToInt32(fiNum.Value);
            entity.goodsid = Convert.ToInt64((cbGoods.SelectedItem as DataRowView).Row["id"].ToString());
            entity.goods = new Model.Entities.Goods() { name = (cbGoods.SelectedItem as DataRowView).Row["name"].ToString() };
            entity.warehouseid = Convert.ToInt64((cbWarehouse.SelectedItem as DataRowView).Row["id"].ToString());
            entity.warehouse = new Warehouse() { name = (cbWarehouse.SelectedItem as DataRowView).Row["name"].ToString() };
            entity.sort = items.Count + 1;
            return entity;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (int.TryParse(fiNum.Value, out count) && count > 0)
            {
                if (string.IsNullOrEmpty(ApplyUid))
                    ApplyUid = Guid.NewGuid().ToString();
                if (items == null)
                    items = new List<ApplyOrderItem>();
                var entity = new Model.Entities.ApplyOrderItem();
                entity = SetValue(entity);
                items.Add(entity);
                FreshData();
            }
            else
                MessageBox.Show("请输入正确数量");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }
            var index = Convert.ToInt32(dgvItem.SelectedRows[0].Cells["编号"].Value);
            items[index - 1] = SetValue(items[index - 1]);
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            items.Remove(items.Find(x => x.sort == Convert.ToInt32(dgvItem.SelectedRows[0].Cells["编号"].Value)));
            FreshData();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                List<Tuple<long, long, int>> param = new List<Tuple<long, long, int>>();
                foreach (var item in items)
                {
                    param.Add(new Tuple<long, long, int>(item.warehouseid, item.goodsid, item.count));
                }
                if (!Service.Business.CheckStock(param))
                {
                    var entity = new Model.Entities.ApplyOrder();
                    entity = SetValue(entity);
                    Service.DAO.Insert(entity);
                    Service.DAO.Insert(items.ToArray());
                    items = null;
                    ApplyUid = string.Empty;
                    UserMainControl.Instance.FreshUI(typeof(SelfApplyPurchaseQueryControl));
                }
                else
                {
                    MessageBox.Show("库存充足，请直接申领！");
                    FreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("申请失败！");
            }
        }
    }
}
