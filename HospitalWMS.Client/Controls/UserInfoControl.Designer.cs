
namespace HospitalWMS.Client.Controls
{
    partial class UserInfoControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ibtnLogout = new Sunny.UI.UIImageButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibtnLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.BackColor = System.Drawing.Color.Transparent;
            this.uiAvatar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiAvatar1.FillColor = System.Drawing.Color.Transparent;
            this.uiAvatar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiAvatar1.Location = new System.Drawing.Point(0, 0);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(63, 63);
            this.uiAvatar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiAvatar1.TabIndex = 0;
            this.uiAvatar1.Text = "uiAvatar1";
            this.uiAvatar1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiAvatar1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.uiAvatar1_MouseDoubleClick);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(63, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(206, 63);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ibtnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(269, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(63, 63);
            this.panel1.TabIndex = 2;
            // 
            // ibtnLogout
            // 
            this.ibtnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibtnLogout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibtnLogout.Image = global::HospitalWMS.Client.Properties.Resources.退出登录;
            this.ibtnLogout.Location = new System.Drawing.Point(10, 10);
            this.ibtnLogout.Margin = new System.Windows.Forms.Padding(10);
            this.ibtnLogout.Name = "ibtnLogout";
            this.ibtnLogout.Padding = new System.Windows.Forms.Padding(10);
            this.ibtnLogout.Size = new System.Drawing.Size(43, 43);
            this.ibtnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibtnLogout.TabIndex = 3;
            this.ibtnLogout.TabStop = false;
            this.ibtnLogout.Text = null;
            this.ibtnLogout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ibtnLogout.Click += new System.EventHandler(this.ibtnLogout_Click);
            // 
            // UserInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiAvatar1);
            this.Name = "UserInfoControl";
            this.Size = new System.Drawing.Size(332, 63);
            this.Load += new System.EventHandler(this.UserInfoControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserInfoControl_Paint);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibtnLogout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIImageButton ibtnLogout;
    }
}
