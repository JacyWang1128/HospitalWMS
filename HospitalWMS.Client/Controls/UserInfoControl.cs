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
    public partial class UserInfoControl : UserControl
    {
        public UserInfoControl()
        {
            InitializeComponent();
        }

        private void UserInfoControl_Load(object sender, EventArgs e)
        {
            if (Runtime.Instance.CurrentUser == null)
                return;
            uiLabel1.Text = $"尊敬的{Runtime.Instance.CurrentUser.displayname??"用户"}欢迎您";
        }

        private void uiAvatar1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("是否退出登录？","提示",MessageBoxButtons.OKCancel) == DialogResult.OK)
                Runtime.Instance.Restart();
        }

        private void ibtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出登录？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Runtime.Instance.Restart();
        }

        private void UserInfoControl_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = 63;
            uiAvatar1.Width = 63;
        }
    }
}
