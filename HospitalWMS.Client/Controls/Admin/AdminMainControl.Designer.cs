
namespace HospitalWMS.Client.Controls.Admin
{
    partial class AdminMainControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("管理用户");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("用户管理", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("管理部门");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("部门管理", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("管理仓库");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("仓库管理", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("管理供应商");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("供应商管理", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("管理物资");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("物资管理", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiTreeView1 = new Sunny.UI.UITreeView();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(150, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1114, 606);
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTreeView1
            // 
            this.uiTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiTreeView1.FillColor = System.Drawing.Color.AliceBlue;
            this.uiTreeView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTreeView1.ForeColor = System.Drawing.Color.Black;
            this.uiTreeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiTreeView1.Location = new System.Drawing.Point(0, 0);
            this.uiTreeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeView1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTreeView1.Name = "uiTreeView1";
            treeNode1.Name = "节点5";
            treeNode1.Text = "管理用户";
            treeNode2.Name = "节点0";
            treeNode2.Text = "用户管理";
            treeNode3.Name = "节点6";
            treeNode3.Text = "管理部门";
            treeNode4.Name = "节点1";
            treeNode4.Text = "部门管理";
            treeNode5.Name = "节点7";
            treeNode5.Text = "管理仓库";
            treeNode6.Name = "节点2";
            treeNode6.Text = "仓库管理";
            treeNode7.Name = "节点8";
            treeNode7.Text = "管理供应商";
            treeNode8.Name = "节点3";
            treeNode8.Text = "供应商管理";
            treeNode9.Name = "节点9";
            treeNode9.Text = "管理物资";
            treeNode10.Name = "节点4";
            treeNode10.Text = "物资管理";
            this.uiTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8,
            treeNode10});
            this.uiTreeView1.RectColor = System.Drawing.Color.AliceBlue;
            this.uiTreeView1.ShowPlusMinus = false;
            this.uiTreeView1.ShowText = false;
            this.uiTreeView1.Size = new System.Drawing.Size(150, 606);
            this.uiTreeView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeView1.TabIndex = 0;
            this.uiTreeView1.Text = "uiTreeView1";
            this.uiTreeView1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTreeView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiTreeView1_NodeMouseClick);
            // 
            // AdminMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiTreeView1);
            this.Name = "AdminMainControl";
            this.Size = new System.Drawing.Size(1264, 606);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITreeView uiTreeView1;
    }
}
