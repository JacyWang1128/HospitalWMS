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

namespace HospitalWMS.Client.Controls
{
    public partial class ChangePasswordControl : BaseDataControl
    {
        public ChangePasswordControl()
        {
            InitializeComponent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(fiNewpwd.Value.Length > 12 || fiNewpwd.Value.Length < 6)
            {
                MessageBox.Show("密码长度应为6~12位！");
                return;
            }
            if (fiOldpwd.Value.ToSHA() == Runtime.Instance.CurrentUser.password)
            {
                if (fiNewpwd.Value == fiSubmitpwd.Value)
                {
                    if (fiNewpwd.Value.ToSHA() != Runtime.Instance.CurrentUser.password)
                    {
                        var entity = Runtime.Instance.CurrentUser;
                        entity.password = fiNewpwd.Value.ToSHA();
                        Service.DAO.Update(entity);
                        MessageBox.Show("您已修改密码，请重新登陆！");
                        Application.Exit();
                    }
                    else
                        MessageBox.Show("新密码与旧密码相同！");
                }
                else
                    MessageBox.Show("确认密码不一致！");
            }
            else
                MessageBox.Show("请输入正确原密码！");
        }
    }
}
