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
    public partial class DeptManageControl : BaseDataControl
    {
        public DeptManageControl()
        {
            InitializeComponent();
        }
        public override void FreshData()
        {
            dgvDept.DataSource = Service.Common.db.Queryable<Department>().Select(x => new { 编号 = x.id, 名称 = x.name}).ToDataTable();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dept = new Department() { name = fiDeptname.Value };
            Service.DAO.Insert(dept); 
            FreshData();
        }

        private void DeptMangeageControl_Load(object sender, EventArgs e)
        {
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDept.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            Service.DAO.Delete(new Department() { id = Convert.ToInt64(dgvDept.SelectedRows[0].Cells["编号"].Value) });
            FreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDept.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要更新的行！");
                return;
            }
            var entity = Service.Common.db.Queryable<Department>().First(x => x.id == Convert.ToInt64(dgvDept.SelectedRows[0].Cells["编号"].Value));
            entity.name = fiDeptname.Value;
            Service.DAO.Update(entity);
            FreshData();
        }
    }
}
