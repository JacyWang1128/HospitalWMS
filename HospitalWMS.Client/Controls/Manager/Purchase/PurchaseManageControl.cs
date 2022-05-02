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

namespace HospitalWMS.Client.Controls.Manager.Purchase
{
    public partial class PurchaseManageControl : BaseDataControl
    {
        public PurchaseManageControl()
        {
            InitializeComponent();
        }

        public override void FreshData()
        {
            var query = Service.Common.db.Queryable<Model.Entities.Order>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.perchaser, x => x.purchaserid).ToList()
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier.displayname, 申请时间 = x.applytime, 采购人 = x.perchaser == null?"":x.perchaser.displayname,采购结果=x.state.ToString(), 审核结果 = x.result })
                .ToList();
            dgvOrder.DataSource = query;
            dgvItem.DataSource = null;
        }
        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.SelectedRows.Count < 1)
                return;
            var order_num = dgv.SelectedRows[0].Cells["单号"].Value.ToString();
            var query = Service.Common.db.Queryable<OrderItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.orderid == order_num)
                .OrderBy(x => x.sort).Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 数量 = x.count })
                .ToDataTable();
            dgvItem.DataSource = query;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择记录！");
                return;
            }
            var result = (ApplyResult)dgvOrder.SelectedRows[0].Cells["审核结果"].Value;
            if (result != ApplyResult.未审批)
            {
                MessageBox.Show("已审批，请勿重复审批！");
                return;
            }
            var id = Convert.ToInt64(dgvOrder.SelectedRows[0].Cells["编号"].Value);
            if (Service.Business.ApproveApply<Model.Entities.Order>(id))
            {
                var order_num = dgvOrder.SelectedRows[0].Cells["单号"].Value.ToString();
                var query = Service.Common.db.Queryable<OrderItem>()
                 .Mapper(x => x.goods, x => x.goodsid)
                 .Mapper(x => x.warehouse, x => x.warehouseid)
                 .Where(x => x.orderid == order_num).ToList();
                foreach (var item in query)
                {
                    if (!Service.Business.ImWarehouse(item.warehouseid, item.goodsid, item.count))
                    {
                        MessageBox.Show("入库失败！");
                        break;
                    }
                }

            }
            else
                MessageBox.Show("批准失败！");
            FreshData();
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择记录！");
                return;
            }
            var result = (ApplyResult)dgvOrder.SelectedRows[0].Cells["审核结果"].Value;
            if (result != ApplyResult.未审批)
            {
                MessageBox.Show("已审批，请勿重复审批！");
                return;
            }
            var id = Convert.ToInt64(dgvOrder.SelectedRows[0].Cells["编号"].Value);
            if (!Service.Business.RecallApply<Model.Entities.Order>(id))
                MessageBox.Show("撤回失败！");
            FreshData();
        }
    }
}
