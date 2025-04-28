namespace KLWM.UserControls
{
    partial class UCameraInfo
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.cbxStation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvCameraHis = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPtoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutPhoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsOutbound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutboundInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraHis)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvCameraHis, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1628, 1014);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1622, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.cbxName);
            this.panel1.Controls.Add(this.cbxStation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1616, 106);
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
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(232, 18);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(121, 23);
            this.cbxName.TabIndex = 3;
            // 
            // cbxStation
            // 
            this.cbxStation.FormattingEnabled = true;
            this.cbxStation.Location = new System.Drawing.Point(54, 18);
            this.cbxStation.Name = "cbxStation";
            this.cbxStation.Size = new System.Drawing.Size(121, 23);
            this.cbxStation.TabIndex = 2;
            this.cbxStation.SelectedIndexChanged += new System.EventHandler(this.cbxStation_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "岗位:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(3, 21);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(45, 15);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "姓名:";
            // 
            // dgvCameraHis
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvCameraHis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCameraHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCameraHis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Uname,
            this.UId,
            this.UStation,
            this.InTime,
            this.OutTime,
            this.InPtoto,
            this.OutPhoto,
            this.IsOutbound,
            this.OutboundInfo});
            this.dgvCameraHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCameraHis.Location = new System.Drawing.Point(3, 121);
            this.dgvCameraHis.Name = "dgvCameraHis";
            this.dgvCameraHis.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dgvCameraHis.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCameraHis.RowTemplate.Height = 27;
            this.dgvCameraHis.Size = new System.Drawing.Size(1622, 890);
            this.dgvCameraHis.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 10F;
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            // 
            // Uname
            // 
            this.Uname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Uname.DataPropertyName = "Uname";
            this.Uname.FillWeight = 20F;
            this.Uname.HeaderText = "员工姓名";
            this.Uname.MinimumWidth = 6;
            this.Uname.Name = "Uname";
            // 
            // UId
            // 
            this.UId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UId.DataPropertyName = "UId";
            this.UId.FillWeight = 15F;
            this.UId.HeaderText = "员工ID";
            this.UId.MinimumWidth = 6;
            this.UId.Name = "UId";
            // 
            // UStation
            // 
            this.UStation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UStation.DataPropertyName = "UStation";
            this.UStation.FillWeight = 20F;
            this.UStation.HeaderText = "员工岗位";
            this.UStation.MinimumWidth = 6;
            this.UStation.Name = "UStation";
            // 
            // InTime
            // 
            this.InTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InTime.DataPropertyName = "InTime";
            this.InTime.FillWeight = 30F;
            this.InTime.HeaderText = "进入时间";
            this.InTime.MinimumWidth = 6;
            this.InTime.Name = "InTime";
            // 
            // OutTime
            // 
            this.OutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OutTime.DataPropertyName = "OutTime";
            this.OutTime.FillWeight = 30F;
            this.OutTime.HeaderText = "出去时间";
            this.OutTime.MinimumWidth = 6;
            this.OutTime.Name = "OutTime";
            // 
            // InPtoto
            // 
            this.InPtoto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InPtoto.DataPropertyName = "InPtoto";
            this.InPtoto.FillWeight = 30F;
            this.InPtoto.HeaderText = "进入图片";
            this.InPtoto.MinimumWidth = 6;
            this.InPtoto.Name = "InPtoto";
            // 
            // OutPhoto
            // 
            this.OutPhoto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OutPhoto.DataPropertyName = "OutPhoto";
            this.OutPhoto.FillWeight = 30F;
            this.OutPhoto.HeaderText = "出去图片";
            this.OutPhoto.MinimumWidth = 6;
            this.OutPhoto.Name = "OutPhoto";
            // 
            // IsOutbound
            // 
            this.IsOutbound.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsOutbound.DataPropertyName = "IsOutbound";
            this.IsOutbound.FillWeight = 10F;
            this.IsOutbound.HeaderText = "是否出库";
            this.IsOutbound.MinimumWidth = 6;
            this.IsOutbound.Name = "IsOutbound";
            // 
            // OutboundInfo
            // 
            this.OutboundInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OutboundInfo.DataPropertyName = "OutboundInfo";
            this.OutboundInfo.FillWeight = 40F;
            this.OutboundInfo.HeaderText = "出库内容";
            this.OutboundInfo.MinimumWidth = 6;
            this.OutboundInfo.Name = "OutboundInfo";
            // 
            // UCameraInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCameraInfo";
            this.Size = new System.Drawing.Size(1628, 1014);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraHis)).EndInit();
            this.ResumeLayout(false);
            dgvCameraHis.AutoGenerateColumns = false;

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.ComboBox cbxStation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridView dgvCameraHis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uname;
        private System.Windows.Forms.DataGridViewTextBoxColumn UId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn InTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPtoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutPhoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsOutbound;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutboundInfo;
    }
}
