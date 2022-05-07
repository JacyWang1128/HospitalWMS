using HospitalWMS.Client.Controls.Purchaser;
using HospitalWMS.Model;
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

        private long ApplyId = 0;
        private Order apply = null;
        private List<OrderItem> applyItems = null;

        private List<Model.Entities.ApplyOrderItem> orderItems = null;
        public override void FreshData()
        {
            //var query = Service.Common.db.Queryable<Model.Entities.Order>()
            //    .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.perchaser, x => x.purchaserid).ToList()
            //    .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier.displayname, 申请时间 = x.applytime, 采购人 = x.perchaser == null?"":x.perchaser.displayname,采购结果=x.state.ToString(), 审核结果 = x.result })
            //    .ToList();
            //dgvApply.DataSource = query;
            //dgvItem.DataSource = null;
        }

        public override void InitData(EntityBase entity)
        {
            ApplyId = entity.id;
            var query = Service.Common.db.Queryable<Model.Entities.Order>().Where(x => x.id == entity.id).First();
            if (query == null)
            {
                MessageBox.Show("未找到申领记录！");
                return;
            }
            apply = query;
            var applyitems = Service.Common.db.Queryable<OrderItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.orderid == query.uuid)
                .OrderBy(x => x.sort).ToList();
            applyItems = applyitems;
            var items = applyitems.Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count })
                .ToList();
            dgvItem.DataSource = items;
            var order = Service.Common.db.Queryable<ApplyOrder>().First(x => x.id == query.applyid);
            var orderitems = Service.Common.db.Queryable<ApplyOrderItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == order.uuid)
                .OrderBy(x => x.sort).ToList();
            orderItems = orderitems;
            var orderitem = orderitems.Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count })
                .ToList();
            dgvApply.DataSource = orderitem;
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
            var id = ApplyId;
            var query = applyItems;
            if (Service.Business.ApproveApply<Model.Entities.Order>(id))
            {
                //var order_num = dgvApply.SelectedRows[0].Cells["单号"].Value.ToString();
                //var query = Service.Common.db.Queryable<OrderItem>()
                // .Mapper(x => x.goods, x => x.goodsid)
                // .Mapper(x => x.warehouse, x => x.warehouseid)
                // .Where(x => x.orderid == order_num).ToList();
                //foreach (var item in query)
                //{
                //    if (!Service.Business.ImWarehouse(item.warehouseid, item.goodsid, item.count))
                //    {
                //        MessageBox.Show("入库失败！");
                //        break;
                //    }
                //}
                //创建入库单
                var uuid = Guid.NewGuid().ToString();
                var imwarehouse = new Model.Entities.ImWarehouse()
                {
                    uuid = uuid,
                    applierid = Runtime.Instance.currentUser.id,
                    orderid = apply.id,
                    applytime = DateTime.Now,
                    result = ApplyResult.未审批,
                };
                var imwarehouseitems = new List<ImWarehouseItem>();
                foreach (var item in query)
                {
                    imwarehouseitems.Add(new ImWarehouseItem()
                    {
                        applyid = imwarehouse.uuid,
                        count = item.count,
                        goodsid = item.goodsid,
                        sort = item.sort,
                        warehouseid = item.warehouseid
                    });
                }
                Service.DAO.Insert(imwarehouse);
                Service.DAO.Insert(imwarehouseitems.ToArray());
                //PurchaserMainControl.Instance.FreshUI(typeof(PurchaseQueryControl));
            }
            else
                MessageBox.Show("批准失败！");
            //FreshData();
            PurchaserMainControl.Instance.FreshUI(typeof(PurchaseQueryControl));
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            var id = ApplyId;
            if (!Service.Business.RecallApply<Model.Entities.Order>(id))
                MessageBox.Show("撤回失败！");
            PurchaserMainControl.Instance.FreshUI(typeof(PurchaseQueryControl));
        }
    }
}
