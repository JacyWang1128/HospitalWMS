using HospitalWMS.Client.Controls.Purchaser;
using HospitalWMS.Model.Entities;
using HospitalWMS.Model.Enums;
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
    public partial class PlanQueryControl : BaseDataControl
    {
        public PlanQueryControl()
        {
            InitializeComponent();
            if (Runtime.Instance.CurrentUser.role == Model.Enums.UserType.科室管理员)
            {
                btnVerify.Hide();
            }
            else
            {
                btnCreate.Hide();
                //btnModify.Hide();
            }
        }

        public override void FreshData()
        {
            List<Plan> query;
            if (Runtime.Instance.CurrentUser.role == Model.Enums.UserType.科室管理员)
            {
                query = Service.Common.db.Queryable<Plan>()
                    .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid)
                    .Where(x => x.applierid == Runtime.Instance.CurrentUser.id)
                    .ToList();
            }
            else
            {
                query = Service.Common.db.Queryable<Plan>().OrderBy("applytime")
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid)
                .ToList();
            }
            dgvApply.DataSource = query.Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.username, 申请时间 = x.applytime, 审批人 = x.approver == null ? "" : x.approver.username, 审核结果 = x.result }).ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DeptManageMainControl.Instance.FreshUI(typeof(ApplyPlanControl));
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvApply.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择需要修改的记录！");
                return;
            }
            if ((ApplyResult)dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["审核结果"].Value != ApplyResult.审核不通过)
            {
                var applyid = Convert.ToInt64(dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["编号"].Value);
                DeptManageMainControl.Instance.SkipUI(typeof(ApplyPlanControl), new Model.EntityBase() { id = applyid });
            }
            else
            {
                MessageBox.Show("审核不通过计划禁止修改！");
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (dgvApply.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择需要审核的记录！");
                return;
            }
            if ((ApplyResult)dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["审核结果"].Value == ApplyResult.未审批)
            {
                var applyid = Convert.ToInt64(dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["编号"].Value);
                PurchaserMainControl.Instance.SkipUI(typeof(ApplyPlanManageControl), new Model.EntityBase() { id = applyid });
            }
            else
            {
                MessageBox.Show("该计划已审核！");
            }
        }

        private void dgvApply_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var uuid = dgvApply.Rows[e.RowIndex].Cells["单号"].Value.ToString();
            var query = Service.Common.db.Queryable<PlanItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == uuid)
                .OrderBy(x => x.sort).ToList()
                .Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count, 剩余数量 = x.currentcount })
                .ToList();
            dgvItem.DataSource = query;
        }
    }
}
