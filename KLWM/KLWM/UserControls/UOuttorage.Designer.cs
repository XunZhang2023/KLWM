using System.Drawing;

namespace KLWM.UserControls
{
    partial class UOuttorage
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
            this.dgvOutStorage = new System.Windows.Forms.DataGridView();
            this.PNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOutCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POutRecipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStorage)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1170, 106);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1176, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOutStorage, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 747);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvOutStorage
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvOutStorage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOutStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutStorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PNo,
            this.TType,
            this.PName,
            this.PManufacturer,
            this.PSize,
            this.PUnit,
            this.UOutCount,
            this.POutRecipient,
            this.UOutTime});
            this.dgvOutStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutStorage.Location = new System.Drawing.Point(3, 121);
            this.dgvOutStorage.Name = "dgvOutStorage";
            this.dgvOutStorage.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dgvOutStorage.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOutStorage.RowTemplate.Height = 27;
            this.dgvOutStorage.Size = new System.Drawing.Size(1176, 623);
            this.dgvOutStorage.TabIndex = 1;
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
            // TType
            // 
            this.TType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TType.DataPropertyName = "PType";
            this.TType.FillWeight = 20F;
            this.TType.HeaderText = "类别";
            this.TType.MinimumWidth = 6;
            this.TType.Name = "TType";
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
            this.PSize.FillWeight = 20F;
            this.PSize.HeaderText = "规格";
            this.PSize.MinimumWidth = 6;
            this.PSize.Name = "PSize";
            // 
            // PUnit
            // 
            this.PUnit.DataPropertyName = "PUnit";
            this.PUnit.HeaderText = "单位";
            this.PUnit.MinimumWidth = 6;
            this.PUnit.Name = "PUnit";
            this.PUnit.Width = 125;
            // 
            // UOutCount
            // 
            this.UOutCount.DataPropertyName = "POutCount";
            this.UOutCount.HeaderText = "数量";
            this.UOutCount.MinimumWidth = 6;
            this.UOutCount.Name = "UOutCount";
            this.UOutCount.Width = 125;
            // 
            // POutRecipient
            // 
            this.POutRecipient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POutRecipient.DataPropertyName = "POutRecipient";
            this.POutRecipient.FillWeight = 25F;
            this.POutRecipient.HeaderText = "领用人";
            this.POutRecipient.MinimumWidth = 6;
            this.POutRecipient.Name = "POutRecipient";
            // 
            // UOutTime
            // 
            this.UOutTime.DataPropertyName = "CTime";
            this.UOutTime.HeaderText = "时间";
            this.UOutTime.MinimumWidth = 6;
            this.UOutTime.Name = "UOutTime";
            this.UOutTime.Width = 125;
            // 
            // UOuttorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UOuttorage";
            this.Size = new System.Drawing.Size(1182, 747);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStorage)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvOutStorage;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn PNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOutCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn POutRecipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOutTime;
    }
}
