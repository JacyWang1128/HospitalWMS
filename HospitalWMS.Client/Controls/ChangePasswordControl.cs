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
            if (fiOldpwd.Value.ToSHA() == Service.Common.currentUser.password)
            {
                if (fiNewpwd.Value == fiSubmitpwd.Value)
                {
                    if (fiNewpwd.Value.ToSHA() != Service.Common.currentUser.password)
                    {
                        var entity = Service.Common.currentUser;
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
