using System.Drawing;

namespace KLWM.UserControls
{
    partial class UInStorage
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
            this.btnSel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.cbxPManufacturer = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInStorage = new System.Windows.Forms.DataGridView();
            this.UInNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(6, 59);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(83, 33);
            this.btnSel.TabIndex = 54;
            this.btnSel.Text = "查询";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(604, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "结束时间:";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "yyyy-MM-dd";
            this.dateTo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(709, 11);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(134, 34);
            this.dateTo.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(359, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "开始时间:";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "yyyy-MM-dd";
            this.dateFrom.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(464, 11);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(134, 34);
            this.dateFrom.TabIndex = 50;
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(54, 18);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(121, 23);
            this.cbxType.TabIndex = 2;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "厂商:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(3, 21);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(45, 15);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "类型:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.cbxPManufacturer);
            this.panel1.Controls.Add(this.cbxType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 106);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(95, 59);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(83, 33);
            this.btnExport.TabIndex = 57;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbxPManufacturer
            // 
            this.cbxPManufacturer.FormattingEnabled = true;
            this.cbxPManufacturer.Location = new System.Drawing.Point(232, 18);
            this.cbxPManufacturer.Name = "cbxPManufacturer";
            this.cbxPManufacturer.Size = new System.Drawing.Size(121, 23);
            this.cbxPManufacturer.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.63284F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1360, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvInStorage, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1366, 703);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvInStorage
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvInStorage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInStorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UInNo,
            this.UInType,
            this.UInName,
            this.UInManufacturer,
            this.UInSize,
            this.UInUnit,
            this.UInCount,
            this.UInTime});
            this.dgvInStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInStorage.Location = new System.Drawing.Point(3, 121);
            this.dgvInStorage.Name = "dgvInStorage";
            this.dgvInStorage.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dgvInStorage.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInStorage.RowTemplate.Height = 27;
            this.dgvInStorage.Size = new System.Drawing.Size(1360, 579);
            this.dgvInStorage.TabIndex = 1;
            // 
            // UInNo
            // 
            this.UInNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UInNo.DataPropertyName = "PNo";
            this.UInNo.FillWeight = 20F;
            this.UInNo.HeaderText = "编号";
            this.UInNo.MinimumWidth = 6;
            this.UInNo.Name = "UInNo";
            // 
            // UInType
            // 
            this.UInType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UInType.DataPropertyName = "PType";
            this.UInType.FillWeight = 20F;
            this.UInType.HeaderText = "类别";
            this.UInType.MinimumWidth = 6;
            this.UInType.Name = "UInType";
            // 
            // UInName
            // 
            this.UInName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UInName.DataPropertyName = "PName";
            this.UInName.FillWeight = 20F;
            this.UInName.HeaderText = "名称";
            this.UInName.MinimumWidth = 6;
            this.UInName.Name = "UInName";
            // 
            // UInManufacturer
            // 
            this.UInManufacturer.DataPropertyName = "PManufacturer";
            this.UInManufacturer.HeaderText = "厂商";
            this.UInManufacturer.MinimumWidth = 6;
            this.UInManufacturer.Name = "UInManufacturer";
            this.UInManufacturer.Width = 125;
            // 
            // UInSize
            // 
            this.UInSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UInSize.DataPropertyName = "PSize";
            this.UInSize.FillWeight = 20F;
            this.UInSize.HeaderText = "规格";
            this.UInSize.MinimumWidth = 6;
            this.UInSize.Name = "UInSize";
            // 
            // UInUnit
            // 
            this.UInUnit.DataPropertyName = "PUnit";
            this.UInUnit.HeaderText = "单位";
            this.UInUnit.MinimumWidth = 6;
            this.UInUnit.Name = "UInUnit";
            this.UInUnit.Width = 125;
            // 
            // UInCount
            // 
            this.UInCount.DataPropertyName = "InCount";
            this.UInCount.HeaderText = "数量";
            this.UInCount.MinimumWidth = 6;
            this.UInCount.Name = "UInCount";
            this.UInCount.Width = 125;
            // 
            // UInTime
            // 
            this.UInTime.DataPropertyName = "CTime";
            this.UInTime.HeaderText = "创建时间";
            this.UInTime.MinimumWidth = 6;
            this.UInTime.Name = "UInTime";
            this.UInTime.Width = 125;
            // 
            // UInStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UInStorage";
            this.Size = new System.Drawing.Size(1366, 703);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxPManufacturer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvInStorage;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UInTime;
    }
}
