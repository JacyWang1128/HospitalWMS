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

namespace HospitalWMS.Client.Controls.Manager.ExWarehouse
{
    public partial class ExWarehouseManageControl : BaseDataControl
    {
        public ExWarehouseManageControl()
        {
            InitializeComponent();
        }

        public override void FreshData()
        {
            var query = Service.Common.db.Queryable<Model.Entities.ExWarehouse>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList()
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
            dgvExWarehouse.DataSource = query;
            dgvItem.DataSource = null;
        }

        private void dgvExWarehouse_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.SelectedRows.Count < 1)
                return;
            var order_num = dgv.SelectedRows[0].Cells["单号"].Value.ToString();
            var query = Service.Common.db.Queryable<ExWarehouseItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == order_num)
                .OrderBy(x => x.sort).ToList().Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 数量 = x.count })
                .ToList();
            dgvItem.DataSource = query;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvExWarehouse.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择记录！");
                return;
            }
            var result = (ApplyResult)dgvExWarehouse.SelectedRows[0].Cells["审核结果"].Value;
            if (result != ApplyResult.未审批)
            {
                MessageBox.Show("已审批，请勿重复审批！");
                return;
            }
            var id = Convert.ToInt64(dgvExWarehouse.SelectedRows[0].Cells["编号"].Value);
            var order_num = dgvExWarehouse.SelectedRows[0].Cells["单号"].Value.ToString();
            var query = Service.Common.db.Queryable<ExWarehouseItem>()
             .Mapper(x => x.goods, x => x.goodsid)
             .Mapper(x => x.warehouse, x => x.warehouseid)
             .Where(x => x.applyid == order_num).ToList();
            try
            {
                List<Tuple<long, long, int>> param = new List<Tuple<long, long, int>>();
                foreach (var item in query)
                {
                    param.Add(new Tuple<long, long, int>(item.warehouseid, item.goodsid, item.count));
                }
                if (Service.Business.ExWarehouse(param))
                {
                    if (Service.Business.ApproveApply<Model.Entities.ExWarehouse>(id))
                    {

                    }
                    else
                        MessageBox.Show("批准失败！");
                }
                else
                    MessageBox.Show("物资库存不足，出库失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FreshData();
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            if (dgvExWarehouse.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择记录！");
                return;
            }
            var result = (ApplyResult)dgvExWarehouse.SelectedRows[0].Cells["审核结果"].Value;
            if (result != ApplyResult.未审批)
            {
                MessageBox.Show("已审批，请勿重复审批！");
                return;
            }
            var id = Convert.ToInt64(dgvExWarehouse.SelectedRows[0].Cells["编号"].Value);
            if (!Service.Business.RecallApply<Model.Entities.ExWarehouse>(id))
                MessageBox.Show("撤回失败！");
            FreshData();
        }
    }
}
