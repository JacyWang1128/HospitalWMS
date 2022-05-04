using HospitalWMS.Model;
using HospitalWMS.Model.Entities;
using HospitalWMS.Model.Enums;
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

namespace HospitalWMS.Client.Controls.Manager.ExWarehouse
{
    public partial class ExWarehouseManageControl : BaseDataControl
    {

        private List<ApplyItem> applyItems = null;
        private List<ExWarehouseItem> exWarehouseItems = null;
        private long ApplyId = 0;

        public ExWarehouseManageControl()
        {
            InitializeComponent();
        }

        public override void InitData(EntityBase entity)
        {
            ApplyId = entity.id;
            var query = Service.Common.db.Queryable<Model.Entities.ExWarehouse>().Where(x => x.id == entity.id).First();
            if (query == null)
            {
                MessageBox.Show("未找到申请记录！");
                return;
            }
            var apply = Service.Common.db.Queryable<Model.Entities.Apply>().Where(x => x.id == query.orderid).First();
            if(apply == null)
            {
                MessageBox.Show("未找到申领记录！");
                return;
            }
            var items = Service.Common.db.Queryable<ExWarehouseItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == query.uuid)
                .OrderBy(x => x.sort).ToList();
            exWarehouseItems = items;
            //List<ApplyItem> OrderList = applyitems;
            //Expressionable<Stock> exp = new Expressionable<Stock>();
            //foreach (var item in OrderList)
            //{
            //    exp.Or(it => it.warehouseid == item.warehouseid && it.goodsid == item.goodsid);
            //}
            var itemsource = items.Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count })
                .ToList();
            dgvItem.DataSource = itemsource;
            //var goodsids = applyitems.Select(x => string.Join("_", x.warehouseid, x.goodsid)).Distinct().ToArray();
            var applyitems = Service.Common.db.Queryable<Model.Entities.ApplyItem>()
                       .Mapper(x => x.warehouse, x => x.warehouseid)
                       .Mapper(x => x.goods, x => x.goodsid)
                       .Where(x=>x.applyid == apply.uuid)
                       .ToList();
            applyItems = applyitems;
            var applytable = applyitems.Select(x => new
            {
                编号 = x.sort,
                商品名称 = x.goods.name,
                仓库 = x.warehouse.name,
                单价 = x.goods.price,
                数量 = x.count
            }).ToList();
            dgvApply.DataSource = applytable;
        }

        public override void FreshData()
        {
            //var query = Service.Common.db.Queryable<Model.Entities.ExWarehouse>()
            //    .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList()
            //    .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
            //    .ToList();
            //dgvExWarehouse.DataSource = query;
            //dgvItem.DataSource = null;
        }

        private void dgvExWarehouse_SelectionChanged(object sender, EventArgs e)
        {
            //var dgv = sender as DataGridView;
            //if (dgv.SelectedRows.Count < 1)
            //    return;
            //var order_num = dgv.SelectedRows[0].Cells["单号"].Value.ToString();
            //var query = Service.Common.db.Queryable<ExWarehouseItem>()
            //    .Mapper(x => x.goods, x => x.goodsid)
            //    .Mapper(x => x.warehouse, x => x.warehouseid)
            //    .Where(x => x.applyid == order_num)
            //    .OrderBy(x => x.sort).ToList().Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 数量 = x.count })
            //    .ToList();
            //dgvItem.DataSource = query;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //if (dgvApply.SelectedRows.Count < 1)
            //{
            //    MessageBox.Show("请选择记录！");
            //    return;
            //}
            //var result = (ApplyResult)dgvApply.SelectedRows[0].Cells["审核结果"].Value;
            //if (result != ApplyResult.未审批)
            //{
            //    MessageBox.Show("已审批，请勿重复审批！");
            //    return;
            //}
            var id = ApplyId;//Convert.ToInt64(dgvApply.SelectedRows[0].Cells["编号"].Value);
            //var order_num = dgvApply.SelectedRows[0].Cells["单号"].Value.ToString();
            var query = exWarehouseItems;
             //   Service.Common.db.Queryable<ExWarehouseItem>()
             //.Mapper(x => x.goods, x => x.goodsid)
             //.Mapper(x => x.warehouse, x => x.warehouseid)
             //.Where(x => x.applyid == order_num).ToList();
            try
            {
                foreach (var item in exWarehouseItems)
                {
                    if(applyItems.Any(x=>x.goodsid == item.goodsid) && applyItems.First(x=>x.goodsid == item.goodsid).count == item.count)
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("申领单条目和出库单条目不一致，不予以出库！");
                        return;
                    }
                }
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
            ManageMainControl.Instatnce.FreshUI(typeof(ExWarehouseQueryControl));
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            //if (dgvApply.SelectedRows.Count < 1)
            //{
            //    MessageBox.Show("请选择记录！");
            //    return;
            //}
            //var result = (ApplyResult)dgvApply.SelectedRows[0].Cells["审核结果"].Value;
            //if (result != ApplyResult.未审批)
            //{
            //    MessageBox.Show("已审批，请勿重复审批！");
            //    return;
            //}
            var id = ApplyId;/// Convert.ToInt64(dgvApply.SelectedRows[0].Cells["编号"].Value);
            if (!Service.Business.RecallApply<Model.Entities.ExWarehouse>(id))
                MessageBox.Show("撤回失败！");
            ManageMainControl.Instatnce.FreshUI(typeof(ExWarehouseQueryControl));
        }
    }
}
