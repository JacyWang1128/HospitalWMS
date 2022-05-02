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

namespace HospitalWMS.Client.Controls.Manager.Goods
{
    public partial class StockManageControl : UserControl
    {
        public StockManageControl()
        {
            InitializeComponent();
        }

        public void FreshData(bool isFilter = false)
        {
            //var temp = Service.Common.db.Queryable<Stock>()
            //    .Mapper(x => x.warehouse, x => x.warehouseid)
            //    .Mapper(x => x.goods, x => x.goodsid).ToList();
            if (isFilter)
            {
                //var warehouseid = Convert.ToInt64((cbWarehouse.SelectedItem as DataRowView).Row["id"].ToString());
                //var goodsid = Convert.ToInt64((cbGoods.SelectedItem as DataRowView).Row["id"].ToString());
                //var supplierid = Convert.ToInt64((cbSupplier.SelectedItem as DataRowView).Row["id"].ToString());
                //var specificationid = Convert.ToInt64((cbSpecification.SelectedItem as DataRowView).Row["id"].ToString());
                //var goodstype = cbGoodsType.SelectedIndex;
                var query = Service.Common.db.Queryable<Stock>()
                    .Mapper(x => x.warehouse, x => x.warehouseid)
                    .Mapper(x => x.goods, x => x.goodsid).ToList()
                    .Where(x => (cbWarehouse.SelectedItem == null ? true : x.warehouseid == Convert.ToInt64((cbWarehouse.SelectedItem as DataRowView).Row["id"].ToString()))
                            && (cbGoods.SelectedItem == null ? true : x.goodsid == Convert.ToInt64((cbGoods.SelectedItem as DataRowView).Row["id"].ToString()))
                            //        && string.IsNullOrWhiteSpace(cbSupplier.SelectedText)?true: x.goods.supplier.id == Convert.ToInt64((cbSupplier.SelectedItem as DataRowView).Row["id"].ToString())
                            //        && string.IsNullOrWhiteSpace(cbSpecification.SelectedText)?true: x.goods.specification.id == Convert.ToInt64((cbSpecification.SelectedItem as DataRowView).Row["id"].ToString())
                            && (cbGoodsType.SelectedItem == null ? true : x.goods.goodstype.ToString() == cbGoodsType.SelectedItem.ToString())).ToList()
                    .Select(x => new
                    {
                        编号 = x.id,
                        仓库 = x.warehouse.name,
                        物资 = x.goods.name,
                        数量 = x.count,
                        单位 = x.goods.unit,
                    //规格 = x.goods.specification.name,
                    物资类型 = x.goods.goodstype.ToString(),
                    //供应商 = x.goods.supplier.name,
                    单价 = x.goods.price,
                        总价 = (decimal)x.count * x.goods.price
                    }).ToList();
                dgvStock.DataSource = query;
            }
            else
            {
                var query = Service.Common.db.Queryable<Stock>()
                       .Mapper(x => x.warehouse, x => x.warehouseid)
                       .Mapper(x => x.goods, x => x.goodsid).ToList()
                       .Select(x => new
                       {
                           编号 = x.id,
                           仓库 = x.warehouse.name,
                           物资 = x.goods.name,
                           数量 = x.count,
                           单位 = x.goods.unit,
                        //规格 = x.goods.specification.name,
                        物资类型 = x.goods.goodstype.ToString(),
                        //供应商 = x.goods.supplier.name,
                        单价 = x.goods.price,
                           总价 = (decimal)x.count * x.goods.price
                       }).ToList();
                dgvStock.DataSource = query;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FreshData(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FreshData();
        }

        private void StockManageControl_Load(object sender, EventArgs e)
        {
            cbWarehouse.DataSource = Service.Common.db.Queryable<Model.Entities.Warehouse>().ToDataTable();
            cbWarehouse.DisplayMember = "name";
            cbGoods.DataSource = Service.Common.db.Queryable<Model.Entities.Goods>().ToDataTable();
            cbGoods.DisplayMember = "name";
            cbSupplier.DataSource = Service.Common.db.Queryable<Model.Entities.Supplier>().ToDataTable();
            cbSupplier.DisplayMember = "name";
            cbSpecification.DataSource = Service.Common.db.Queryable<Model.Entities.Specification>().ToDataTable();
            cbSpecification.DisplayMember = "name";
            cbGoodsType.DataSource = Enum.GetNames(typeof(GoodsType));
        }
    }
}
