﻿using System;
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
            if (Service.Common.currentUser == null)
                return;
            uiLabel1.Text = $"尊敬的{Service.Common.currentUser.displayname??"用户"}欢迎您";
        }

        private void uiAvatar1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("是否退出登录？","提示",MessageBoxButtons.OKCancel) == DialogResult.OK)
                Runtime.Instance.Restart();
        }
    }
}