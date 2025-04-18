using DevExpress.Utils.Extensions;
using KLWM.Auxiliary;
using ProcessControlSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainLoadingRefactor.DataCore.DataModel;
using static DevExpress.XtraEditors.RoundedSkinPanel;

namespace KLWM.UserFroms
{
    public partial class frmInStorage : Form
    {
        public frmInStorage()
        {
            InitializeComponent();

            dgvInStore.AutoGenerateColumns = false;
            InStoreSource.DataSource = InStores;
            dgvInStore.DataSource = InStoreSource.DataSource;

            ScanDriverContext.OnRspBarcode += ScanDriverContext_OnRspBarcode;
            StaticDelegates.OnRspInOrOutCountChange += StaticDelegates_OnRspInOrOutCountChange;
        }
        private BindingList<WInstore> InStores = new BindingList<WInstore>();
        private BindingSource InStoreSource = new BindingSource();
        /// <summary>
        /// 添加入库信息
        /// </summary>
        /// <param name="inOrOutCount"></param>
        private void StaticDelegates_OnRspInOrOutCountChange(double inOrOutCount)
        {
            if (this.Visible == true)
            {
                Invoke(new Action(() =>
                {
                if (this.tbxNo.Text == "")
                {
                    MessageBox.Show("请在文本输入框中输入备件编码！");
                    return;
                }
                WProductInfo wProductInfo = DbContext.MySql.Select<WProductInfo>().Where(e => e.PNo == this.tbxNo.Text).First();//.Where(e => e.PNo == this.tbxNo.Text)
                if (wProductInfo == null)
                {
                    MessageBox.Show("为找到该备件信息！请添加备件信息！");
                }
                WInstore wInstore = new WInstore()
                {
                    PNo = wProductInfo.PNo,
                    PType = wProductInfo.Ptype,
                    PName = wProductInfo.PName,
                    PManufacturer = wProductInfo.PManufacturer,
                    PSize = wProductInfo.PSize,
                    PUnit = wProductInfo.PUnit,
                    InCount = inOrOutCount,
                    Comment = "",
                    CTime = DateTime.Now,
                    ValidFlag = 1
                };
                InStores.Add(wInstore);
                InStoreSource.DataSource = InStores;
                this.tbxNo.Text = "";
                }));
            }
        }
        /// <summary>
        /// 打开数量输入界面
        /// </summary>
        /// <param name="barcode"></param>
        private void ScanDriverContext_OnRspBarcode(string barcode)
        {
            if (barcode == string.Empty || barcode == default) return;
            if (this.Visible == true)
            {
                Invoke(new Action(() =>
                {
                    this.tbxNo.Text = barcode;
                    frmCount frmCount = new frmCount();
                    frmCount.ShowDialog();
                }));
            }
        }
        /// <summary>
        /// 删除选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvInStore.CurrentRow == null)
            {
                MessageBox.Show("请选择需要剔除的数据！");
                return;
            }
            if (!(dgvInStore.CurrentRow.DataBoundItem is WInstore wInStore))
            {
                return;
            }
            WInstore inStore = InStores.Where(a => a.PNo == wInStore.PNo).First();
            Invoke(new Action(() =>
            {
                dgvInStore.Rows.RemoveAt(InStores.IndexOf(wInStore));
                InStores.Remove(inStore);
                dgvInStore.Refresh();
            }));
        }
        /// <summary>
        /// 手动添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualIn_Click(object sender, EventArgs e)
        {
            frmCount frmCount = new frmCount();
            frmCount.ShowDialog();
        }
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInStore_Click(object sender, EventArgs e)
        {
            DbContext.MySql.Transaction(() =>
            {
                //保存入库表
                var affrows = DbContext.MySql.Insert<WInstore>().AppendData(InStores).ExecuteAffrows();
                if (affrows < 1)
                {
                    MessageBox.Show("数据存储失败！事务逻辑不会造成脏数据！");
                    return;
                }
                //保存库存表
                foreach (var item in InStores)
                {
                    Thread.Sleep(10);
                    WStores wStore = DbContext.MySql.Select<WStores>().Where(a => a.PNo == item.PNo).First();
                    WStores newWStores = new WStores()
                    {
                        PNo = item.PNo,
                        PName = item.PName,
                        PType = item.PType,
                        PManufacturer = item.PManufacturer,
                        PSize = item.PSize,
                        PUnit = item.PUnit,
                        ValidFlag = 1
                    };
                    if (wStore != null)
                    {
                        newWStores.PCount = item.InCount + wStore.PCount;
                        newWStores.Id = wStore.Id;
                        newWStores.CTime = wStore.CTime;
                        affrows = DbContext.MySql.Update<WStores>().SetSource(newWStores).ExecuteAffrows();
                    }
                    else
                    {
                        newWStores.PCount = item.InCount;
                        newWStores.CTime = DateTime.Now;
                        affrows = DbContext.MySql.Insert<WStores>().AppendData(newWStores).ExecuteAffrows();
                    }
                    if (affrows < 1)
                    {
                        MessageBox.Show("数据存储失败！事务逻辑不会造成脏数据！");
                        return;
                    }
                }
                MessageBox.Show("入库成功！");
                InStores.Clear();
                StaticDelegates.KanbanDataInChange();
            });
        }
    }
}
