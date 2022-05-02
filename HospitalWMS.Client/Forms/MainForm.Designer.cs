
namespace HospitalWMS.Client.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.userInfoControl1 = new HospitalWMS.Client.Controls.UserInfoControl();
            this.uiContent = new Sunny.UI.UIPanel();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiLabel1);
            this.uiPanel1.Controls.Add(this.userInfoControl1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1264, 75);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.uiLabel1.Size = new System.Drawing.Size(976, 75);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "医院物资管理系统";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // userInfoControl1
            // 
            this.userInfoControl1.BackColor = System.Drawing.Color.Transparent;
            this.userInfoControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.userInfoControl1.Location = new System.Drawing.Point(976, 0);
            this.userInfoControl1.Margin = new System.Windows.Forms.Padding(13, 16, 13, 16);
            this.userInfoControl1.Name = "userInfoControl1";
            this.userInfoControl1.Size = new System.Drawing.Size(288, 75);
            this.userInfoControl1.TabIndex = 0;
            // 
            // uiContent
            // 
            this.uiContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContent.Location = new System.Drawing.Point(0, 75);
            this.uiContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiContent.Name = "uiContent";
            this.uiContent.Size = new System.Drawing.Size(1264, 606);
            this.uiContent.TabIndex = 1;
            this.uiContent.Text = null;
            this.uiContent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiContent.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.uiContent);
            this.Controls.Add(this.uiPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.Text = "医院物资管理系统";
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Controls.UserInfoControl userInfoControl1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiContent;
    }
}