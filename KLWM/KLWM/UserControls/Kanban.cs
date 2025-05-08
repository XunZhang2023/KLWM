using KLWM.Auxiliary;
using KLWM.DataCore.Context;
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
using static KLWM.Auxiliary.StaticDelegates;

namespace KLWM.UserFroms
{
    public partial class Kanban : UserControl
    {
        public Kanban()
        {
            InitializeComponent();
            InitData();
            this.dgvstore.AutoGenerateColumns = false;
            this.dgvCameraHis.AutoGenerateColumns = false;
            StaticDelegates.OnRspKanbanDataInChange += StaticDelegates_OnRspKanbanDataInChange;
            StaticDelegates.OnRspKanbanDataOutChange += StaticDelegates_OnRspKanbanDataOutChange;
            StaticDelegates.OnRspUserInfoChange += StaticDelegates_OnRspUserInfoChange;
            StaticDelegates.OnRspCameraDataChange += StaticDelegates_OnRspCameraDataChange;
        }
        /// <summary>
        /// 相机触发
        /// </summary>
        /// <param name="_InOrOut"></param>
        /// <param name="_ProductNo"></param>
        private void StaticDelegates_OnRspCameraDataChange(int _InOrOut, string _ProductNo)
        {
            WCameraLog wCameraLog = DbContext.MySql.Select<WCameraLog>().Where(s => s.IsOutbound == 0
                                                                                         && s.UName == StaticDelegates.wUserinfo.Uname
                                                                                         && s.InTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date))
                                                                                 .OrderByDescending(s => s.Id)
                                                                                 .First();

            if (wCameraLog != null)
            {
                //获取截图
                Bitmap bmp = new Bitmap(pbxReal.Width, pbxReal.Height);
                pbxReal.DrawToBitmap(bmp, pbxReal.ClientRectangle);
                byte[] imgbytes = ImgHelper.BitmapToByte(bmp);

                wCameraLog.OutTime = DateTime.Now;
                wCameraLog.OutPhoto = imgbytes;
                wCameraLog.IsOutbound = _InOrOut;
                wCameraLog.OutboundInfo = "_ProductNo";

                DbContext.MySql.Update<WCameraLog>().SetSource(wCameraLog).ExecuteAffrows();

            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            GetStoresDataToday();
            GetCameraLogToday();
            //DaHuaHelper.Realplay(this.pbxReal.Handle);
        }
        /// <summary>
        /// 用户触发
        /// </summary>
        /// <param name="userContext"></param>
        private void StaticDelegates_OnRspUserInfoChange(UserInfoStruct userContext)
        {
            try
            {
                WUserinfo wUserinfo = DbContext.MySql.Select<WUserinfo>().Where(s => s.ValidFlag == 1 && s.UName == userContext.Uname).First();
                Image originalImage;
                if (wUserinfo != null)
                {
                    //图片缩放
                    originalImage = ImgHelper.CreateThumbnail(wUserinfo.UPhoto, 280, 330);
                    Invoke(new Action(() =>
                    {
                        this.lblName.Text = wUserinfo.UName;
                        this.lblNo.Text = wUserinfo.UId;
                        this.pbxPeople.Image = originalImage;
                        this.lblStation.Text = wUserinfo.UStation;
                    }));
                    //获取截图
                    Bitmap bmp = new Bitmap(pbxReal.Width, pbxReal.Height);
                    pbxReal.DrawToBitmap(bmp, pbxReal.ClientRectangle);
                    byte[] imgbytes = ImgHelper.BitmapToByte(bmp);


                    WCameraLog wCameraLog = DbContext.MySql.Select<WCameraLog>().Where(s => s.IsOutbound == 0
                                                                                         && s.UName == userContext.Uname
                                                                                         && s.InTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date))
                                                                                 .OrderByDescending(s => s.Id)
                                                                                 .First();
                    //插入摄像头识别记录
                    if (wCameraLog == null)
                    {
                        WCameraLog NewwCameraLog = new WCameraLog()
                        {
                            UName = wUserinfo.UName,
                            UId = wUserinfo.UId,
                            UStation = wUserinfo.UStation,
                            InTime = DateTime.Now,
                            InPtoto = imgbytes,
                            IsOutbound = 0,
                            ValidFlag = 1
                        };

                        DbContext.MySql.Insert<WCameraLog>().AppendData(NewwCameraLog).ExecuteAffrows();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        /// <summary>
        /// 入库触发
        /// </summary>
        private void StaticDelegates_OnRspKanbanDataInChange()
        {
            GetStoresDataToday(); GetCameraLogToday();
        }
        /// <summary>
        /// 出库触发
        /// </summary>
        private void StaticDelegates_OnRspKanbanDataOutChange()
        {
            GetStoresDataToday(); GetCameraLogToday();
        }
        /// <summary>
        /// 获取初始化数据
        /// </summary>
        private void GetCameraLogToday()
        {
            List<WCameraLog> wCameraLog = DbContext.MySql.Select<WCameraLog>().Where(s => s.InTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date)).ToList();
            BindingList<WCameraLog> wCameraLogList = new BindingList<WCameraLog>(wCameraLog);
            dgvCameraHis.DataSource = wCameraLogList;
        }
        /// <summary>
        /// 获取今日库存变动
        /// </summary>
        private void GetStoresDataToday()
        {
            List<Storechange> wStores = DbContext.MySql.Select<Storechange>().Where(s => s.CTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date)).ToList();
            BindingList<Storechange> bwStoresList = new BindingList<Storechange>(wStores);
            dgvstore.DataSource = bwStoresList;
        }
        #region 出入库屏蔽
        ///// <summary>
        ///// 获取今日入库
        ///// </summary>
        //private void GetInStoreDataToday()
        //{
        //    List<WInstore> wInStores = DbContext.MySql.Select<WInstore>().Where(s => s.CTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date)).ToList();
        //    BindingList<WInstore> bwInStoresList = new BindingList<WInstore>(wInStores);
        //    dgvinstore.DataSource = bwInStoresList;
        //}
        ///// <summary>
        ///// 获取今日出库
        ///// </summary>
        //private void GetOutStoreDataToday()
        //{
        //    List<WOutstore> wOutStores = DbContext.MySql.Select<WOutstore>().Where(s => s.CTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date)).ToList();
        //    BindingList<WOutstore> bwOutStoresList = new BindingList<WOutstore>(wOutStores);
        //    dgvoutstore.DataSource = bwOutStoresList;
        //}
        #endregion
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInStore_Click(object sender, EventArgs e)
        {
            frmInStorage frmInStorage = new frmInStorage();
            frmInStorage.ShowDialog();
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutStore_Click(object sender, EventArgs e)
        {
            frmOutStorage frmOutStorage = new frmOutStorage();
            frmOutStorage.ShowDialog();
        }
        /// <summary>
        /// 判断状态显示红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvstore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            if (dgvstore.Columns[e.ColumnIndex].Name == "PCount" && Double.Parse(e.Value.ToString()) < 0)
            {
                e.CellStyle.ForeColor = Color.Red;
            }

        }
        /// <summary>
        /// 判断状态显示红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCameraHis_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            if (dgvstore.Columns[e.ColumnIndex].Name == "IsOutbound" && Double.Parse(e.Value.ToString()) < 1)
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }
    }
}
