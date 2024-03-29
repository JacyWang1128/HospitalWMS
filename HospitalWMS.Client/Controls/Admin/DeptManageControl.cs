﻿using HospitalWMS.Model.Entities;
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
            var table = Service.Common.db.Queryable<Department>().Select(x => new { 编号 = x.id, 部门编号 = x.num, 名称 = x.name }).ToDataTable();
            dgvDept.DataSource = Service.Common.db.Queryable<Department>().Select(x => new { 编号 = x.id,部门编号 = x.num, 名称 = x.name}).ToDataTable();
            dgvDept.Columns[0].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fiDeptname.Value))
            {
                MessageBox.Show("请输入部门名称！");
                return;
            }
            if (string.IsNullOrWhiteSpace(fiDeptNum.Value))
            {
                MessageBox.Show("请输入部门编号！");
                return;
            }
            if(Service.Common.db.Queryable<Department>().Any(x=>x.num == fiDeptNum.Value))
            {
                MessageBox.Show("请勿添加重复部门编号！");
                return;
            }
            if (Service.Common.db.Queryable<Department>().Any(x => x.name == fiDeptname.Value))
            {
                MessageBox.Show("请勿添加重复部门名称！");
                return;
            }
            var dept = new Department() { name = fiDeptname.Value,num = fiDeptNum.Value };
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
            if (string.IsNullOrWhiteSpace(fiDeptname.Value))
            {
                MessageBox.Show("请输入部门名称！");
                return;
            }
            if (string.IsNullOrWhiteSpace(fiDeptNum.Value))
            {
                MessageBox.Show("请输入部门编号！");
                return;
            }
            var entity = Service.Common.db.Queryable<Department>().First(x => x.id == Convert.ToInt64(dgvDept.SelectedRows[0].Cells["编号"].Value));
            entity.name = fiDeptname.Value;
            entity.num = fiDeptNum.Value;
            if (Service.Common.db.Queryable<Department>().Any(x => x.id != entity.id && x.num == fiDeptNum.Value))
            {
                MessageBox.Show("部门编号重复！");
                return;
            }
            if (Service.Common.db.Queryable<Department>().Any(x => x.id != entity.id && x.name == fiDeptname.Value))
            {
                MessageBox.Show("部门名称重复！");
                return;
            }
            Service.DAO.Update(entity);
            FreshData();
        }
    }
}
