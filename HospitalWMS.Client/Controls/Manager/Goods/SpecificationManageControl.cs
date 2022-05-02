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

namespace HospitalWMS.Client.Controls.Manager.Goods
{
    public partial class SpecificationManageControl : BaseDataControl
    {
        public SpecificationManageControl()
        {
            InitializeComponent();
        }

        public override void FreshData()
        {
            dgvSpecification.DataSource = Service.Common.db.Queryable<Specification>().Select(x => new { 编号 = x.id, 名称 = x.name }).ToDataTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSpecification.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要更新的行！");
                return;
            }
            var entity = Service.Common.db.Queryable<Specification>().First(x => x.id == Convert.ToInt64(dgvSpecification.SelectedRows[0].Cells["编号"].Value));
            entity.name = fiSpecification.Value;
            Service.DAO.Update(entity);
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSpecification.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            Service.DAO.Delete(new Specification() { id = Convert.ToInt64(dgvSpecification.SelectedRows[0].Cells["编号"].Value) });
            FreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entity = new Specification() { name = fiSpecification.Value };
            Service.DAO.Insert(entity);
            FreshData();
        }
    }
}
