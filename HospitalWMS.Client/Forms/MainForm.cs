﻿using HospitalWMS.Client.Controls.Admin;
using HospitalWMS.Client.Controls.Manager;
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
            switch (Service.Common.currentUser.role)
            {
                case Model.Enums.UserType.系统管理员:
                    uiContent.Controls.Add(new AdminMainControl() { Dock = DockStyle.Fill });
                    break;
                case Model.Enums.UserType.申领员:
                    uiContent.Controls.Add(new UserMainControl() { Dock = DockStyle.Fill });
                    break;
                case Model.Enums.UserType.仓库管理员:
                    uiContent.Controls.Add(new ManageMainControl() { Dock = DockStyle.Fill });
                    break;
                default:
                    break;
            }
        }
    }
}