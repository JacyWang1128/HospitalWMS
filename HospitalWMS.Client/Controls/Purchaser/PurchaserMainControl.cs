using HospitalWMS.Client.Controls.Manager.Purchase;
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

namespace HospitalWMS.Client.Controls.Purchaser
{
    public partial class PurchaserMainControl : UserControl
    {
        private static PurchaserMainControl instance = null;

        public static PurchaserMainControl Instance { get => instance; set => instance = value; }
        public ChangePasswordControl ChangePasswordControl
        {
            get
            {
                if (changePasswordControl == null)
                    changePasswordControl = new ChangePasswordControl();
                return changePasswordControl;
            }
            set => changePasswordControl = value;
        }

        public PurchaseQueryControl PurchaseQueryControl
        {
            get
            {
                if (purchaseQueryControl == null)
                    purchaseQueryControl = new PurchaseQueryControl();
                return purchaseQueryControl;
            }
            set => purchaseQueryControl = value;
        }

        public ApplyPurchaseQueryControl ApplyPurchaseQueryControl
        {
            get
            {
                if (applyPurchaseQueryControl == null)
                    applyPurchaseQueryControl = new ApplyPurchaseQueryControl();
                return applyPurchaseQueryControl;
            }
            set => applyPurchaseQueryControl = value;
        }

        public ApplyPurchaseManageControl ApplyPurchaseManageControl
        {
            get
            {
                if (applyPurchaseManageControl == null)
                    applyPurchaseManageControl = new ApplyPurchaseManageControl();
                return applyPurchaseManageControl;
            }
            set => applyPurchaseManageControl = value;
        }

        public PurchaseManageControl PurchaseManageControl
        {
            get
            {
                if (purchaseManageControl == null)
                    purchaseManageControl = new PurchaseManageControl();
                return purchaseManageControl;
            }
            set => purchaseManageControl = value;
        }

        private ChangePasswordControl changePasswordControl = null;
        private PurchaseQueryControl purchaseQueryControl = null;
        private ApplyPurchaseQueryControl applyPurchaseQueryControl = null;
        private ApplyPurchaseManageControl applyPurchaseManageControl = null;
        private PurchaseManageControl purchaseManageControl = null;

        public PurchaserMainControl()
        {
            InitializeComponent();
        }

        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count < 1)
            {
                switch (e.Node.Text)
                {
                    case "查询申购":
                        FreshUI(ApplyPurchaseQueryControl);
                        break;
                    case "查询采购":
                        FreshUI(PurchaseQueryControl);
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
                }
            }
        }
    }
}
