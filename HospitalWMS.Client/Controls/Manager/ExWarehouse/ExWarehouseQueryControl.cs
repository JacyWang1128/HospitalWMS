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

namespace HospitalWMS.Client.Controls.Manager.ExWarehouse
{
    public partial class ExWarehouseQueryControl : BaseDataControl
    {
        public ExWarehouseQueryControl()
        {
            InitializeComponent();
        }
        public override void FreshData()
        {
            FreshData(false);
        }

        public void FreshData(bool isFilter)
        {
            if (isFilter)
            {
                var query = Service.Common.db.Queryable<Model.Entities.ExWarehouse>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid)
                .ToList()
                .Where(x => (cbApplyResult.SelectedItem == null ? true : x.result.ToString() == cbApplyResult.SelectedItem.ToString()))
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
                dgvApply.DataSource = query;
            }
            else
            {
                var query = Service.Common.db.Queryable<Model.Entities.ExWarehouse>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList()
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
                dgvApply.DataSource = query;
            }
        }


        private void ExWarehouseQueryControl_Load(object sender, EventArgs e)
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

        private void dgvApply_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((ApplyResult)dgvApply.Rows[e.RowIndex].Cells["审核结果"].Value == ApplyResult.未审批)
            {
                ManageMainControl.Instance.SkipUI(typeof(ExWarehouseManageControl), new Model.EntityBase() { id = (long)dgvApply.Rows[e.RowIndex].Cells["编号"].Value });
            }
            else
            {
                MessageBox.Show("该记录已审核！");
            }
        }
    }
}
