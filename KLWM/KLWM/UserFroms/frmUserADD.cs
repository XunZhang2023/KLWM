using KLWM.Auxiliary;
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

namespace KLWM.UserFroms
{
    public partial class frmUserADD : Form
    {
        public frmUserADD()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 拖拽放开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPhoto_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            tbxPhoto.Text = path;
        }
        /// <summary>
        /// 拖拽进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPhoto_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// 按钮打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string fileFilter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
            string image_path = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = fileFilter;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            image_path = ofd.FileName;
            tbxPhoto.Text = image_path;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxUId.Text))
                {
                    MessageBox.Show("请正确输入员工号！");
                    return;
                }
                if (string.IsNullOrEmpty(tbxStation.Text))
                {
                    MessageBox.Show("请正确输入岗位名！");
                    return;
                }
                if (string.IsNullOrEmpty(tbxUName.Text))
                {
                    MessageBox.Show("请正确输入员工姓名！");
                    return;
                }
                Byte[] byData = ImgHelper.GetImageByteFromPath(tbxPhoto.Text);
                WUserinfo wUserinfoNew = new WUserinfo()
                {
                    UStation = tbxStation.Text,
                    UName = tbxUName.Text,
                    UPhoto = byData,
                     UId = tbxUId.Text,
                    ValidFlag = 1,
                    CTime = DateTime.Now
                };
                WUserinfo wUserinfo = DbContext.MySql.Select<WUserinfo>().Where(s => s.UId==tbxUId.Text).First();
                if (wUserinfo != null)
                {
                    wUserinfoNew.Id = wUserinfo.Id;
                    DbContext.MySql.Update<WUserinfo>().SetSource(wUserinfoNew).ExecuteAffrows();
                }
                else
                {
                    DbContext.MySql.Insert<WUserinfo>().AppendData(wUserinfoNew).ExecuteAffrows();
                }
                
                MessageBox.Show("数据保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
