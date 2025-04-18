using System.Drawing;
using System.Windows.Forms;

namespace KLWM.UserFroms
{
    partial class Kanban
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOutStore = new System.Windows.Forms.Button();
            this.pbxPeople = new System.Windows.Forms.PictureBox();
            this.btnInStore = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvstore = new System.Windows.Forms.DataGridView();
            this.PNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvoutstore = new System.Windows.Forms.DataGridView();
            this.POutNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutRecipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvinstore = new System.Windows.Forms.DataGridView();
            this.PInNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PInType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PInName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PInManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstore)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvoutstore)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvinstore)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1444, 926);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1438, 549);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblStation);
            this.groupBox4.Controls.Add(this.lblNo);
            this.groupBox4.Controls.Add(this.lblName);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnOutStore);
            this.groupBox4.Controls.Add(this.pbxPeople);
            this.groupBox4.Controls.Add(this.btnInStore);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(941, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 543);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "人脸识别";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(301, 435);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(15, 15);
            this.lblStation.TabIndex = 4;
            this.lblStation.Text = " ";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(301, 397);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(15, 15);
            this.lblNo.TabIndex = 4;
            this.lblNo.Text = " ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(301, 354);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(15, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "岗位：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "工号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名：";
            // 
            // btnOutStore
            // 
            this.btnOutStore.Location = new System.Drawing.Point(323, 488);
            this.btnOutStore.Name = "btnOutStore";
            this.btnOutStore.Size = new System.Drawing.Size(97, 46);
            this.btnOutStore.TabIndex = 1;
            this.btnOutStore.Text = "出库";
            this.btnOutStore.UseVisualStyleBackColor = true;
            this.btnOutStore.Click += new System.EventHandler(this.btnOutStore_Click);
            // 
            // pbxPeople
            // 
            this.pbxPeople.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbxPeople.Location = new System.Drawing.Point(6, 354);
            this.pbxPeople.Name = "pbxPeople";
            this.pbxPeople.Size = new System.Drawing.Size(193, 180);
            this.pbxPeople.TabIndex = 1;
            this.pbxPeople.TabStop = false;
            // 
            // btnInStore
            // 
            this.btnInStore.Location = new System.Drawing.Point(214, 488);
            this.btnInStore.Name = "btnInStore";
            this.btnInStore.Size = new System.Drawing.Size(97, 46);
            this.btnInStore.TabIndex = 0;
            this.btnInStore.Text = "入库";
            this.btnInStore.UseVisualStyleBackColor = true;
            this.btnInStore.Click += new System.EventHandler(this.btnInStore_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(6, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 297);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvstore);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 543);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "今日变动监测";
            // 
            // dgvstore
            // 
            this.dgvstore.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvstore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvstore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PNo,
            this.PType,
            this.PName,
            this.PManufacturer,
            this.PSize,
            this.PUnit,
            this.PCount,
            this.CTime});
            this.dgvstore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvstore.Location = new System.Drawing.Point(3, 21);
            this.dgvstore.Name = "dgvstore";
            this.dgvstore.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dgvstore.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvstore.RowTemplate.Height = 27;
            this.dgvstore.Size = new System.Drawing.Size(926, 519);
            this.dgvstore.TabIndex = 0;
            this.dgvstore.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvstore_CellFormatting);
            // 
            // PNo
            // 
            this.PNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PNo.DataPropertyName = "PNo";
            this.PNo.FillWeight = 20F;
            this.PNo.HeaderText = "编号";
            this.PNo.MinimumWidth = 6;
            this.PNo.Name = "PNo";
            // 
            // PType
            // 
            this.PType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PType.DataPropertyName = "PType";
            this.PType.FillWeight = 20F;
            this.PType.HeaderText = "类型";
            this.PType.MinimumWidth = 6;
            this.PType.Name = "PType";
            // 
            // PName
            // 
            this.PName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PName.DataPropertyName = "PName";
            this.PName.FillWeight = 20F;
            this.PName.HeaderText = "名称";
            this.PName.MinimumWidth = 6;
            this.PName.Name = "PName";
            // 
            // PManufacturer
            // 
            this.PManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PManufacturer.DataPropertyName = "PManufacturer";
            this.PManufacturer.FillWeight = 20F;
            this.PManufacturer.HeaderText = "厂商";
            this.PManufacturer.MinimumWidth = 6;
            this.PManufacturer.Name = "PManufacturer";
            // 
            // PSize
            // 
            this.PSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PSize.DataPropertyName = "PSize";
            this.PSize.FillWeight = 15F;
            this.PSize.HeaderText = "规格";
            this.PSize.MinimumWidth = 6;
            this.PSize.Name = "PSize";
            // 
            // PUnit
            // 
            this.PUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PUnit.DataPropertyName = "PUnit";
            this.PUnit.FillWeight = 10F;
            this.PUnit.HeaderText = "单位";
            this.PUnit.MinimumWidth = 6;
            this.PUnit.Name = "PUnit";
            // 
            // PCount
            // 
            this.PCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PCount.DataPropertyName = "PCount";
            this.PCount.FillWeight = 20F;
            this.PCount.HeaderText = "数量";
            this.PCount.MinimumWidth = 6;
            this.PCount.Name = "PCount";
            // 
            // CTime
            // 
            this.CTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CTime.DataPropertyName = "CTime";
            this.CTime.FillWeight = 25F;
            this.CTime.HeaderText = "创建时间";
            this.CTime.MinimumWidth = 6;
            this.CTime.Name = "CTime";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 558);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1438, 365);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvoutstore);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(722, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(713, 359);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "今日出库记录";
            // 
            // dgvoutstore
            // 
            this.dgvoutstore.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            this.dgvoutstore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvoutstore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvoutstore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POutNo,
            this.POutType,
            this.POutName,
            this.POutManufacturer,
            this.POutCount,
            this.POutRecipient,
            this.POutTime});
            this.dgvoutstore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvoutstore.Location = new System.Drawing.Point(3, 21);
            this.dgvoutstore.Name = "dgvoutstore";
            this.dgvoutstore.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvoutstore.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvoutstore.RowTemplate.Height = 27;
            this.dgvoutstore.Size = new System.Drawing.Size(707, 335);
            this.dgvoutstore.TabIndex = 2;
            // 
            // POutNo
            // 
            this.POutNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutNo.DataPropertyName = "PNo";
            this.POutNo.FillWeight = 20F;
            this.POutNo.HeaderText = "编号";
            this.POutNo.MinimumWidth = 6;
            this.POutNo.Name = "POutNo";
            // 
            // POutType
            // 
            this.POutType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutType.DataPropertyName = "PType";
            this.POutType.FillWeight = 20F;
            this.POutType.HeaderText = "产品类型";
            this.POutType.MinimumWidth = 6;
            this.POutType.Name = "POutType";
            // 
            // POutName
            // 
            this.POutName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutName.DataPropertyName = "PName";
            this.POutName.FillWeight = 20F;
            this.POutName.HeaderText = "产品名称";
            this.POutName.MinimumWidth = 6;
            this.POutName.Name = "POutName";
            // 
            // POutManufacturer
            // 
            this.POutManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutManufacturer.DataPropertyName = "PManufacturer";
            this.POutManufacturer.FillWeight = 20F;
            this.POutManufacturer.HeaderText = "厂商";
            this.POutManufacturer.MinimumWidth = 6;
            this.POutManufacturer.Name = "POutManufacturer";
            // 
            // POutCount
            // 
            this.POutCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutCount.DataPropertyName = "POutCount";
            this.POutCount.FillWeight = 25F;
            this.POutCount.HeaderText = "出库量";
            this.POutCount.MinimumWidth = 6;
            this.POutCount.Name = "POutCount";
            // 
            // POutRecipient
            // 
            this.POutRecipient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutRecipient.DataPropertyName = "POutRecipient";
            this.POutRecipient.FillWeight = 20F;
            this.POutRecipient.HeaderText = "领用人";
            this.POutRecipient.MinimumWidth = 6;
            this.POutRecipient.Name = "POutRecipient";
            // 
            // POutTime
            // 
            this.POutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutTime.DataPropertyName = "CTime";
            this.POutTime.FillWeight = 30F;
            this.POutTime.HeaderText = "时间";
            this.POutTime.MinimumWidth = 6;
            this.POutTime.Name = "POutTime";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvinstore);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(713, 359);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "今日入库记录";
            // 
            // dgvinstore
            // 
            this.dgvinstore.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            this.dgvinstore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvinstore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvinstore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PInNo,
            this.PInType,
            this.PInName,
            this.PInManufacturer,
            this.InCount,
            this.CInTime});
            this.dgvinstore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvinstore.Location = new System.Drawing.Point(3, 21);
            this.dgvinstore.Name = "dgvinstore";
            this.dgvinstore.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Bisque;
            this.dgvinstore.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvinstore.RowTemplate.Height = 27;
            this.dgvinstore.Size = new System.Drawing.Size(707, 335);
            this.dgvinstore.TabIndex = 1;
            // 
            // PInNo
            // 
            this.PInNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PInNo.DataPropertyName = "PNo";
            this.PInNo.FillWeight = 20F;
            this.PInNo.HeaderText = "编号";
            this.PInNo.MinimumWidth = 6;
            this.PInNo.Name = "PInNo";
            // 
            // PInType
            // 
            this.PInType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PInType.DataPropertyName = "PType";
            this.PInType.FillWeight = 20F;
            this.PInType.HeaderText = "产品类型";
            this.PInType.MinimumWidth = 6;
            this.PInType.Name = "PInType";
            // 
            // PInName
            // 
            this.PInName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PInName.DataPropertyName = "PName";
            this.PInName.FillWeight = 20F;
            this.PInName.HeaderText = "产品名称";
            this.PInName.MinimumWidth = 6;
            this.PInName.Name = "PInName";
            // 
            // PInManufacturer
            // 
            this.PInManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PInManufacturer.DataPropertyName = "PManufacturer";
            this.PInManufacturer.FillWeight = 20F;
            this.PInManufacturer.HeaderText = "厂商";
            this.PInManufacturer.MinimumWidth = 6;
            this.PInManufacturer.Name = "PInManufacturer";
            // 
            // InCount
            // 
            this.InCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InCount.DataPropertyName = "InCount";
            this.InCount.FillWeight = 25F;
            this.InCount.HeaderText = "入库量";
            this.InCount.MinimumWidth = 6;
            this.InCount.Name = "InCount";
            // 
            // CInTime
            // 
            this.CInTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CInTime.DataPropertyName = "CTime";
            this.CInTime.FillWeight = 30F;
            this.CInTime.HeaderText = "时间";
            this.CInTime.MinimumWidth = 6;
            this.CInTime.Name = "CInTime";
            // 
            // Kanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Kanban";
            this.Size = new System.Drawing.Size(1444, 926);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstore)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvoutstore)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvinstore)).EndInit();
            this.ResumeLayout(false);


            this.dgvinstore.AutoGenerateColumns = false;
            this.dgvoutstore.AutoGenerateColumns = false;
            this.dgvstore.AutoGenerateColumns = false;

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOutStore;
        private System.Windows.Forms.Button btnInStore;
        private System.Windows.Forms.DataGridView dgvstore;
        private System.Windows.Forms.DataGridView dgvinstore;
        private System.Windows.Forms.PictureBox pbxPeople;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvoutstore;
        private DataGridViewTextBoxColumn POutNo;
        private DataGridViewTextBoxColumn POutType;
        private DataGridViewTextBoxColumn POutName;
        private DataGridViewTextBoxColumn POutManufacturer;
        private DataGridViewTextBoxColumn POutCount;
        private DataGridViewTextBoxColumn POutRecipient;
        private DataGridViewTextBoxColumn POutTime;
        private DataGridViewTextBoxColumn PInNo;
        private DataGridViewTextBoxColumn PInType;
        private DataGridViewTextBoxColumn PInName;
        private DataGridViewTextBoxColumn PInManufacturer;
        private DataGridViewTextBoxColumn InCount;
        private DataGridViewTextBoxColumn CInTime;
        private DataGridViewTextBoxColumn PNo;
        private DataGridViewTextBoxColumn PType;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn PManufacturer;
        private DataGridViewTextBoxColumn PSize;
        private DataGridViewTextBoxColumn PUnit;
        private DataGridViewTextBoxColumn PCount;
        private DataGridViewTextBoxColumn CTime;
    }
}
