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
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainLoadingRefactor.DataCore.DataModel;

namespace KLWM.UserControls
{
    public partial class UCameraInfo : UserControl
    {
        private List<WCameraLog> CameraLogs = new List<WCameraLog>();
        public UCameraInfo()
        {
            InitializeComponent();
            InitData();
            dgvCameraHis.AutoGenerateColumns = false;
        }
        public void InitData()
        {
            List<string> cbxStr1 = new List<string>();
            cbxStr1 = DbContext.MySql.Select<WCameraLog>().Distinct().OrderByDescending(a => a.Id).ToList(a => a.UStation);
            cbxStr1.Insert(0, "All");
            cbxStation.DataSource = cbxStr1;
            cbxStation.DisplayMember = "UStation";
            cbxStation.SelectedIndex = 0;
        }
        private void cbxStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> cbxStr2 = new List<string>();
            cbxStr2 = DbContext.MySql.Select<WCameraLog>().Where(o => o.ValidFlag == 1 && o.UStation == cbxStation.Text).Distinct().ToList(o => o.UName);
            cbxStr2.Insert(0, "All");
            cbxName.DataSource = cbxStr2;
            cbxName.DisplayMember = "Uname";
            cbxName.SelectedIndex = 0;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string selStation = cbxStation.Text == "All" ? "" : cbxStation.Text;
            string selName = cbxName.Text == "All" ? "" : cbxName.Text;
            CameraLogs = DbContext.MySql.Select<WCameraLog>().Where(a => selStation == "" ? a.ValidFlag == 1 : a.UStation == selStation
                                                                    && selName == "" ? a.ValidFlag == 1 : a.UName == selName
                                                                    && a.InTime >= dateFrom.Value
                                                                    && a.InTime <= dateTo.Value
                                                                    && a.ValidFlag == 1).OrderByDescending(a => a.Id).ToList();

            dgvCameraHis.DataSource = new BindingList<WCameraLog>(CameraLogs);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string Path1 = Application.StartupPath + @"\备件库数据导出\相机记录导出\" + DateTime.Now.ToString("yyyyMMdd");
                string Path2 = Path1 + @"\相机日志" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (!Directory.Exists(Path1))
                {
                    Directory.CreateDirectory(Path1);
                }

                NpoiHelper.ExportExcel(Path2, dgvCameraHis, "宋体", 11);//这里的路径是需要写入你需要保存的文件格式的，不需要创建自动检测创建
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
