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
            this.BasicData = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.WarehouseManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.StockControl = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ProductType = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ProductInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Storage = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.EXwarehouse = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.StoreInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.WMcheck = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.KanBan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.KanBanInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
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
            // BasicData
            // 
            this.BasicData.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ProductType,
            this.ProductInfo});
            this.BasicData.Expanded = true;
            this.BasicData.Name = "BasicData";
            this.BasicData.Text = "基础数据";
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
            // WarehouseManagement
            // 
            this.WarehouseManagement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Storage,
            this.EXwarehouse});
            this.WarehouseManagement.Expanded = true;
            this.WarehouseManagement.Name = "WarehouseManagement";
            this.WarehouseManagement.Text = "出入库管理";
            // 
            // StockControl
            // 
            this.StockControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.StoreInfo});
            this.StockControl.Expanded = true;
            this.StockControl.Name = "StockControl";
            this.StockControl.Text = "库存管理";
            // 
            // ProductType
            // 
            this.ProductType.Name = "ProductType";
            this.ProductType.Text = "产品类型";
            // 
            // ProductInfo
            // 
            this.ProductInfo.Name = "ProductInfo";
            this.ProductInfo.Text = "产品信息";
            // 
            // Storage
            // 
            this.Storage.Name = "Storage";
            this.Storage.Text = "入库";
            // 
            // EXwarehouse
            // 
            this.EXwarehouse.Name = "EXwarehouse";
            this.EXwarehouse.Text = "出库";
            // 
            // StoreInfo
            // 
            this.StoreInfo.Name = "StoreInfo";
            this.StoreInfo.Text = "库存信息";
            // 
            // WMcheck
            // 
            this.WMcheck.Expanded = true;
            this.WMcheck.Name = "WMcheck";
            this.WMcheck.Text = "盘点";
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
            this.KanBanInfo.Text = "看板";
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
            this.Text = "康龙备件库管理系统";
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
        private DevExpress.XtraBars.Navigation.AccordionControlElement ProductType;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ProductInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Storage;
        private DevExpress.XtraBars.Navigation.AccordionControlElement EXwarehouse;
        private DevExpress.XtraBars.Navigation.AccordionControlElement StoreInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement WMcheck;
        private DevExpress.XtraBars.Navigation.AccordionControlElement KanBanInfo;
    }
}

