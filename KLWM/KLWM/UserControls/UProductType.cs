using DevExpress.Utils.About;
using KLWM.Auxiliary;
using KLWM.UserFroms;
using Org.BouncyCastle.Utilities.Collections;
using ProcessControlSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainLoadingRefactor.DataCore.DataModel;
using WinSDKDemo_ZPL;

namespace KLWM.UserControls
{
    public partial class UProductType : UserControl
    {
        List<WProductInfo> wProductInfos = new List<WProductInfo>();
        IntPtr printer;
        bool isOpen = false;
        public UProductType()
        {
            InitializeComponent();
            InitData(); 
           // ZPLPrint.PrinterCreator(ref printer, "");
            dgvProductType.AutoGenerateColumns = false;
            //OpenPrint();
        }

        private void OpenPrint()
        {
            if (isOpen)
            {
                ZPLPrint.ClosePort(printer);
            }
            string info = "";
            info = "USB," + "";
            isOpen = ZPLPrint.OpenPort(printer, info) == 0;

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
            //打印
            ZPLPrint.ZPL_StartFormat(printer);
            ZPLPrint.ZPL_Text(printer, 50, 50, 12, 0, 15, 12, "类别: ");//类别
            ZPLPrint.ZPL_Text(printer, 80, 45, 12, 0, 15, 12, wProductInfo.Ptype);//类别
            ZPLPrint.ZPL_GraphicBox(printer, 120, 50, 300, 2, 2, 0);//下划线
            ZPLPrint.ZPL_Text(printer, 50, 120, 12, 0, 15, 12, "型号: ");//型号
            ZPLPrint.ZPL_Text(printer, 80, 115, 12, 0, 15, 12, wProductInfo.PSize);//型号
            ZPLPrint.ZPL_GraphicBox(printer, 120, 120, 300, 2, 2, 0);//下划线
            ZPLPrint.ZPL_Text(printer, 50, 190, 12, 0, 15, 12, "厂商:");//厂商
            ZPLPrint.ZPL_Text(printer, 80, 185, 12, 0, 15, 12, wProductInfo.PManufacturer);//厂商
            ZPLPrint.ZPL_GraphicBox(printer, 120, 190, 300, 2, 2, 0);//下划线
            ZPLPrint.ZPL_BarCode128(printer, 80, 210, 0, 5, 150, 'Y', 'N', 'N', 'A', wProductInfo.PNo);//条码
            ZPLPrint.ZPL_EndFormat(printer);
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
