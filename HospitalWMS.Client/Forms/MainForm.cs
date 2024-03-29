﻿using HospitalWMS.Client.Controls.Admin;
using HospitalWMS.Client.Controls.DeptManager;
using HospitalWMS.Client.Controls.Manager;
using HospitalWMS.Client.Controls.Matron;
using HospitalWMS.Client.Controls.Purchaser;
using HospitalWMS.Client.Controls.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Client.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            switch (Runtime.Instance.CurrentUser.role)
            {
                case Model.Enums.UserType.系统管理员:
                    var control = new AdminMainControl() { Dock = DockStyle.Fill };
                    uiContent.Controls.Add(control);
                    break;
                case Model.Enums.UserType.申领员:
                    var control2 = new UserMainControl() { Dock = DockStyle.Fill };
                    uiContent.Controls.Add(control2);
                    UserMainControl.Instance = control2;
                    break;
                case Model.Enums.UserType.仓库管理员:
                    var control3 = new ManageMainControl() { Dock = DockStyle.Fill };
                    ManageMainControl.Instance = control3;
                    uiContent.Controls.Add(control3);
                    break;
                case Model.Enums.UserType.采购人员:
                    var control4 = new PurchaserMainControl() { Dock = DockStyle.Fill };
                    PurchaserMainControl.Instance = control4;
                    uiContent.Controls.Add(control4);
                    break;
                case Model.Enums.UserType.科室管理员:
                    var control5 = new DeptManageMainControl() { Dock = DockStyle.Fill };
                    DeptManageMainControl.Instance = control5;
                    uiContent.Controls.Add(control5);
                    break;
                case Model.Enums.UserType.护士长:
                    var control6 = new MatronMainControl() { Dock = DockStyle.Fill };
                    MatronMainControl.Instance = control6;
                    uiContent.Controls.Add(control6);
                    break;
                default:
                    break;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            userInfoControl1.Width = Convert.ToInt32(userInfoControl1.Parent.Width * 0.2);
        }
    }
}
