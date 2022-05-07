using HospitalWMS.Model;
using HospitalWMS.Model.Entities;
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
    public partial class RestitutionControl : BaseDataControl
    {
        public RestitutionControl()
        {
            InitializeComponent();
        }
        private string ApplyUid = string.Empty;
        private List<RestitutionItem> items = null;
        private Apply apply = null;
        private List<ApplyItem> applyItems = null;
        private void uiLabel2_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            label.Width = Convert.ToInt32(label.Parent.Width * 0.33);
        }

        public override void InitData(EntityBase entity)
        {
            apply = Service.Common.db.Queryable<Apply>().Where(x => x.id == entity.id).First();
            if (apply != null)
            {
                applyItems = Service.Common.db.Queryable<ApplyItem>()
                    .Mapper(x => x.goods, x => x.goodsid)
                    .Mapper(x => x.warehouse, x => x.warehouseid)
                    .Where(x => x.applyid == apply.uuid).ToList();
                dgvApply.DataSource = applyItems.Select(x => new { 编号 = x.sort, 物资 = x.goods.name, 数量 = x.count, 仓库 = x.warehouse.name }).ToList();
                FreshData();
            }
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
            //var query = Service.Common.db.Queryable<Model.Entities.Restitution>()
            //    .Mapper(x => x.applier, x => x.applierid)
            //    .Mapper(x => x.approver, x => x.approverid)
            //    //.Mapper(x => x.items, x => x.items.First().applyid)
            //    .Where(x => x.applierid == Service.Common.currentUser.id).ToList()
            //    .Select(x => new { 编号 = x.id, 申请时间 = x.applytime, 申请人 = x.applier.displayname, 申请原因 = x.cause, 审批人 = x.approver == null ? "" : x.approver.displayname, 申请结果 = x.result.ToString() }).ToList();
            //dgvApply.DataSource = query;
            cbWarehouse.DataSource = Service.Common.db.Queryable<Model.Entities.Warehouse>().ToDataTable();
            cbWarehouse.DisplayMember = "name";
            var applyitemsgoodsids = applyItems == null? new List<long>():applyItems.Select(x => x.goodsid).Distinct().ToList();
            var temp = Service.Common.db.Queryable<Model.Entities.Goods>().Where(x => applyitemsgoodsids.Contains(x.id)).ToList();
            var goodids = items == null ? new List<long>() : items.Select(x => x.goodsid).Distinct().ToList();
            cbGoods.DataSource = temp.Where(x => !goodids.Contains(x.id)).ToList();
            cbGoods.DisplayMember = "name";
        }
        public override void FreshData()
        {
            FreshItems();
            FreshApply();
        }

        private Model.Entities.Restitution SetValue(Model.Entities.Restitution entity)
        {
            entity.uuid = ApplyUid;
            entity.result = Model.Enums.ApplyResult.未审批;
            entity.applierid = Service.Common.currentUser.id;
            entity.applytime = DateTime.Now;
            entity.cause = fiCause.Value;
            entity.applyid = apply.id;
            entity.approvecause = string.Empty;
            return entity;
        }
        private Model.Entities.RestitutionItem SetValue(Model.Entities.RestitutionItem entity)
        {
            entity.applyid = ApplyUid;
            entity.count = Convert.ToInt32(fiNum.Value);
            entity.goodsid = (cbGoods.SelectedItem as Model.Entities.Goods).id;
            entity.goods = new Model.Entities.Goods() { name = (cbGoods.SelectedItem as Model.Entities.Goods).name };
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
                    items = new List<RestitutionItem>();
                var entity = new Model.Entities.RestitutionItem();
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
                MessageBox.Show("请选择要更新的行！");
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
                if (string.IsNullOrWhiteSpace(fiCause.Value))
                {
                    MessageBox.Show("请输入退库原因！");
                    return;
                }
                foreach (var item in items)
                {
                    var query = applyItems.Where(x => x.goodsid == item.goodsid);
                    if (query.Any())
                    {
                        if(query.First().count < item.count)
                        {
                            MessageBox.Show("退库数量超过申领数量！");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("包含申领单不存在物品，无法退库！");
                        return;
                    }
                }
                var entity = new Model.Entities.Restitution();
                entity = SetValue(entity);
                Service.DAO.Insert(entity);
                Service.DAO.Insert(items.ToArray());
                items = null;
                ApplyUid = string.Empty;
                UserMainControl.Instance.FreshUI(typeof(SelfRestitutionQueryControl));
            }
            catch (Exception ex)
            {
                MessageBox.Show("申请失败！");
            }
        }
    }
}
