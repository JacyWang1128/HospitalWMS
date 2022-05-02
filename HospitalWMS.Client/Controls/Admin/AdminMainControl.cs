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
    public partial class AdminMainControl : UserControl
    {
        public UserManageControl UserMange
        {
            get
            {
                if (_userMange == null)
                {
                    _userMange = new UserManageControl() { Dock = DockStyle.Fill };
                }
                return _userMange;
            }
        }

        public DeptManageControl DeptMangeageControl
        {
            get
            {
                if (_deptMangeageControl == null)
                    _deptMangeageControl = new DeptManageControl() { Dock = DockStyle.Fill };
                return _deptMangeageControl;
            }
            set => _deptMangeageControl = value;
        }

        public WarehouseManageControl WarehouseManageControl
        {
            get
            {
                if (_warehouseManageControl == null)
                    _warehouseManageControl = new WarehouseManageControl() { Dock = DockStyle.Fill };
                return _warehouseManageControl;
            }
            set => _warehouseManageControl = value;
        }
        private UserManageControl _userMange = null;

        private DeptManageControl _deptMangeageControl = null;

        private WarehouseManageControl _warehouseManageControl = null;

        public AdminMainControl()
        {
            InitializeComponent();
        }

        private void uiUserMange_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(UserMange);
            UserMange.FreshData();
        }

        private void btnDeptMange_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(DeptMangeageControl);
            DeptMangeageControl.FreshData();
        }

        private void btnWarehouseManage_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(WarehouseManageControl);
            WarehouseManageControl.FreshData();
        }
    }
}
