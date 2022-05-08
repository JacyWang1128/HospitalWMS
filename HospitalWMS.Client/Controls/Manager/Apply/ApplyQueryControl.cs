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

namespace HospitalWMS.Client.Controls.Manager.Apply
{
    public partial class ApplyQueryControl : BaseDataControl
    {
        public ApplyQueryControl()
        {
            InitializeComponent();
        }
        private void dgvApply_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((ApplyResult)dgvApply.Rows[e.RowIndex].Cells["审核结果"].Value == ApplyResult.未审批)
            {
                ManageMainControl.Instance.SkipUI(typeof(ApplyManageControl), new Model.EntityBase() { id = (long)dgvApply.Rows[e.RowIndex].Cells["编号"].Value });
            }
            else
            {
                MessageBox.Show("该记录已审核！");
            }
        }

        public override void FreshData()
        {
            FreshData(false);
        }

        public void FreshData(bool isFilter)
        {
            if (isFilter)
            {
                var query = Service.Common.db.Queryable<Model.Entities.Apply>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid)
                .ToList()
                .Where(x => (cbApplyResult.SelectedItem == null ? true : x.result.ToString() == cbApplyResult.SelectedItem.ToString()))
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请原因 = x.cause, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
                dgvApply.DataSource = query;
            }
            else
            {
                var query = Service.Common.db.Queryable<Model.Entities.Apply>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList()
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请原因 = x.cause, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
                dgvApply.DataSource = query;
            }
        }


        private void ApplyQueryControl_Load(object sender, EventArgs e)
        {
            cbApplyResult.DataSource = Enum.GetNames(typeof(ApplyResult));
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FreshData(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FreshData();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (dgvApply.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择需要审核的记录！");
                return;
            }
            if ((ApplyResult)dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["审核结果"].Value == ApplyResult.未审批)
            {
                ManageMainControl.Instance.SkipUI(typeof(ApplyManageControl), new Model.EntityBase() { id = (long)dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["编号"].Value });
            }
            else
            {
                MessageBox.Show("该记录已审核！");
            }
        }
    }
}
