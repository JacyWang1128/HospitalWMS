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

namespace HospitalWMS.Client.Controls.Purchaser
{
    public partial class ApplyPurchaseManageControl : BaseDataControl
    {
        public ApplyPurchaseManageControl()
        {
            InitializeComponent();
        }

        private long ApplyId = 0;
        private ApplyOrder apply = null;
        private List<ApplyOrderItem> applyItems = null;
        public override void FreshData()
        {
            //var query = Service.Common.db.Queryable<Model.Entities.ApplyOrder>()
            //    .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList()
            //    .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
            //    .ToList();
            dgvItem.DataSource = null;
        }

        public override void InitData(EntityBase entity)
        {
            ApplyId = entity.id;
            var query = Service.Common.db.Queryable<Model.Entities.ApplyOrder>().Where(x => x.id == entity.id).First();
            if (query == null)
            {
                MessageBox.Show("未找到申领记录！");
                return;
            }
            apply = query;
            var applyitems = Service.Common.db.Queryable<ApplyOrderItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == query.uuid)
                .OrderBy(x => x.sort).ToList();
            applyItems = applyitems;
            List<ApplyOrderItem> OrderList = applyitems;
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
                List<Tuple<long, long, int>> param = new List<Tuple<long, long, int>>();
                foreach (var item in query)
                {
                    param.Add(new Tuple<long, long, int>(item.warehouseid, item.goodsid, item.count));
                }
                if (Service.Business.ApproveApply<Model.Entities.ApplyOrder>(id))
                {
                    //生成采购单
                    var uuid = Guid.NewGuid().ToString();
                    var order = new Model.Entities.Order()
                    {
                        uuid = uuid,
                        applierid = Runtime.Instance.currentUser.id,
                        applyid = apply.id,
                        applytime = DateTime.Now,
                        result = ApplyResult.未审批,
                    };
                    var orderItems = new List<OrderItem>();
                    foreach (var item in query)
                    {
                        orderItems.Add(new OrderItem()
                        {
                            orderid = order.uuid,
                            count = item.count,
                            goodsid = item.goodsid,
                            sort = item.sort,
                            warehouseid = item.warehouseid
                        });
                    }
                    Service.DAO.Insert(order);
                    Service.DAO.Insert(orderItems.ToArray());
                    PurchaserMainControl.Instance.FreshUI(typeof(ApplyPurchaseQueryControl));
                }
                else
                    MessageBox.Show("批准失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            var id = ApplyId;
            if (!Service.Business.RecallApply<Model.Entities.ApplyOrder>(id))
                MessageBox.Show("撤回失败！");
            PurchaserMainControl.Instance.FreshUI(typeof(ApplyPurchaseQueryControl));
        }
    }
}
