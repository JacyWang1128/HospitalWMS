using HospitalWMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Client.Controls.Admin
{
    public partial class WarehouseManageControl : BaseDataControl
    {
        public WarehouseManageControl()
        {
            InitializeComponent();
        }

        public override void FreshData()
        {
            dgvWarehouse.DataSource = Service.Common.db.Queryable<Warehouse>().Select(x => new { 编号= x.id,仓库编号 = x.num, 名称 = x.name }).ToDataTable();
            dgvWarehouse.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fiWarehouseName.Value))
            {
                MessageBox.Show("请输入仓库名称！");
                return;
            }
            if (string.IsNullOrWhiteSpace(fiWarehouseNum.Value))
            {
                MessageBox.Show("请输入仓库编号！");
                return;
            }
            if (Service.Common.db.Queryable<Department>().Any(x => x.num == fiWarehouseNum.Value))
            {
                MessageBox.Show("请勿添加重复仓库编号！");
                return;
            }
            if (Service.Common.db.Queryable<Department>().Any(x => x.name == fiWarehouseName.Value))
            {
                MessageBox.Show("请勿添加重复仓库名称！");
                return;
            }
            var warehouse = new Warehouse() { num = fiWarehouseNum.Value, name = fiWarehouseName.Value };
            Service.DAO.Insert(warehouse);
            FreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fiWarehouseName.Value))
            {
                MessageBox.Show("请输入仓库名称！");
                return;
            }
            if (string.IsNullOrWhiteSpace(fiWarehouseNum.Value))
            {
                MessageBox.Show("请输入仓库编号！");
                return;
            }
            if (dgvWarehouse.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要更新的行！");
                return;
            }
            var entity = Service.Common.db.Queryable<Warehouse>().First(x => x.id == Convert.ToInt64(dgvWarehouse.SelectedRows[0].Cells["编号"].Value));
            if (Service.Common.db.Queryable<Department>().Any(x => x.id != entity.id && x.num == fiWarehouseNum.Value))
            {
                MessageBox.Show("仓库编号重复！");
                return;
            }
            if (Service.Common.db.Queryable<Department>().Any(x => x.id != entity.id && x.name == fiWarehouseName.Value))
            {
                MessageBox.Show("仓库名称重复！");
                return;
            }
            entity.num = fiWarehouseNum.Value;
            entity.name = fiWarehouseName.Value;
            Service.DAO.Update(entity);
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            Service.DAO.Delete(new Warehouse() { id = Convert.ToInt64(dgvWarehouse.SelectedRows[0].Cells["编号"].Value) });
            FreshData();
        }

        private void WarehouseManageControl_Load(object sender, EventArgs e)
        {
            FreshData();
        }
    }
}
