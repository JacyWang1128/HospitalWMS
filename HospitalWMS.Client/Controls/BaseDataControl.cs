﻿using HospitalWMS.Model;
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
    public partial class BaseDataControl : UserControl
    {
        public BaseDataControl()
        {
            InitializeComponent();
        }

        public virtual void FreshData()
        {

        }

        public virtual void InitData(EntityBase entity)
        {

        }
    }
}
