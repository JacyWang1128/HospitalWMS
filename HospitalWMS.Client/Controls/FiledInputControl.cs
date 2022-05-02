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
    public partial class FiledInputControl : UserControl
    {
        public FiledInputControl()
        {
            InitializeComponent();
        }
        [CategoryAttribute("控件属性"), DescriptionAttribute("密码样式"), ReadOnly(false)]
        public char PwdCharacter
        {
            get
            {
                return uiTextBox1.PasswordChar;
            }
            set
            {
                uiTextBox1.PasswordChar = value;
            }
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
        [CategoryAttribute("控件属性"), DescriptionAttribute("字段值"), ReadOnly(false)]
        public string Value
        {
            get
            {
                return uiTextBox1.Text;
            }
            set
            {
                uiTextBox1.Text = value;
            }
        }

        private void FiledInputControl_Resize(object sender, EventArgs e)
        {
            uiLabel1.Size = new Size(Convert.ToInt32(this.Size.Width * 0.33),this.Size.Height);
        }

        private void FiledInputControl_Load(object sender, EventArgs e)
        {
            uiLabel1.Size = new Size(Convert.ToInt32(this.Size.Width * 0.33), this.Size.Height);
        }
    }
}
