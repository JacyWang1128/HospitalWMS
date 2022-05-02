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

namespace HospitalWMS.Client.Controls.Manager.Supplier
{
    public partial class SupplierManageControl : BaseDataControl
    {
        public SupplierManageControl()
        {
            InitializeComponent();
        }
        public override void FreshData()
        {
            dgvSupplier.DataSource = Service.Common.db.Queryable<Model.Entities.Supplier>().ToList().Select(x => new { 编号 = x.id, 名称 = x.name, 合同到期时间 = x.expire, 所属仓库 = string.IsNullOrWhiteSpace(x.warehouseids) ? "所有" : x.warehouseids }).ToList();
        }

        private void SupplierManageControl_Load(object sender, EventArgs e)
        {
            var warehouses = Service.Common.db.Queryable<Warehouse>().Select(x => x.name).ToList();
            warehouses.ForEach(x => ctvWarehouse.Nodes.Add(x));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entity = new Model.Entities.Supplier()
            {
                isabandon = dpExpire.Value < DateTime.Now,
                name = fiName.Value,
                expire = dpExpire.Value,
                warehouseids = ctvWarehouse.Text
            };
            try
            {
                Service.DAO.Insert(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加供应商失败！");
            }
            FreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSupplier.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请选择要更新的行！");
                    return;
                }
                var entity = Service.Common.db.Queryable<Model.Entities.Supplier>().First(x => x.id == Convert.ToInt64(dgvSupplier.SelectedRows[0].Cells["编号"].Value));
                entity.isabandon = dpExpire.Value < DateTime.Now;
                entity.expire = dpExpire.Value;
                entity.name = fiName.Value;
                entity.warehouseids = ctvWarehouse.Text;
                Service.DAO.Update(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改供应商信息失败！");
            }
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            Service.DAO.Delete(new Model.Entities.Supplier() { id = Convert.ToInt64(dgvSupplier.SelectedRows[0].Cells["编号"].Value) });
            FreshData();
        }
    }
}
