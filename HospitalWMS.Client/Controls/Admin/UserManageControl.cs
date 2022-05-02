using HospitalWMS.Model.Entities;
using HospitalWMS.Model.Enums;
using HospitalWMS.Service.Helpers;
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
    public partial class UserManageControl : BaseDataControl
    {
        public UserManageControl()
        {
            InitializeComponent();
        }

        public override void FreshData()
        {
            var te = Service.Common.db.Queryable<Model.Entities.User>().ToList();
            //var temp = Service.Common.db.Queryable<User, Department>((u, d) => u.departmentid == d.id)
            //    .Select((u, d) => new { 编号 = u.id, 用户名 = u.username, 昵称 = u.displayname, 密码 = u.password, 角色 = u.role.ToString(), 部门 = d.name }).ToList();
            var temp = Service.Common.db.Queryable<Model.Entities.User>().Mapper(x => x.department, x => x.departmentid).ToList().Select(u => new { 编号 = u.id, 用户名 = u.username, 昵称 = u.displayname, 密码 = u.password, 角色 = u.role.ToString(), 部门 = u.department == null?"":u.department.name }).ToList();
            dgvUser.DataSource = temp;
            cbxRole.DataSource = Enum.GetNames(typeof(UserType));
            cbxDept.DataSource = Service.Common.db.Queryable<Department>().Select(x => x.name).ToList();
        }

        private void UserManageControl_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var deptid = Service.Common.db.Queryable<Department>().First(x => x.name == cbxDept.SelectedValue.ToString()).id;
            var role = cbxRole.SelectedIndex;
            var entity = new Model.Entities.User()
            {
                username = fiUsername.Value,
                password = fiPassword.Value.ToSHA(),
                departmentid = deptid,
                displayname = fiDisplayname.Value,
                role = (UserType)role
            };
            try
            {
                Service.DAO.Insert(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加用户失败！");
            }
            FreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            Service.DAO.Delete(new Model.Entities.User() { id = Convert.ToInt64(dgvUser.SelectedRows[0].Cells["编号"].Value) });
            FreshData();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                bool isChangeSelfPassword = false;
                if (dgvUser.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请选择要更新的行！");
                    return;
                }
                if(Convert.ToInt64(dgvUser.SelectedRows[0].Cells["编号"].Value) == Service.Common.currentUser.id && fiPassword.Value.ToSHA() != Service.Common.currentUser.password)
                    isChangeSelfPassword = true;
                var entity = Service.Common.db.Queryable<Model.Entities.User>().First(x => x.id == Convert.ToInt64(dgvUser.SelectedRows[0].Cells["编号"].Value));
                var deptid = Service.Common.db.Queryable<Department>().First(x => x.name == cbxDept.SelectedValue.ToString()).id;
                var role = cbxRole.SelectedIndex;
                entity.username = fiUsername.Value;
                entity.password = fiPassword.Value.ToSHA();
                entity.departmentid = deptid;
                entity.displayname = fiDisplayname.Value;
                entity.role = (UserType)role;
                Service.DAO.Update(entity);
                if (isChangeSelfPassword)
                {
                    MessageBox.Show("您已修改自己的密码，请重新启动本软件！");
                    Application.Exit();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户信息失败！");
            }
            FreshData();
        }

        private void uiLabel1_Resize(object sender, EventArgs e)
        {
            uiLabel1.Size = new Size(Convert.ToInt32(uiLabel1.Parent.Size.Width * 0.33), uiLabel1.Size.Height);
        }

        private void uiLabel2_Resize(object sender, EventArgs e)
        {
            uiLabel2.Size = new Size(Convert.ToInt32(uiLabel2.Parent.Size.Width * 0.33), uiLabel2.Size.Height);
        }

    }
}
