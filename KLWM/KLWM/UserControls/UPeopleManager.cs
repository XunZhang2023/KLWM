using DevExpress.Drawing.Internal.Fonts.Interop;
using DevExpress.XtraExport.Helpers;
using KLWM.Auxiliary;
using KLWM.UserFroms;
using NPOI.Util;
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
    public partial class UPeopleManager : UserControl
    {
        private Form zoomForm; 
        private PictureBox zoomPictureBox;
        private List<WUserinfo> wUserinfo = new List<WUserinfo>();
        public UPeopleManager()
        {
            InitializeComponent();
            InitData();
            InitializeZoomForm();
            dgvPeople.AutoGenerateColumns = false;
            // 添加鼠标移动事件
            dgvPeople.CellMouseEnter += dgvPeople_CellMouseEnter;
            dgvPeople.CellMouseLeave += dgvPeople_CellMouseLeave;
            dgvPeople.MouseMove += dgvPeople_MouseMove;
        }
        private void InitializeZoomForm()
        {
            zoomForm = new Form();
            zoomForm.FormBorderStyle = FormBorderStyle.None;
            zoomForm.ShowInTaskbar = false;
            zoomForm.StartPosition = FormStartPosition.Manual;
            zoomForm.TopMost = true;

            zoomPictureBox = new PictureBox();
            zoomPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            zoomPictureBox.Dock = DockStyle.Fill;
            zoomPictureBox.BackColor = Color.White;
            //zoomPictureBox.BorderStyle = BorderStyle.FixedSingle;

            zoomForm.Controls.Add(zoomPictureBox);
            zoomForm.Padding = new Padding(5);
            zoomForm.Visible = false;
        }
        public void InitData()
        {
            List<string> cbxStr1 = new List<string>();
            cbxStr1 = DbContext.MySql.Select<WUserinfo>().Distinct().OrderByDescending(a => a.Id).ToList(a => a.UStation);
            cbxStr1.Insert(0, "All");
            cbxUStation.DataSource = cbxStr1;
            cbxUStation.DisplayMember = "UStation";
            cbxUStation.SelectedIndex = 0;
        }
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> cbxStr2 = new List<string>();
            cbxStr2 = DbContext.MySql.Select<WUserinfo>().Where(o => o.ValidFlag == 1 && o.UStation == cbxUStation.Text).Distinct().ToList(o => o.UName);
            cbxStr2.Insert(0, "All");
            cbxUName.DataSource = cbxStr2;
            cbxUName.DisplayMember = "UName";
            cbxUName.SelectedIndex = 0;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            GetPeopleInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserADD frmUserADD = new frmUserADD();
            frmUserADD.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (dgvPeople.CurrentRow == null)
            {
                MessageBox.Show("请选择需要剔除的数据！");
                return;
            }
            if (!(dgvPeople.CurrentRow.DataBoundItem is WUserinfo wUserinfo))
            {
                return;
            }
            wUserinfo.ValidFlag = 0;
            DbContext.MySql.Update<WUserinfo>().SetSource(wUserinfo).ExecuteAffrows();
            GetPeopleInfo();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string Path1 = Application.StartupPath + @"\备件库数据导出\用户信息导出\" + DateTime.Now.ToString("yyyyMMdd");
                string Path2 = Path1 + @"\用户" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (!Directory.Exists(Path1))
                {
                    Directory.CreateDirectory(Path1);
                }

                NpoiHelper.ExportExcel(Path2, dgvPeople, "宋体", 11);//这里的路径是需要写入你需要保存的文件格式的，不需要创建自动检测创建
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void GetPeopleInfo()
        {
            string selUStation = cbxUStation.Text == "All" ? "" : cbxUStation.Text;
            string selPUName = cbxUName.Text == "All" ? "" : cbxUName.Text;
            wUserinfo = DbContext.MySql.Select<WUserinfo>().Where(a => selUStation == "" ? a.ValidFlag == 1 : a.UStation == selUStation
                                                                    && selPUName == "" ? a.ValidFlag == 1 : a.UName == selPUName
                                                                    && a.CTime >= dateFrom.Value
                                                                    && a.CTime <= dateTo.Value
                                                                    && a.ValidFlag == 1).OrderByDescending(a => a.Id).ToList();


            foreach (WUserinfo item in wUserinfo)
            {
                item.UPhoto = ImgHelper.PhotoImageInsert(ImgHelper.CreateThumbnail(item.UPhoto, 30, 30));
                Thread.Sleep(10);
            }

            dgvPeople.DataSource = new BindingList<WUserinfo>(wUserinfo);
        }

        #region 图片预览处理
        private void UpdateZoomFormPosition()
        {
            // 设置放大窗体显示在鼠标右下方
            Point mousePos = Control.MousePosition;
            int offset = 20; // 距离鼠标的偏移量
            zoomForm.Location = new Point(mousePos.X + offset, mousePos.Y + offset);

            // 设置放大图片的大小（原始大小的2倍）
            if (zoomPictureBox.Image != null)
            {
                int zoomWidth = zoomPictureBox.Image.Width * 4;
                int zoomHeight = zoomPictureBox.Image.Height * 4;

                // 限制最大大小
                int maxSize = 400;
                if (zoomWidth > maxSize) zoomWidth = maxSize;
                if (zoomHeight > maxSize) zoomHeight = maxSize;

                zoomForm.ClientSize = new Size(zoomWidth, zoomHeight);
            }
        }
        private void dgvPeople_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoomForm.Visible)
            {
                UpdateZoomFormPosition();
            }
        }

        private void dgvPeople_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPeople.Columns["UPhoto"].Index)
            {
                zoomForm.Visible = false;
            }
        }

        private void dgvPeople_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPeople.Columns["UPhoto"].Index && e.RowIndex >= 0)
            {
                var cell = dgvPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value is byte[])
                {
                    Image image = ImgHelper.CreateThumbnail(cell.Value as byte[], 30, 30);
                    zoomPictureBox.Image = image;
                    UpdateZoomFormPosition();
                    zoomForm.Visible = true;
                }
            }
        }
        #endregion
    }
}
