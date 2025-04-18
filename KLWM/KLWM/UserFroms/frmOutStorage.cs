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

namespace KLWM.UserFroms
{
    public partial class frmOutStorage : Form
    {
        public frmOutStorage()
        {
            InitializeComponent();

            dgvOutStore.AutoGenerateColumns = false;
            OutStoreSource.DataSource = OutStores;
            dgvOutStore.DataSource = OutStoreSource;

            ScanDriverContext.OnRspBarcode += ScanDriverContext_OnRspBarcode;
            StaticDelegates.OnRspInOrOutCountChange += StaticDelegates_OnRspInOrOutCountChange;
        }

        private BindingList<WOutstore> OutStores = new BindingList<WOutstore>();
        private BindingSource OutStoreSource = new BindingSource();
        /// <summary>
        /// 添加出库信息
        /// </summary>
        /// <param name="inOrOutCount"></param>
        private void StaticDelegates_OnRspInOrOutCountChange(double inOrOutCount)
        {

            if (this.Visible == true)
            {
                string uName = StaticDelegates.wUserinfo.Uname;
                if (this.tbxNo.Text == "")
                {
                    MessageBox.Show("请在文本输入框中输入备件编码！");
                    return;
                }
                WProductInfo wProductInfo = DbContext.MySql.Select<WProductInfo>().Where(e => e.PNo == this.tbxNo.Text).First();
                if (wProductInfo == null)
                {
                    MessageBox.Show("为找到该备件信息！请添加备件信息！");
                    return;
                }
                WOutstore wOutstore = new WOutstore()
                {
                    PNo = wProductInfo.PNo,
                    PType = wProductInfo.Ptype,
                    PName = wProductInfo.PName,
                    PManufacturer = wProductInfo.PManufacturer,
                    PSize = wProductInfo.PSize,
                    PUnit = wProductInfo.PUnit,
                    POutCount = inOrOutCount,
                    POutRecipient = uName == "" ? "" : uName,
                    Comment = "",
                    CTime = DateTime.Now,
                    ValidFlag = 1
                };
                OutStores.Add(wOutstore);
                OutStoreSource.DataSource = OutStores;
                this.tbxNo.Text = "";
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

            if (dgvOutStore.CurrentRow == null)
            {
                MessageBox.Show("请选择需要剔除的数据！");
                return;
            }
            if (!(dgvOutStore.CurrentRow.DataBoundItem is WOutstore wOutStore))
            {
                return;
            }
            WOutstore OutStore = OutStores.Where(a => a.PNo == wOutStore.PNo && a.POutCount== wOutStore.POutCount).First();
            Invoke(new Action(() =>
            {
                dgvOutStore.Rows.RemoveAt(OutStores.IndexOf(OutStore));
                OutStores.Remove(OutStore);
                dgvOutStore.Refresh();
            }));
        }
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutStore_Click(object sender, EventArgs e)
        {
            DbContext.MySql.Transaction(() => {
                //保存出库表
                var affrows = DbContext.MySql.Insert<WOutstore>().AppendData(OutStores).ExecuteAffrows();
                if (affrows < 1)
                {
                    MessageBox.Show("数据存储失败！事务逻辑不会造成脏数据！");
                    return;
                }
                //保存库存表
                foreach (var item in OutStores)
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
                        if (item.POutCount > wStore.PCount)
                        {
                            MessageBox.Show("库存数量不足！请确认出库数量！");
                            return;
                        }
                        newWStores.PCount = wStore.PCount - item.POutCount;
                        newWStores.Id = wStore.Id;
                        newWStores.CTime = wStore.CTime;
                        affrows = DbContext.MySql.Update<WStores>().SetSource(newWStores).ExecuteAffrows();
                    }
                    else
                    {
                        MessageBox.Show("未找到此备件！请确认已入库或检查备件编码是否正确！");
                        return;
                    }
                    if (affrows < 1)
                    {
                        MessageBox.Show("数据存储失败！事务逻辑不会造成脏数据！");
                        return;
                    }
                }
                MessageBox.Show("出库成功！");
                OutStores.Clear();
                StaticDelegates.KanbanDataOutChange();
            });
        }
        /// <summary>
        /// 手动添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualOut_Click(object sender, EventArgs e)
        {
            frmCount frmCount = new frmCount();
            frmCount.ShowDialog();
        }
    }
}
