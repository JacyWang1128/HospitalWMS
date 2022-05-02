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
    public partial class FiledComboControl : UserControl
    {
        public FiledComboControl()
        {
            InitializeComponent();
        }

        [CategoryAttribute("控件属性"), DescriptionAttribute("字段名称"), ReadOnly(false)]
        public string Title
        {
            get
            {
                return uiLabel1.Text;
            }
            set
            {
                uiLabel1.Text = value;
            }
        }
        [CategoryAttribute("控件属性"), DescriptionAttribute("选择值"), ReadOnly(false)]
        public object SelectedValue
        {
            get
            {
                return uiComboBox1.SelectedValue;
            }
            set
            {
                uiComboBox1.SelectedValue = value;
            }
        }
        [CategoryAttribute("控件属性"), DescriptionAttribute("选项集合"), ReadOnly(false)]
        public object SelectedSource
        {
            get
            {
                return uiComboBox1.DataSource;
            }
            set
            {
                uiComboBox1.DataSource = value;
            }
        }
        private void FiledComboControl_Resize(object sender, EventArgs e)
        {
            uiLabel1.Size = new Size(Convert.ToInt32(this.Size.Width * 0.33), this.Size.Height);
        }

        private void FiledComboControl_Load(object sender, EventArgs e)
        {
            uiLabel1.Size = new Size(Convert.ToInt32(this.Size.Width * 0.33), this.Size.Height);
        }
    }
}
