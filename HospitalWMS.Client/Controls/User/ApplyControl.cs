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
    public partial class ApplyControl : BaseDataControl
    {
        public ApplyControl()
        {
            InitializeComponent();
        }

        private string ApplyUid = string.Empty;
        private List<ApplyItem> items = null;

        private void uiLabel2_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            label.Width = Convert.ToInt32(label.Parent.Width * 0.33);
        }

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
            if (Service.Common.CurrentMonthPlan == null)
            {
                MessageBox.Show("请创建申领计划！");
                UserMainControl.Instance.ClearWrap();
                return;
            }
            var planitems = Service.Common.CurrentMonthPlan.items;
            //var query = Service.Common.db.Queryable<Model.Entities.Apply>()
            //    .Mapper(x => x.applier, x => x.applierid)
            //    .Mapper(x => x.approver, x => x.approverid)
            //    //.Mapper(x => x.items, x => x.items.First().applyid)
            //    .Where(x => x.applierid == Service.Common.currentUser.id).ToList()
            //    .Select(x => new { 编号 = x.id, 申请时间 = x.applytime, 申请人 = x.applier.displayname,申请原因 = x.cause, 审批人 = x.approver == null ? "" : x.approver.displayname, 申请结果 = x.result.ToString() }).ToList();
            //dgvStock.DataSource = query;
            //if (items != null && items.Count > 0)
            //{
            //    List<ApplyItem> OrderList = items;
            //    Expressionable<Stock> exp = new Expressionable<Stock>();
            //    foreach (var item in OrderList)
            //    {
            //        exp.Or(it => it.warehouseid == item.warehouseid && it.goodsid == item.goodsid);
            //    }
            //    var stock = Service.Common.db.Queryable<Stock>()
            //               .Mapper(x => x.warehouse, x => x.warehouseid)
            //               .Mapper(x => x.goods, x => x.goodsid)
            //               .Where(exp.ToExpression())
            //               .ToList();
            //    //stocks = stock;
            //    var stocktable = stock.Select(x => new
            //    {
            //        编号 = x.id,
            //        仓库 = x.warehouse.name,
            //        物资 = x.goods.name,
            //        数量 = x.count,
            //        单位 = x.goods.unit,
            //        规格 = x.goods.specification,
            //        物资类型 = x.goods.goodstype.ToString(),
            //        //供应商 = x.goods.supplier.name,
            //        单价 = x.goods.price,
            //        总价 = (decimal)x.count * x.goods.price
            //    }).ToList();
            //    dgvStock.DataSource = stocktable;
            //}
            dgvStock.DataSource = planitems.Select(x => new
            {
                编号 = x.id,
                仓库 = x.warehouse.name,
                物资 = x.goods.name,
                计划数量 = x.count,
                当前可领 = x.currentcount,
                单位 = x.goods.unit,
                规格 = x.goods.specification,
                物资类型 = x.goods.goodstype.ToString(),
                //供应商 = x.goods.supplier.name,
                单价 = x.goods.price,
                总价 = (decimal)x.currentcount * x.goods.price
            }).ToList();
            cbWarehouse.DataSource = Service.Common.db.Queryable<Model.Entities.Warehouse>().ToDataTable();
            cbWarehouse.DisplayMember = "name";
            var goodids = items == null ? new List<long>() : items.Select(x => x.goodsid).Distinct().ToList();
            cbGoods.DataSource = planitems.Select(x => x.goods).ToList().Where(x => !goodids.Contains(x.id)).ToList();//Service.Common.db.Queryable<Model.Entities.Goods>().Where(x => !goodids.Contains(x.id)).ToDataTable();
            cbGoods.DisplayMember = "name";
        }
        public override void FreshData()
        {
            FreshItems();
            FreshApply();
        }

        private Model.Entities.Apply SetValue(Model.Entities.Apply entity)
        {
            entity.uuid = ApplyUid;
            entity.result = Model.Enums.ApplyResult.未审批;
            entity.applierid = Runtime.Instance.CurrentUser.id;
            entity.applytime = DateTime.Now;
            entity.cause = fiCause.Value;
            entity.approvecause = string.Empty;
            return entity;
        }
        private Model.Entities.ApplyItem SetValue(Model.Entities.ApplyItem entity)
        {
            var goods = cbGoods.SelectedItem as Goods;
            entity.applyid = ApplyUid;
            entity.count = Convert.ToInt32(fiNum.Value);
            entity.goodsid = goods.id;//Convert.ToInt64((cbGoods.SelectedItem as DataRowView).Row["id"].ToString());
            entity.goods = goods;//new Model.Entities.Goods() { name = (cbGoods.SelectedItem as DataRowView).Row["name"].ToString() };
            entity.warehouseid = Convert.ToInt64((cbWarehouse.SelectedItem as DataRowView).Row["id"].ToString());
            entity.warehouse = new Warehouse() { name = (cbWarehouse.SelectedItem as DataRowView).Row["name"].ToString() };
            entity.sort = items.Count + 1;
            return entity;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                int count = 0;
                if (int.TryParse(fiNum.Value, out count) && count > 0)
                {
                    if (string.IsNullOrEmpty(ApplyUid))
                        ApplyUid = Guid.NewGuid().ToString();
                    if (items == null)
                        items = new List<ApplyItem>();
                    var entity = new Model.Entities.ApplyItem();
                    entity = SetValue(entity);
                    var planitem = Service.Common.CurrentMonthPlan.items.First(x => x.goodsid == entity.goodsid);
                    if(planitem == null)
                    {
                        throw new ApplicationException();
                    }
                    if(entity.count > planitem.currentcount)
                    {
                        throw new ApplicationException("申请数量超过当前可领数量！");
                    }
                    items.Add(entity);
                    FreshData();
                }
                else
                    MessageBox.Show("请输入正确数量");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"添加物资失败！\r\n{ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItem.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请选择要修改的行！");
                    return;
                }
                var index = Convert.ToInt32(dgvItem.SelectedRows[0].Cells["编号"].Value);
                items[index - 1] = SetValue(items[index - 1]);
                var planitem = Service.Common.CurrentMonthPlan.items.First(x => x.goodsid == items[index - 1].goodsid);
                if (planitem == null)
                {
                    throw new ApplicationException();
                }
                if (items[index - 1].count > planitem.currentcount)
                {
                    throw new ApplicationException("申请数量超过当前可领数量！");
                }
                FreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"修改物资失败！\r\n{ex.Message}");
            }
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
                if (string.IsNullOrWhiteSpace(fiCause.Value))
                {
                    MessageBox.Show("请输入申领原因！");
                    return;
                }

                //List<Tuple<long, long, int>> param = new List<Tuple<long, long, int>>();
                //foreach (var item in items)
                //{
                //    param.Add(new Tuple<long, long, int>(item.warehouseid, item.goodsid, item.count));
                //}
                if (Service.Business.CheckPlan(items))//Service.Business.CheckStock(param))
                {
                    var entity = new Model.Entities.Apply();
                    entity = SetValue(entity);
                    entity.items = items;
                    Service.Business.Apply(entity);
                    //Service.DAO.Insert(entity);
                    //Service.DAO.Insert(items.ToArray());
                    items = null;
                    ApplyUid = string.Empty;
                    UserMainControl.Instance.FreshUI(typeof(SelfApplyQueryControl));
                }
                else
                {
                    MessageBox.Show("当前可申领数量不足，申请失败！");
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
