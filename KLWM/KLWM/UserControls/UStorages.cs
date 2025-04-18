using DevExpress.XtraPrinting;
using KLWM.Auxiliary;
using Newtonsoft.Json;
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

namespace KLWM.UserControls
{
    public partial class UStorages : UserControl
    {
        private List<WStores> wStores = new List<WStores>();
        public UStorages()
        {
            InitializeComponent();
            InitData();
            dgvStorages.AutoGenerateColumns = false;
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

        private void btnExpore_Click(object sender, EventArgs e)
        {

            try
            {
                string Path1 = Application.StartupPath + @"\备件库数据导出\库存信息导出\" + DateTime.Now.ToString("yyyyMMdd");
                string Path2 = Path1 + @"\库存" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (!Directory.Exists(Path1))
                {
                    Directory.CreateDirectory(Path1);
                }

                NpoiHelper.ExportExcel(Path2, dgvStorages, "宋体", 11);//这里的路径是需要写入你需要保存的文件格式的，不需要创建自动检测创建
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFolder();
                List<WStores> wStores = NpoiHelper.InputExcel(path);
                DbContext.MySql.Insert<WStores>().AppendData(wStores).ExecuteAffrows();
                MessageBox.Show("备件数据导入成功！");
                GetStorages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private string OpenFolder()
        {
            string sPath = ""; 
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sPath = dialog.FileName;
            }
            return sPath;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            GetStorages();
        }

        private void GetStorages()
        {

            string selType = cbxType.Text == "All" ? "" : cbxType.Text;
            string selPManufacturer = cbxPManufacturer.Text == "All" ? "" : cbxPManufacturer.Text;
            wStores = DbContext.MySql.Select<WStores>().Where(a => selType == "" ? a.ValidFlag == 1 : a.PType == selType
                                                                    && selPManufacturer == "" ? a.ValidFlag == 1 : a.PManufacturer == selPManufacturer
                                                                    && a.CTime >= dateTo.Value
                                                                    && a.CTime <= dateFrom.Value
                                                                    && a.ValidFlag == 1).OrderByDescending(a => a.Id).ToList();
            dgvStorages.DataSource = new BindingList<WStores>(wStores);
        }
    }
}
