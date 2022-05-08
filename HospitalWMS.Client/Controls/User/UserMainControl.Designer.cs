
namespace HospitalWMS.Client.Controls.User
{
    partial class UserMainControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("申领物资");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("申领查询");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("物资申领", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("退库查询");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("物资退库", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("申购物资");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("申购查询");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("物资申购", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("修改个人信息");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("个人信息", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiTreeView1 = new Sunny.UI.UITreeView();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(129, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1135, 606);
            this.uiPanel1.TabIndex = 5;
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
            treeNode1.Name = "节点3";
            treeNode1.Text = "申领物资";
            treeNode2.Name = "节点4";
            treeNode2.Text = "申领查询";
            treeNode3.Name = "节点0";
            treeNode3.Text = "物资申领";
            treeNode4.Name = "节点6";
            treeNode4.Text = "退库查询";
            treeNode5.Name = "节点1";
            treeNode5.Text = "物资退库";
            treeNode6.Name = "节点7";
            treeNode6.Text = "申购物资";
            treeNode7.Name = "节点8";
            treeNode7.Text = "申购查询";
            treeNode8.Name = "节点2";
            treeNode8.Text = "物资申购";
            treeNode9.Name = "节点1";
            treeNode9.Text = "修改个人信息";
            treeNode10.Name = "节点0";
            treeNode10.Text = "个人信息";
            this.uiTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode8,
            treeNode10});
            this.uiTreeView1.ShowPlusMinus = false;
            this.uiTreeView1.ShowText = false;
            this.uiTreeView1.Size = new System.Drawing.Size(129, 606);
            this.uiTreeView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeView1.TabIndex = 6;
            this.uiTreeView1.Text = "uiTreeView1";
            this.uiTreeView1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTreeView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiTreeView1_NodeMouseClick);
            // 
            // UserMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiTreeView1);
            this.Name = "UserMainControl";
            this.Size = new System.Drawing.Size(1264, 606);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITreeView uiTreeView1;
    }
}
