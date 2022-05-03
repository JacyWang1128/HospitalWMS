using HospitalWMS.Client.Controls.Manager.Goods;
using HospitalWMS.Client.Controls.Manager.Supplier;
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
                    _userMange = new UserManageControl();
                }
                return _userMange;
            }
            set => _userMange = value;
        }

        public DeptManageControl DeptMangeageControl
        {
            get
            {
                if (_deptMangeageControl == null)
                    _deptMangeageControl = new DeptManageControl();
                return _deptMangeageControl;
            }
            set => _deptMangeageControl = value;
        }

        public WarehouseManageControl WarehouseManageControl
        {
            get
            {
                if (_warehouseManageControl == null)
                    _warehouseManageControl = new WarehouseManageControl();
                return _warehouseManageControl;
            }
            set => _warehouseManageControl = value;
        }

        public SupplierManageControl SupplierManageControl
        {
            get
            {
                if (_supplierManageControl == null)
                    _supplierManageControl = new SupplierManageControl();
                return _supplierManageControl;
            }
            set => _supplierManageControl = value;
        }

        public GoodsManagerControl GoodsManagerControl
        {
            get
            {
                if (_goodsManagerControl == null)
                    _goodsManagerControl = new GoodsManagerControl();
                return _goodsManagerControl;
            }
            set => _goodsManagerControl = value;
        }

        private UserManageControl _userMange = null;

        private DeptManageControl _deptMangeageControl = null;

        private WarehouseManageControl _warehouseManageControl = null;

        private SupplierManageControl _supplierManageControl = null;
        private GoodsManagerControl _goodsManagerControl = null;

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

        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count < 1)
            {
                switch (e.Node.Text)
                {
                    case "管理用户":
                        FreshUI(UserMange);
                        break;
                    case "管理部门":
                        FreshUI(DeptMangeageControl);
                        break;
                    case "管理仓库":
                        FreshUI(WarehouseManageControl);
                        break;
                    case "管理供应商":
                        FreshUI(SupplierManageControl);
                        break;
                    case "管理物资":
                        FreshUI(GoodsManagerControl);
                        break;
                    default:
                        break;
                }
            }
        }
        private void FreshUI(BaseDataControl control)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.FreshData();
        }
    }
}
