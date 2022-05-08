
namespace HospitalWMS.Client.Controls.Manager.Goods
{
    partial class GoodsManagerControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.dgvGoods = new Sunny.UI.UIDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbSupplier = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbGoodsType = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiFlowLayoutPanel1 = new Sunny.UI.UIFlowLayoutPanel();
            this.btnDelete = new Sunny.UI.UIButton();
            this.btnUpdate = new Sunny.UI.UIButton();
            this.btnAdd = new Sunny.UI.UIButton();
            this.fiName = new HospitalWMS.Client.Controls.FiledInputControl();
            this.fiUnit = new HospitalWMS.Client.Controls.FiledInputControl();
            this.fiPrice = new HospitalWMS.Client.Controls.FiledInputControl();
            this.fiSpecification = new HospitalWMS.Client.Controls.FiledInputControl();
            this.fiGoodsNum = new HospitalWMS.Client.Controls.FiledInputControl();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.uiFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiTableLayoutPanel1);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(1064, 606);
            this.uiTitlePanel1.TabIndex = 3;
            this.uiTitlePanel1.Text = "物资管理";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.uiTableLayoutPanel1.ColumnCount = 3;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.Controls.Add(this.fiGoodsNum, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.dgvGoods, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiFlowLayoutPanel1, 2, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.fiName, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.fiUnit, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.fiPrice, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.fiSpecification, 1, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTableLayoutPanel1.RowCount = 4;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1064, 571);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // dgvGoods
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvGoods.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGoods.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvGoods.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiTableLayoutPanel1.SetColumnSpan(this.dgvGoods, 3);
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoods.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoods.EnableHeadersVisualStyles = false;
            this.dgvGoods.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvGoods.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvGoods.Location = new System.Drawing.Point(8, 176);
            this.dgvGoods.Name = "dgvGoods";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoods.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvGoods.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvGoods.RowTemplate.Height = 23;
            this.dgvGoods.SelectedIndex = -1;
            this.dgvGoods.Size = new System.Drawing.Size(1048, 387);
            this.dgvGoods.TabIndex = 14;
            this.dgvGoods.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbSupplier);
            this.panel3.Controls.Add(this.uiLabel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(710, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 50);
            this.panel3.TabIndex = 13;
            // 
            // cbSupplier
            // 
            this.cbSupplier.DataSource = null;
            this.cbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSupplier.FillColor = System.Drawing.Color.White;
            this.cbSupplier.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSupplier.Location = new System.Drawing.Point(116, 0);
            this.cbSupplier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSupplier.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbSupplier.Size = new System.Drawing.Size(230, 50);
            this.cbSupplier.TabIndex = 3;
            this.cbSupplier.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSupplier.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(0, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(116, 50);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "供应商";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Lable_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbGoodsType);
            this.panel2.Controls.Add(this.uiLabel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(710, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 50);
            this.panel2.TabIndex = 12;
            // 
            // cbGoodsType
            // 
            this.cbGoodsType.DataSource = null;
            this.cbGoodsType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGoodsType.FillColor = System.Drawing.Color.White;
            this.cbGoodsType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbGoodsType.Location = new System.Drawing.Point(116, 0);
            this.cbGoodsType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGoodsType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbGoodsType.Name = "cbGoodsType";
            this.cbGoodsType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbGoodsType.Size = new System.Drawing.Size(230, 50);
            this.cbGoodsType.TabIndex = 2;
            this.cbGoodsType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbGoodsType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(0, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(116, 50);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "物资类型";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Lable_Paint);
            // 
            // uiFlowLayoutPanel1
            // 
            this.uiFlowLayoutPanel1.Controls.Add(this.btnDelete);
            this.uiFlowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.uiFlowLayoutPanel1.Controls.Add(this.btnAdd);
            this.uiFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.uiFlowLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiFlowLayoutPanel1.Location = new System.Drawing.Point(711, 122);
            this.uiFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiFlowLayoutPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiFlowLayoutPanel1.Name = "uiFlowLayoutPanel1";
            this.uiFlowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.uiFlowLayoutPanel1.Radius = 1;
            this.uiFlowLayoutPanel1.ShowText = false;
            this.uiFlowLayoutPanel1.Size = new System.Drawing.Size(344, 46);
            this.uiFlowLayoutPanel1.TabIndex = 7;
            this.uiFlowLayoutPanel1.Text = "uiFlowLayoutPanel1";
            this.uiFlowLayoutPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiFlowLayoutPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(137, 11);
            this.btnDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(71, 11);
            this.btnUpdate.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 30);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(5, 10);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // fiName
            // 
            this.fiName.BackColor = System.Drawing.Color.Transparent;
            this.fiName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiName.Location = new System.Drawing.Point(10, 10);
            this.fiName.Margin = new System.Windows.Forms.Padding(5);
            this.fiName.Name = "fiName";
            this.fiName.PwdCharacter = '\0';
            this.fiName.Size = new System.Drawing.Size(341, 46);
            this.fiName.TabIndex = 8;
            this.fiName.Title = "商品名称";
            this.fiName.Value = "";
            // 
            // fiUnit
            // 
            this.fiUnit.BackColor = System.Drawing.Color.Transparent;
            this.fiUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiUnit.Location = new System.Drawing.Point(10, 66);
            this.fiUnit.Margin = new System.Windows.Forms.Padding(5);
            this.fiUnit.Name = "fiUnit";
            this.fiUnit.PwdCharacter = '\0';
            this.fiUnit.Size = new System.Drawing.Size(341, 46);
            this.fiUnit.TabIndex = 9;
            this.fiUnit.Title = "单位";
            this.fiUnit.Value = "";
            // 
            // fiPrice
            // 
            this.fiPrice.BackColor = System.Drawing.Color.Transparent;
            this.fiPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiPrice.Location = new System.Drawing.Point(361, 66);
            this.fiPrice.Margin = new System.Windows.Forms.Padding(5);
            this.fiPrice.Name = "fiPrice";
            this.fiPrice.PwdCharacter = '\0';
            this.fiPrice.Size = new System.Drawing.Size(341, 46);
            this.fiPrice.TabIndex = 10;
            this.fiPrice.Title = "价格";
            this.fiPrice.Value = "";
            // 
            // fiSpecification
            // 
            this.fiSpecification.BackColor = System.Drawing.Color.Transparent;
            this.fiSpecification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiSpecification.Location = new System.Drawing.Point(361, 10);
            this.fiSpecification.Margin = new System.Windows.Forms.Padding(5);
            this.fiSpecification.Name = "fiSpecification";
            this.fiSpecification.PwdCharacter = '\0';
            this.fiSpecification.Size = new System.Drawing.Size(341, 46);
            this.fiSpecification.TabIndex = 15;
            this.fiSpecification.Title = "规格型号";
            this.fiSpecification.Value = "";
            // 
            // fiGoodsNum
            // 
            this.fiGoodsNum.BackColor = System.Drawing.Color.Transparent;
            this.fiGoodsNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiGoodsNum.Location = new System.Drawing.Point(10, 122);
            this.fiGoodsNum.Margin = new System.Windows.Forms.Padding(5);
            this.fiGoodsNum.Name = "fiGoodsNum";
            this.fiGoodsNum.PwdCharacter = '\0';
            this.fiGoodsNum.Size = new System.Drawing.Size(341, 46);
            this.fiGoodsNum.TabIndex = 16;
            this.fiGoodsNum.Title = "商品编号";
            this.fiGoodsNum.Value = "";
            // 
            // GoodsManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiTitlePanel1);
            this.Name = "GoodsManagerControl";
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.uiFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIFlowLayoutPanel uiFlowLayoutPanel1;
        private Sunny.UI.UIButton btnDelete;
        private Sunny.UI.UIButton btnUpdate;
        private Sunny.UI.UIButton btnAdd;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private FiledInputControl fiName;
        private FiledInputControl fiUnit;
        private FiledInputControl fiPrice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox cbGoodsType;
        private Sunny.UI.UIComboBox cbSupplier;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIDataGridView dgvGoods;
        private FiledInputControl fiSpecification;
        private FiledInputControl fiGoodsNum;
    }
}
