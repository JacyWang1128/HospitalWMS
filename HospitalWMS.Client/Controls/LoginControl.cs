using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Client
{
    public partial class LoginControl: UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Service.Common.Login(uiTextBox1.Text, uiTextBox2.Text))
            {
                this.ParentForm.DialogResult = DialogResult.OK;
                this.ParentForm.Close();
            }
            else
                MessageBox.Show("用户名密码错误！");
        }
    }
}
