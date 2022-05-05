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

namespace HospitalWMS.Client.Controls.Manager.Apply
{
    public partial class ApplyManageControl : BaseDataControl
    {
        public ApplyManageControl()
        {
            InitializeComponent();
        }

        private List<ApplyItem> applyItems = null;
        private List<Stock> stocks = null;
        private long ApplyId = 0;
        private Model.Entities.Apply apply = null;

        public override void FreshData()
        {
            var query = Service.Common.db.Queryable<Model.Entities.Apply>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList()
                .Select(x => new { 编号 = x.id, 单号 = x.uuid, 申请人 = x.applier == null ? "" : x.applier.displayname, 申请原因 = x.cause, 申请时间 = x.applytime, 审核人 = x.approver == null ? "" : x.approver.displayname, 审核结果 = x.result })
                .ToList();
            dgvStock.DataSource = query;
            dgvItem.DataSource = null;
        }

        public override void InitData(EntityBase entity)
        {
            ApplyId = entity.id;
            var query = Service.Common.db.Queryable<Model.Entities.Apply>().Where(x => x.id == entity.id).First();
            if (query == null)
            {
                MessageBox.Show("未找到申领记录！");
                return;
            }
            apply = query;
            var applyitems = Service.Common.db.Queryable<ApplyItem>()
                .Mapper(x => x.goods, x => x.goodsid)
                .Mapper(x => x.warehouse, x => x.warehouseid)
                .Where(x => x.applyid == query.uuid)
                .OrderBy(x => x.sort).ToList();
            applyItems = applyitems;
            List<ApplyItem> OrderList = applyitems;
            Expressionable<Stock> exp = new Expressionable<Stock>();
            foreach (var item in OrderList)
            {
                exp.Or(it => it.warehouseid == item.warehouseid && it.goodsid == item.goodsid);
            }
            var items = applyitems.Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 单价 = x.goods.price, 数量 = x.count })
                .ToList();
            dgvItem.DataSource = items;
            //var goodsids = applyitems.Select(x => string.Join("_", x.warehouseid, x.goodsid)).Distinct().ToArray();
            var stock = Service.Common.db.Queryable<Stock>()
                       .Mapper(x => x.warehouse, x => x.warehouseid)
                       .Mapper(x => x.goods, x => x.goodsid)
                       .Where(exp.ToExpression())
                       .ToList();
            stocks = stock;
            var stocktable = stock.Select(x => new
            {
                编号 = x.id,
                仓库 = x.warehouse.name,
                物资 = x.goods.name,
                数量 = x.count,
                单位 = x.goods.unit,
                规格 = x.goods.specification,
                物资类型 = x.goods.goodstype.ToString(),
                //供应商 = x.goods.supplier.name,
                单价 = x.goods.price,
                总价 = (decimal)x.count * x.goods.price
            }).ToList();
            dgvStock.DataSource = stocktable;
        }

        private void dgvApply_SelectionChanged(object sender, EventArgs e)
        {
            //var dgv = sender as DataGridView;
            //if (dgv.SelectedRows.Count < 1)
            //    return;
            //var order_num = dgv.SelectedRows[0].Cells["单号"].Value.ToString();
            //var query = Service.Common.db.Queryable<ApplyItem>()
            //    .Mapper(x => x.goods, x => x.goodsid)
            //    .Mapper(x => x.warehouse, x => x.warehouseid)
            //    .Where(x => x.applyid == order_num)
            //    .OrderBy(x => x.sort).ToList().Select(x => new { 编号 = x.sort, 商品名称 = x.goods.name, 仓库 = x.warehouse.name, 数量 = x.count })
            //    .ToList();
            //dgvItem.DataSource = query;
        }

        private void btnApprove_Click(object sender, EventArgs e)
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
            var id = ApplyId;
            //var order_num = dgvStock.SelectedRows[0].Cells["单号"].Value.ToString();
            var query = applyItems;
            try
            {
                List<Tuple<long, long, int>> param = new List<Tuple<long, long, int>>();
                foreach (var item in query)
                {
                    param.Add(new Tuple<long, long, int>(item.warehouseid, item.goodsid, item.count));
                }
                if (Service.Business.CheckStock(param))
                {
                    if (Service.Business.ApproveApply<Model.Entities.Apply>(id))
                    {
                        //生成出库单
                        var uuid = Guid.NewGuid().ToString();
                        var exwarehouse = new Model.Entities.ExWarehouse()
                        {
                            uuid = uuid,
                            applierid = Runtime.Instance.currentUser.id,
                            orderid = apply.id,
                            applytime = DateTime.Now,
                            result = ApplyResult.未审批,
                        };
                        var exwarehouseitems = new List<ExWarehouseItem>();
                        foreach (var item in query)
                        {
                            exwarehouseitems.Add(new ExWarehouseItem()
                            {
                                applyid = exwarehouse.uuid,
                                count = item.count,
                                goodsid = item.goodsid,
                                sort = item.sort,
                                warehouseid = item.warehouseid
                            });
                        }
                        Service.DAO.Insert(exwarehouse);
                        Service.DAO.Insert(exwarehouseitems.ToArray());
                        ManageMainControl.Instance.FreshUI(typeof(ApplyQueryControl));
                    }
                    else
                        MessageBox.Show("批准失败！");
                }
                else
                    MessageBox.Show("物资库存不足，批准失败！");
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
            if (!Service.Business.RecallApply<Model.Entities.Apply>(id))
                MessageBox.Show("撤回失败！");
            ManageMainControl.Instance.FreshUI(typeof(ApplyQueryControl));
        }
    }
}
