using KLWM.Auxiliary;
using KLWM.DataCore.Context;
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
            this.dgvinstore.AutoGenerateColumns = false;
            this.dgvoutstore.AutoGenerateColumns = false;
            this.dgvstore.AutoGenerateColumns = false;
            StaticDelegates.OnRspKanbanDataInChange += StaticDelegates_OnRspKanbanDataInChange;
            StaticDelegates.OnRspKanbanDataOutChange += StaticDelegates_OnRspKanbanDataOutChange;
            StaticDelegates.OnRspUserInfoChange += StaticDelegates_OnRspUserInfoChange;
        }

        private void StaticDelegates_OnRspUserInfoChange(UserInfoStruct userContext)
        {
            WUserinfo wUserinfo = DbContext.MySql.Select<WUserinfo>().Where(s => s.ValidFlag==1 && s.UId == userContext.Uid).First();
            Image originalImage;
            if (wUserinfo != null) 
            {
                using (MemoryStream ms = new MemoryStream(wUserinfo.UPhoto))
                {
                    originalImage = Image.FromStream(ms);
                }
                Invoke(new Action(() =>
                {
                    this.lblName.Text = wUserinfo.UName;
                    this.lblNo.Text = wUserinfo.UId;
                    this.pbxPeople.Image = originalImage;
                    this.lblStation.Text = wUserinfo.UStation;
                }));
            }
        }

        private void InitData()
        {
            GetStoreDataToday();
        }
        private void StaticDelegates_OnRspKanbanDataInChange()
        {
            Invoke(new Action(() =>
            {
                GetStoresDataToday();
                GetInStoreDataToday();

            }));
        }
        private void StaticDelegates_OnRspKanbanDataOutChange()
        {
            GetStoresDataToday();
            GetOutStoreDataToday();
        }
        /// <summary>
        /// 获取初始化数据
        /// </summary>
        private void GetStoreDataToday()
        {
            //Invoke(new Action(() =>
            //{
                GetStoresDataToday();
                GetInStoreDataToday();
                GetOutStoreDataToday();

            //}));
        }
        /// <summary>
        /// 获取今日库存变动
        /// </summary>
        private void GetStoresDataToday()
        {
            List<Storechange> wStores = DbContext.MySql.Select<Storechange>().Where(s=>s.CTime.Value.Between(DateTime.Today.Date,DateTime.Now.AddDays(1).Date)).ToList();
            BindingList<Storechange> bwStoresList = new BindingList<Storechange>(wStores);
            dgvstore.DataSource = bwStoresList;
        }
        /// <summary>
        /// 获取今日入库
        /// </summary>
        private void GetInStoreDataToday()
        {
            List<WInstore> wInStores = DbContext.MySql.Select<WInstore>().Where(s => s.CTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date)).ToList();
            BindingList<WInstore> bwInStoresList = new BindingList<WInstore>(wInStores);
            dgvinstore.DataSource = bwInStoresList;
        }
        /// <summary>
        /// 获取今日出库
        /// </summary>
        private void GetOutStoreDataToday()
        {
            List<WOutstore> wOutStores = DbContext.MySql.Select<WOutstore>().Where(s => s.CTime.Value.Between(DateTime.Today.Date, DateTime.Now.AddDays(1).Date)).ToList();
            BindingList<WOutstore> bwOutStoresList = new BindingList<WOutstore>(wOutStores);
            dgvoutstore.DataSource = bwOutStoresList;
        }

        private void btnInStore_Click(object sender, EventArgs e)
        {
            frmInStorage frmInStorage = new frmInStorage();
            frmInStorage.ShowDialog();
        }

        private void btnOutStore_Click(object sender, EventArgs e)
        {
            frmOutStorage frmOutStorage = new frmOutStorage();
            frmOutStorage.ShowDialog();
        }

        private void dgvstore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            if (dgvstore.Columns[e.ColumnIndex].Name == "PCount" &&  Double.Parse(e.Value.ToString()) < 0)
            {
                e.CellStyle.ForeColor = Color.Red;
            }

        }
    }
}
