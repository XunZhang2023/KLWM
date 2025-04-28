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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
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
            this.pbxReal = new System.Windows.Forms.PictureBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReal)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstore)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraHis)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.61555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.38445F));
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1438, 509);
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
            this.groupBox4.Controls.Add(this.pbxReal);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(941, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 503);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "人脸识别";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(302, 397);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(15, 15);
            this.lblStation.TabIndex = 4;
            this.lblStation.Text = " ";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(302, 339);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(15, 15);
            this.lblNo.TabIndex = 4;
            this.lblNo.Text = " ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(302, 286);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(15, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "岗位：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "工号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名：";
            // 
            // btnOutStore
            // 
            this.btnOutStore.Location = new System.Drawing.Point(342, 453);
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
            this.pbxPeople.Location = new System.Drawing.Point(6, 269);
            this.pbxPeople.Name = "pbxPeople";
            this.pbxPeople.Size = new System.Drawing.Size(212, 230);
            this.pbxPeople.TabIndex = 1;
            this.pbxPeople.TabStop = false;
            // 
            // btnInStore
            // 
            this.btnInStore.Location = new System.Drawing.Point(234, 453);
            this.btnInStore.Name = "btnInStore";
            this.btnInStore.Size = new System.Drawing.Size(97, 46);
            this.btnInStore.TabIndex = 0;
            this.btnInStore.Text = "入库";
            this.btnInStore.UseVisualStyleBackColor = true;
            this.btnInStore.Click += new System.EventHandler(this.btnInStore_Click);
            // 
            // pbxReal
            // 
            this.pbxReal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbxReal.Location = new System.Drawing.Point(6, 24);
            this.pbxReal.Name = "pbxReal";
            this.pbxReal.Size = new System.Drawing.Size(433, 239);
            this.pbxReal.TabIndex = 0;
            this.pbxReal.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvstore);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 503);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "今日变动监测";
            // 
            // dgvstore
            // 
            this.dgvstore.AllowUserToAddRows = false;
            this.dgvstore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            this.dgvstore.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvstore.RowTemplate.Height = 27;
            this.dgvstore.Size = new System.Drawing.Size(926, 479);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCameraHis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1438, 405);
            this.panel1.TabIndex = 1;
            // 
            // dgvCameraHis
            // 
            this.dgvCameraHis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCameraHis.RowsDefaultCellStyle = dataGridViewCellStyle4;
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
            this.dgvCameraHis.Location = new System.Drawing.Point(0, 0);
            this.dgvCameraHis.Name = "dgvCameraHis";
            this.dgvCameraHis.RowHeadersWidth = 51;
            this.dgvCameraHis.RowTemplate.Height = 27;
            this.dgvCameraHis.Size = new System.Drawing.Size(1438, 405);
            this.dgvCameraHis.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxReal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstore)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraHis)).EndInit();
            this.ResumeLayout(false);
            this.dgvstore.AutoGenerateColumns = false;
            this.dgvCameraHis.AutoGenerateColumns = false;

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOutStore;
        private System.Windows.Forms.Button btnInStore;
        private System.Windows.Forms.DataGridView dgvstore;
        private System.Windows.Forms.PictureBox pbxPeople;
        private System.Windows.Forms.PictureBox pbxReal;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label label3;
        private DataGridViewTextBoxColumn PNo;
        private DataGridViewTextBoxColumn PType;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn PManufacturer;
        private DataGridViewTextBoxColumn PSize;
        private DataGridViewTextBoxColumn PUnit;
        private DataGridViewTextBoxColumn PCount;
        private DataGridViewTextBoxColumn CTime;
        private Panel panel1;
        private DataGridView dgvCameraHis;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Uname;
        private DataGridViewTextBoxColumn UId;
        private DataGridViewTextBoxColumn UStation;
        private DataGridViewTextBoxColumn InTime;
        private DataGridViewTextBoxColumn OutTime;
        private DataGridViewTextBoxColumn InPtoto;
        private DataGridViewTextBoxColumn OutPhoto;
        private DataGridViewTextBoxColumn IsOutbound;
        private DataGridViewTextBoxColumn OutboundInfo;
    }
}
