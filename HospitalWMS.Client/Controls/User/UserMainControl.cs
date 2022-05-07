using HospitalWMS.Model;
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
        private static UserMainControl instance = null;
        private ChangePasswordControl _changePasswordControl = null;
        private RestitutionControl _restitutionControl = null;
        private ApplyControl _applyControl = null;
        private ApplyPurchaseControl applyPurchaseControl = null;
        private SelfApplyQueryControl selfApplyQueryControl = null;
        private SelfApplyPurchaseQueryControl selfApplyPurchaseQuery = null;
        private SelfRestitutionQueryControl selfRestitutionQueryControl = null;

        public UserMainControl()
        {
            InitializeComponent();
        }

        public ChangePasswordControl ChangePasswordControl
        {
            get
            {
                if (_changePasswordControl == null)
                    _changePasswordControl = new ChangePasswordControl();
                return _changePasswordControl;
            }
            set => _changePasswordControl = value;
        }

        public RestitutionControl RestitutionControl
        {
            get
            {
                if (_restitutionControl == null)
                    _restitutionControl = new RestitutionControl();
                return _restitutionControl;
            }
            set => _restitutionControl = value;
        }

        public ApplyControl ApplyControl
        {
            get
            {
                if (_applyControl == null)
                    _applyControl = new ApplyControl();
                return _applyControl;
            }
            set => _applyControl = value;
        }

        public static UserMainControl Instance { get => instance; set => instance = value; }
        public ApplyPurchaseControl ApplyPurchaseControl
        {
            get
            {
                if (applyPurchaseControl == null)
                    applyPurchaseControl = new ApplyPurchaseControl();
                return applyPurchaseControl;
            }
            set => applyPurchaseControl = value;
        }
        public SelfApplyQueryControl SelfApplyQueryControl
        {
            get
            {
                if (selfApplyQueryControl == null)
                    selfApplyQueryControl = new SelfApplyQueryControl();
                return selfApplyQueryControl;
            }
            set => selfApplyQueryControl = value;
        }
        public SelfApplyPurchaseQueryControl SelfApplyPurchaseQuery
        {
            get
            {
                if (selfApplyPurchaseQuery == null)
                    selfApplyPurchaseQuery = new SelfApplyPurchaseQueryControl();
                return selfApplyPurchaseQuery;
            }
            set => selfApplyPurchaseQuery = value;
        }
        public SelfRestitutionQueryControl SelfRestitutionQueryControl
        {
            get
            {
                if (selfRestitutionQueryControl == null)
                    selfRestitutionQueryControl = new SelfRestitutionQueryControl();
                return selfRestitutionQueryControl;
            }
            set => selfRestitutionQueryControl = value;
        }

        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count < 1)
            {
                switch (e.Node.Text)
                {
                    case "申领物资":
                        FreshUI(ApplyControl);
                        break;
                    case "申领查询":
                        FreshUI(SelfApplyQueryControl);
                        break;
                    case "退库物资":
                        FreshUI(RestitutionControl);
                        break;
                    case "退库查询":
                        FreshUI(SelfRestitutionQueryControl);
                        break;
                    case "申购物资":
                        FreshUI(ApplyPurchaseControl);
                        break;
                    case "申购查询":
                        FreshUI(SelfApplyPurchaseQuery);
                        break;
                    case "修改个人信息":
                        FreshUI(ChangePasswordControl);
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

        public void FreshUI(Type UItype)
        {
            var properties = this.GetType().GetProperties();
            foreach (var item in properties)
            {
                if (item.PropertyType.Name == UItype.Name)
                {
                    BaseDataControl control = null;
                    control = item.GetValue(this) as BaseDataControl;
                    FreshUI(control);
                    return;
                }
            }
        }

        public void SkipUI(Type UItype, EntityBase entity)
        {
            var properties = this.GetType().GetProperties();
            foreach (var item in properties)
            {
                if (item.PropertyType.Name == UItype.Name)
                {
                    BaseDataControl control = null;
                    control = item.GetValue(this) as BaseDataControl;
                    uiPanel1.Controls.Clear();
                    uiPanel1.Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                    control.InitData(entity);
                    return;
                }
            }
        }
    }
}
