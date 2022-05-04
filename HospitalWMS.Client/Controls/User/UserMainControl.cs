using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Client.Controls.User
{
    public partial class UserMainControl : UserControl
    {
        private ChangePasswordControl _changePasswordControl = null;
        private RestitutionControl _restitutionControl = null;
        private ApplyControl _applyControl = null;

        public UserMainControl()
        {
            InitializeComponent();
        }

        public ChangePasswordControl ChangePasswordControl
        {
            get
            {
                if (_changePasswordControl == null)
                    _changePasswordControl = new ChangePasswordControl() { Dock = DockStyle.Fill };
                return _changePasswordControl;
            }
            set => _changePasswordControl = value;
        }

        public RestitutionControl RestitutionControl
        {
            get
            {
                if (_restitutionControl == null)
                    _restitutionControl = new RestitutionControl() { Dock = DockStyle.Fill };
                return _restitutionControl;
            }
            set => _restitutionControl = value;
        }

        public ApplyControl ApplyControl
        {
            get
            {
                if (_applyControl == null)
                    _applyControl = new ApplyControl() { Dock = DockStyle.Fill };
                return _applyControl;
            }
            set => _applyControl = value;
        }

        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ChangePasswordControl);
        }

        private void btnRestitution_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(RestitutionControl);
            RestitutionControl.FreshData();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //uiPanel1.Controls.Clear();
            //uiPanel1.Controls.Add(ApplyControl);
            //ApplyControl.FreshData();
            FreshUI(ApplyControl);
        }

        private void FreshUI(BaseDataControl control)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(control);
            control.FreshData();
        }

        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Nodes.Count < 1)
            {
                switch (e.Node.Text)
                {
                    case "申领物资":
                        break;
                    case "申领查询":
                        break;
                    case "退库物资":
                        break;
                    case "退库查询":
                        break;
                    case "申购物资":
                        break;
                    case "申购查询":
                        break;
                    case "修改个人信息":
                        FreshUI(ChangePasswordControl);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
