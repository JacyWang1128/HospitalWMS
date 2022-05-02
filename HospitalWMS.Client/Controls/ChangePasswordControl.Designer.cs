
namespace HospitalWMS.Client.Controls
{
    partial class ChangePasswordControl
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
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.fiOldpwd = new HospitalWMS.Client.Controls.FiledInputControl();
            this.fiNewpwd = new HospitalWMS.Client.Controls.FiledInputControl();
            this.fiSubmitpwd = new HospitalWMS.Client.Controls.FiledInputControl();
            this.btnModify = new Sunny.UI.UIButton();
            this.uiTitlePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.btnModify);
            this.uiTitlePanel1.Controls.Add(this.fiSubmitpwd);
            this.uiTitlePanel1.Controls.Add(this.fiNewpwd);
            this.uiTitlePanel1.Controls.Add(this.fiOldpwd);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(1064, 606);
            this.uiTitlePanel1.TabIndex = 0;
            this.uiTitlePanel1.Text = "修改密码";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // fiOldpwd
            // 
            this.fiOldpwd.BackColor = System.Drawing.Color.Transparent;
            this.fiOldpwd.Location = new System.Drawing.Point(300, 146);
            this.fiOldpwd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.fiOldpwd.Name = "fiOldpwd";
            this.fiOldpwd.PwdCharacter = '*';
            this.fiOldpwd.Size = new System.Drawing.Size(500, 40);
            this.fiOldpwd.TabIndex = 0;
            this.fiOldpwd.Title = "原密码";
            this.fiOldpwd.Value = "";
            // 
            // fiNewpwd
            // 
            this.fiNewpwd.BackColor = System.Drawing.Color.Transparent;
            this.fiNewpwd.Location = new System.Drawing.Point(300, 215);
            this.fiNewpwd.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.fiNewpwd.Name = "fiNewpwd";
            this.fiNewpwd.PwdCharacter = '*';
            this.fiNewpwd.Size = new System.Drawing.Size(500, 40);
            this.fiNewpwd.TabIndex = 1;
            this.fiNewpwd.Title = "新密码";
            this.fiNewpwd.Value = "";
            // 
            // fiSubmitpwd
            // 
            this.fiSubmitpwd.BackColor = System.Drawing.Color.Transparent;
            this.fiSubmitpwd.Location = new System.Drawing.Point(300, 280);
            this.fiSubmitpwd.Margin = new System.Windows.Forms.Padding(13, 16, 13, 16);
            this.fiSubmitpwd.Name = "fiSubmitpwd";
            this.fiSubmitpwd.PwdCharacter = '*';
            this.fiSubmitpwd.Size = new System.Drawing.Size(500, 40);
            this.fiSubmitpwd.TabIndex = 2;
            this.fiSubmitpwd.Title = "确认";
            this.fiSubmitpwd.Value = "";
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.Location = new System.Drawing.Point(512, 391);
            this.btnModify.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 35);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "修改";
            this.btnModify.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // ChangePasswordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiTitlePanel1);
            this.Name = "ChangePasswordControl";
            this.Size = new System.Drawing.Size(1064, 606);
            this.uiTitlePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private FiledInputControl fiSubmitpwd;
        private FiledInputControl fiNewpwd;
        private FiledInputControl fiOldpwd;
        private Sunny.UI.UIButton btnModify;
    }
}
