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

namespace HospitalWMS.Client.Controls.DeptManager
{
    public partial class ApplyPlanControl : BaseDataControl
    {
        public ApplyPlanControl()
        {
            InitializeComponent();
        }
        private string ApplyUid = string.Empty;
        private List<PlanItem> items = null;

        private void uiLabel2_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            label.Width = Convert.ToInt32(label.Parent.Width * 0.33);
        }

        public override void InitData(EntityBase entity)
        {

        }

        public void FreshItems()
        {
            if (items == null)
            {
                dgvItem.DataSource = null;
                return;
            }
            dgvItem.DataSource = items.Select(x => new { 编号 = x.sort, 物资 = x.goods.name, 规格=x.goods.specification,数量 = x.count, 仓库 = x.warehouse.name }).ToList();
        }
        public void FreshApply()
        {
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

        private Model.Entities.Plan SetValue(Model.Entities.Plan entity)
        {
            entity.uuid = ApplyUid;
            entity.result = Model.Enums.ApplyResult.未审批;
            entity.applierid = Runtime.Instance.CurrentUser.id;
            entity.applytime = DateTime.Now;
            entity.cause = string.Empty;
            entity.approvecause = string.Empty;
            return entity;
        }
        private Model.Entities.PlanItem SetValue(Model.Entities.PlanItem entity)
        {
            entity.applyid = ApplyUid;
            entity.count = Convert.ToInt32(fiNum.Value);
            entity.goodsid = Convert.ToInt64((cbGoods.SelectedItem as DataRowView).Row["id"].ToString());
            entity.goods = new Model.Entities.Goods() { name = (cbGoods.SelectedItem as DataRowView).Row["name"].ToString() };
            entity.warehouseid = Convert.ToInt64((cbWarehouse.SelectedItem as DataRowView).Row["id"].ToString());
            entity.warehouse = new Warehouse() { name = (cbWarehouse.SelectedItem as DataRowView).Row["name"].ToString() };
            entity.currentcount = entity.count;
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
                        items = new List<PlanItem>();
                    var entity = new Model.Entities.PlanItem();
                    entity = SetValue(entity);
                    items.Add(entity);
                    FreshData();
                }
                else
                    MessageBox.Show("请输入正确数量");
            }
            catch (Exception)
            {

                MessageBox.Show("添加物资失败！");
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
                FreshData();
            }
            catch (Exception)
            {
                MessageBox.Show("修改物资失败！");
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
                    var entity = new Model.Entities.Plan();
                    entity = SetValue(entity);
                    Service.DAO.Insert(entity);
                    Service.DAO.Insert(items.ToArray());
                    items = null;
                    ApplyUid = string.Empty;
                    DeptManageMainControl.Instance.FreshUI(typeof(PlanQueryControl));
            }
            catch (Exception ex)
            {
                MessageBox.Show("申请失败！");
            }
        }
    }
}
