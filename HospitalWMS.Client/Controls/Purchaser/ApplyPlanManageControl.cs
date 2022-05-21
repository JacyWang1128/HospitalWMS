using HospitalWMS.Client.Controls.DeptManager;
using HospitalWMS.Client.Controls.Matron;
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

namespace HospitalWMS.Client.Controls.Purchaser
{
    public partial class ApplyPlanManageControl : BaseDataControl
    {
        public ApplyPlanManageControl()
        {
            InitializeComponent();
        }
        private List<PlanItem> applyItems = null;
        private long ApplyId = 0;
        private Model.Entities.Plan apply = null;

        public override void FreshData()
        {
            dgvItem.DataSource = null;
        }

        public override void InitData(EntityBase entity)
        {
            ApplyId = entity.id;
            var query = Service.Common.db.Queryable<Model.Entities.Plan>().Where(x => x.id == entity.id).First();
            if (query == null)
            {
                MessageBox.Show("未找到申领计划记录！");
                return;
            }
            apply = query;
            var applyitems = Service.Common.db.Queryable<PlanItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == query.uuid)
                .OrderBy(x => x.sort).ToList();
            applyItems = applyitems;
            var items = applyitems.Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count })
                .ToList();
            dgvItem.DataSource = items;
        }


        private void btnApprove_Click(object sender, EventArgs e)
        {
            var id = ApplyId;
            var query = applyItems;
            try
            {
                if (Service.Business.ApproveApply<Model.Entities.Plan>(id))
                {
                    MatronMainControl.Instance.FreshUI(typeof(PlanQueryControl));
                }
                else
                    MessageBox.Show("批准失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //FreshData();
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            //if (dgvStock.SelectedRows.Count < 1)
            //{
            //    MessageBox.Show("请选择记录！");
            //    return;
            //}
            //var result = (ApplyResult)dgvStock.SelectedRows[0].Cells["审核结果"].Value;
            //if (result != ApplyResult.未审批)
            //{
            //    MessageBox.Show("已审批，请勿重复审批！");
            //    return;
            //}
            var id = ApplyId;//Convert.ToInt64(dgvStock.SelectedRows[0].Cells["编号"].Value);
            if (!Service.Business.RecallApply<Model.Entities.Plan>(id))
                MessageBox.Show("撤回失败！");
            MatronMainControl.Instance.FreshUI(typeof(PlanQueryControl));
        }
    }
}
