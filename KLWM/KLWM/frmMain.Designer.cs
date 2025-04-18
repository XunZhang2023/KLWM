namespace KLWM
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.KanBan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.KanBanInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BasicData = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ProductInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.PeopleManager = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.WarehouseManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Storage = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.EXwarehouse = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.StockControl = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.StoreInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.WMcheck = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 39);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(584, 653);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.KanBan,
            this.BasicData,
            this.WarehouseManagement,
            this.StockControl,
            this.WMcheck});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 653);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // KanBan
            // 
            this.KanBan.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.KanBanInfo});
            this.KanBan.Expanded = true;
            this.KanBan.Name = "KanBan";
            this.KanBan.Text = "看板信息";
            // 
            // KanBanInfo
            // 
            this.KanBanInfo.Name = "KanBanInfo";
            this.KanBanInfo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.KanBanInfo.Tag = "看板";
            this.KanBanInfo.Text = "看板";
            this.KanBanInfo.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // BasicData
            // 
            this.BasicData.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ProductInfo,
            this.PeopleManager});
            this.BasicData.Expanded = true;
            this.BasicData.Name = "BasicData";
            this.BasicData.Text = "基础数据";
            // 
            // ProductInfo
            // 
            this.ProductInfo.Name = "ProductInfo";
            this.ProductInfo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ProductInfo.Tag = "产品信息";
            this.ProductInfo.Text = "产品信息";
            this.ProductInfo.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // PeopleManager
            // 
            this.PeopleManager.Name = "PeopleManager";
            this.PeopleManager.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.PeopleManager.Tag = "人员管理";
            this.PeopleManager.Text = "人员管理";
            this.PeopleManager.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // WarehouseManagement
            // 
            this.WarehouseManagement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Storage,
            this.EXwarehouse});
            this.WarehouseManagement.Expanded = true;
            this.WarehouseManagement.Name = "WarehouseManagement";
            this.WarehouseManagement.Text = "出入库管理";
            // 
            // Storage
            // 
            this.Storage.Name = "Storage";
            this.Storage.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Storage.Tag = "入库";
            this.Storage.Text = "入库";
            this.Storage.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // EXwarehouse
            // 
            this.EXwarehouse.Name = "EXwarehouse";
            this.EXwarehouse.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.EXwarehouse.Tag = "出库";
            this.EXwarehouse.Text = "出库";
            this.EXwarehouse.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // StockControl
            // 
            this.StockControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.StoreInfo});
            this.StockControl.Expanded = true;
            this.StockControl.Name = "StockControl";
            this.StockControl.Text = "库存管理";
            // 
            // StoreInfo
            // 
            this.StoreInfo.Name = "StoreInfo";
            this.StoreInfo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.StoreInfo.Tag = "库存";
            this.StoreInfo.Text = "库存";
            this.StoreInfo.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // WMcheck
            // 
            this.WMcheck.Expanded = true;
            this.WMcheck.Name = "WMcheck";
            this.WMcheck.Text = "盘点";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(844, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 692);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "康龙备件库管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BasicData;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement WarehouseManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement StockControl;
        private DevExpress.XtraBars.Navigation.AccordionControlElement KanBan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ProductInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Storage;
        private DevExpress.XtraBars.Navigation.AccordionControlElement EXwarehouse;
        private DevExpress.XtraBars.Navigation.AccordionControlElement StoreInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement WMcheck;
        private DevExpress.XtraBars.Navigation.AccordionControlElement KanBanInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement PeopleManager;
    }
}

