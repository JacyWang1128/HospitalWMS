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

namespace HospitalWMS.Client.Controls.DeptManager
{
    public partial class DeptManageMainControl : UserControl
    {
        private ChangePasswordControl changePasswordControl = null;
        private ApplyPlanControl applyPlanControl = null;
        private PlanQueryControl planQueryControl = null;
        private static DeptManageMainControl instance = null;

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

        public ApplyPlanControl ApplyPlanControl
        {
            get
            {
                if (applyPlanControl == null)
                    applyPlanControl = new ApplyPlanControl();
                return applyPlanControl;
            }
            set => applyPlanControl = value;
        }

        public PlanQueryControl PlanQueryControl
        {
            get
            {
                if (planQueryControl == null)
                    planQueryControl = new PlanQueryControl();
                return planQueryControl;
            }
            set => planQueryControl = value;
        }

        public static DeptManageMainControl Instance { get => instance; set => instance = value; }

        public DeptManageMainControl()
        {
            InitializeComponent();
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

        public void ClearWrap()
        {
            uiPanel1.Controls.Clear();
        }

        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count < 1)
            {
                switch (e.Node.Text)
                {
                    case "查看申领计划":
                        FreshUI(PlanQueryControl);
                        break;
                    case "创建申领计划":
                        FreshUI(ApplyPlanControl);
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
