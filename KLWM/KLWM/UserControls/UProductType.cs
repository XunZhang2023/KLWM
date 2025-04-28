using DevExpress.Utils.About;
using KLWM.Auxiliary;
using KLWM.UserFroms;
using Org.BouncyCastle.Utilities.Collections;
using ProcessControlSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainLoadingRefactor.DataCore.DataModel;
using WinSDKDemo_CPCL;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace KLWM.UserControls
{
    public partial class UProductType : UserControl
    {
        List<WProductInfo> wProductInfos = new List<WProductInfo>();

        int _enlarge = Convert.ToInt32(ConfigurationManager.AppSettings["Enlarge"]);
        string _companyName = ConfigurationManager.AppSettings["CompanyName"];
        int _xPos = Convert.ToInt32(ConfigurationManager.AppSettings["XPos"]);
        int _yPos = Convert.ToInt32(ConfigurationManager.AppSettings["YPos"]);


        IntPtr printer;
        int openStatus = 100;
        bool isOpen = false;
        public UProductType()
        {
            InitializeComponent();
            InitData();
            dgvProductType.AutoGenerateColumns = false;
            printer = CPCLPrint.InitPrinter("");
            OpenPrint();
        }
        private void OpenPrint()
        {
            if (openStatus == 0)
            {
                CPCLPrint.ClosePort(printer);
            }
            string info = "";
            info = "USB," + "USB001";
            openStatus = CPCLPrint.OpenPort(printer, "USB,");
        }
        public void InitData()
        {
            List<string> cbxStr1 = new List<string>();
            cbxStr1 = DbContext.MySql.Select<WProductInfo>().Distinct().OrderByDescending(a => a.Id).ToList(a => a.Ptype);
            cbxStr1.Insert(0, "All");
            cbxType.DataSource = cbxStr1;
            cbxType.DisplayMember = "Ptype";
            cbxType.SelectedIndex = 0;
        }
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> cbxStr2 = new List<string>();
            cbxStr2 = DbContext.MySql.Select<WProductInfo>().Where(o => o.ValidFlag == 1 && o.Ptype == cbxType.Text).Distinct().ToList(o => o.PManufacturer);
            cbxStr2.Insert(0, "All");
            cbxPManufacturer.DataSource = cbxStr2;
            cbxPManufacturer.DisplayMember = "PManufacturer";
            cbxPManufacturer.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductADD frmProductADD = new frmProductADD();
            frmProductADD.ShowDialog();
        }
        private void btnSel_Click(object sender, EventArgs e)
        {
            GetProduteInfo();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvProductType.CurrentRow == null)
            {
                MessageBox.Show("请选择需要剔除的数据！");
                return;
            }
            if (!(dgvProductType.CurrentRow.DataBoundItem is WProductInfo wProductInfo))
            {
                return;
            }
            wProductInfo.ValidFlag = 0;
            DbContext.MySql.Update<WProductInfo>().SetSource(wProductInfo).ExecuteAffrows();
            GetProduteInfo();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string Path1 = Application.StartupPath + @"\备件库数据导出\备件信息导出\" + DateTime.Now.ToString("yyyyMMdd");
                string Path2 = Path1 + @"\备件" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (!Directory.Exists(Path1))
                {
                    Directory.CreateDirectory(Path1);
                }

                NpoiHelper.ExportExcel(Path2, dgvProductType, "宋体", 11);//这里的路径是需要写入你需要保存的文件格式的，不需要创建自动检测创建
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return;
            }
        }
        private void dgvProductType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgvProductType.CurrentRow.DataBoundItem is WProductInfo wProductInfo))
            {
                return;
            }
            if (e.ColumnIndex == 6)
            {
                LabPrint(wProductInfo);
            }
        }
        /// <summary>
        /// 标签打印
        /// </summary>
        /// <param name="wProductInfo"></param>
        private void LabPrint(WProductInfo wProductInfo)
        {
            CPCLPrint.CPCL_AddLabel(printer, 0, 500 , 1);
            CPCLPrint.CPCL_SetAlign(printer, 0);
            CPCLPrint.CPCL_AddText(printer, 0, "4", 7, _xPos, _yPos, "类别:");
            CPCLPrint.CPCL_AddText(printer, 0, "4", 7, (_xPos+100), _yPos , wProductInfo.Ptype);
            CPCLPrint.CPCL_AddLine(printer, (_xPos+80) , (_yPos+40) , (_xPos+540) , (_yPos+40) , 1);

            CPCLPrint.CPCL_AddText(printer, 0, "4", 7, _xPos , (_yPos+80) , "型号:");
            CPCLPrint.CPCL_AddText(printer, 0, "4", 7, (_xPos+100) , (_yPos+80) , wProductInfo.PSize);
            CPCLPrint.CPCL_AddLine(printer, (_xPos + 80) , (_yPos+120) , (_xPos + 540) , (_yPos + 120) , 1);

            CPCLPrint.CPCL_AddText(printer, 0, "4", 7, _xPos , (_yPos + 160) , "厂商:");
            CPCLPrint.CPCL_AddText(printer, 0, "4", 7, (_xPos + 100) , (_yPos + 160) , wProductInfo.PManufacturer);
            CPCLPrint.CPCL_AddLine(printer, (_xPos + 80) , (_yPos + 200) , (_xPos + 540) , (_yPos + 200) , 1);

            CPCLPrint.CPCL_AddBarCodeText(printer, 1, 8, 4, 0);
            CPCLPrint.CPCL_AddBarCode(printer, 0, 20, 2, 10, 80, (_xPos + 40) , (_yPos + 230) , wProductInfo.PNo);

            CPCLPrint.CPCL_AddText(printer, 0, "4", 2, _xPos , (_yPos + 360) , _companyName);
            CPCLPrint.CPCL_Print(printer);

        }

        private void GetProduteInfo()
        {
            string selType = cbxType.Text == "All" ? "" : cbxType.Text;
            string selPManufacturer = cbxPManufacturer.Text == "All" ? "" : cbxPManufacturer.Text;
            wProductInfos = DbContext.MySql.Select<WProductInfo>().Where(a => selType == "" ? a.ValidFlag == 1 : a.Ptype == selType
                                                                            && selPManufacturer == "" ? a.ValidFlag == 1 : a.PManufacturer == selPManufacturer
                                                                            && a.CTime >= dateFrom.Value
                                                                            && a.CTime <= dateTo.Value
                                                                            && a.ValidFlag == 1).OrderByDescending(a => a.Id).ToList();

            dgvProductType.DataSource = new BindingList<WProductInfo>(wProductInfos);
        }

        private void btnBatchPrint_Click(object sender, EventArgs e)
        {
            if (wProductInfos.Count!=0)
            {
                foreach (WProductInfo item in wProductInfos)
                {
                    LabPrint(item);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
