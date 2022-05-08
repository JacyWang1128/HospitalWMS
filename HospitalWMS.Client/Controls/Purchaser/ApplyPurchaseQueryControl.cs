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

namespace HospitalWMS.Client.Controls.Purchaser
{
    public partial class ApplyPurchaseQueryControl : BaseDataControl
    {
        public ApplyPurchaseQueryControl()
        {
            InitializeComponent();
        }
        public override void FreshData()
        {
            FreshData(false);
        }

        private void FreshData(bool isFilter)
        {
            dgvItem.DataSource = null;
            if (isFilter)
            {
                var query = Service.Common.db.Queryable<Model.Entities.ApplyOrder>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid)//.Where(x => x.applierid == Runtime.Instance.currentUser.id)
                .ToList()
                .Where(x => (cbApplyResult.SelectedItem == null ? true : x.result.ToString() == cbApplyResult.SelectedItem.ToString()))
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
                dgvApply.DataSource = query;
            }
            else
            {
                var query = Service.Common.db.Queryable<Model.Entities.ApplyOrder>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid)//.Where(x => x.applierid == Runtime.Instance.currentUser.id)
                .ToList()
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
                dgvApply.DataSource = query;
            }
        }

        private void ApplyPurchaseQueryControl_Load(object sender, EventArgs e)
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

        private void dgvApply_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var uuid = dgvApply.Rows[e.RowIndex].Cells["单号"].Value.ToString();
            var query = Service.Common.db.Queryable<ApplyOrderItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == uuid)
                .OrderBy(x => x.sort).ToList()
                .Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count })
                .ToList();
            dgvItem.DataSource = query;
        }

        private void dgvApply_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((ApplyResult)dgvApply.Rows[e.RowIndex].Cells["审核结果"].Value == ApplyResult.未审批)
            {
                PurchaserMainControl.Instance.SkipUI(typeof(ApplyPurchaseManageControl), new Model.EntityBase() { id = (long)dgvApply.Rows[e.RowIndex].Cells["编号"].Value });
            }
            else
            {
                MessageBox.Show("该记录已审核！");
            }
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
                PurchaserMainControl.Instance.SkipUI(typeof(ApplyPurchaseManageControl), new Model.EntityBase() { id = (long)dgvApply.Rows[dgvApply.SelectedRows[0].Index].Cells["编号"].Value });
            }
            else
            {
                MessageBox.Show("该记录已审核！");
            }
        }
    }
}
