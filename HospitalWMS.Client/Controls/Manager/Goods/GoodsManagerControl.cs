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
    public partial class GoodsManagerControl : BaseDataControl
    {
        public GoodsManagerControl()
        {
            InitializeComponent();
        }

        public override void FreshData()
        {
            var temp = Service.Common.db.Queryable<Model.Entities.Goods>()
                //.Mapper(x => x.specification, x => x.specificationid)
                .Mapper(x => x.supplier, x => x.supplierid).ToList()
                .Select(x => new { 编号 = x.id, 商品编号 = x.num, 物资名称 = x.name, 规格 = x.specification, 物资类型 = x.goodstype.ToString(), 单位 = x.unit, 价格 = x.price, 供应商 = x.supplier.name })
                .ToList();
            dgvGoods.DataSource = temp;
            dgvGoods.Columns[0].Visible = false;
            cbGoodsType.DataSource = Enum.GetNames(typeof(GoodsType));
            //cbSpecification.DataSource = Service.Common.db.Queryable<Specification>().Select(x => new { x.id, x.name }).ToDataTable();
            //cbSpecification.DisplayMember = "name";
            cbSupplier.DataSource = Service.Common.db.Queryable<Model.Entities.Supplier>().Select(x => new { x.id, x.name }).ToDataTable();
            cbSupplier.DisplayMember = "name";
        }
        private Model.Entities.Goods SetValue(Model.Entities.Goods entity)
        {
            entity.name = fiName.Value;
            entity.goodstype = (GoodsType)cbGoodsType.SelectedIndex;
            entity.price = Convert.ToDecimal(fiPrice.Value);
            entity.specification = fiSpecification.Value;
            entity.supplierid = Convert.ToInt64((cbSupplier.SelectedItem as DataRowView).Row["id"]);
            entity.unit = fiUnit.Value;
            entity.num = fiGoodsNum.Value;
            return entity;
        }
        private void Lable_Paint(object sender, PaintEventArgs e)
        {
            var control = sender as Label;
            control.Size = new Size(Convert.ToInt32(control.Parent.Width * 0.33), control.Height);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal price = 0;
            if (decimal.TryParse(fiPrice.Value, out price))
            {
                try
                {
                    var entity = SetValue(new Model.Entities.Goods());
                    Service.Business.InsertGoods(entity);
                    //Service.DAO.Insert(entity);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"创建物资失败！{ex.Message??$"\r\n{ex.Message}！"}");
                }
            }
            else
                MessageBox.Show("请输入正确价格！");
            FreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGoods.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请选择要更新的行！");
                    return;
                }
                var entity = SetValue(Service.Common.db.Queryable<Model.Entities.Goods>().First(x => x.id == Convert.ToInt64(dgvGoods.SelectedRows[0].Cells["编号"].Value)));
                Service.Business.UpdateGoods(entity);
                //Service.DAO.Update(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"修改物资信息失败！{ex.Message ?? $"\r\n{ex.Message}！"}");
            }
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGoods.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            Service.DAO.Delete(new Model.Entities.Goods() { id = Convert.ToInt64(dgvGoods.SelectedRows[0].Cells["编号"].Value) });
            FreshData();
        }
    }
}
