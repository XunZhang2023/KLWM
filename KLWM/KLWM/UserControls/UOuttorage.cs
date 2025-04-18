using KLWM.Auxiliary;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainLoadingRefactor.DataCore.DataModel;

namespace KLWM.UserControls
{
    public partial class UOuttorage : UserControl
    {
        private List<WOutstore> OutStores = new List<WOutstore>();
        public UOuttorage()
        {
            InitializeComponent();
            InitData();
            dgvOutStorage.AutoGenerateColumns = false;
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
        private void btnSel_Click(object sender, EventArgs e)
        {
            string selType = cbxType.Text == "All" ? "" : cbxType.Text;
            string selPManufacturer = cbxPManufacturer.Text == "All" ? "" : cbxPManufacturer.Text;
            OutStores = DbContext.MySql.Select<WOutstore>().Where(a => selType==""? a.ValidFlag == 1: a.PType == selType 
                                                                    && selPManufacturer==""? a.ValidFlag == 1: a.PManufacturer == selPManufacturer
                                                                    && a.CTime >= dateFrom.Value
                                                                    && a.CTime <= dateTo.Value
                                                                    && a.ValidFlag == 1).OrderByDescending(a => a.Id).ToList();
            dgvOutStorage.DataSource = new BindingList<WOutstore>(OutStores);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string Path1 = Application.StartupPath + @"\备件库数据导出\出库记录导出\" + DateTime.Now.ToString("yyyyMMdd");
                string Path2 = Path1 + @"\出库" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (!Directory.Exists(Path1))
                {
                    Directory.CreateDirectory(Path1);
                }

                NpoiHelper.ExportExcel(Path2, dgvOutStorage, "宋体", 11);//这里的路径是需要写入你需要保存的文件格式的，不需要创建自动检测创建
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
