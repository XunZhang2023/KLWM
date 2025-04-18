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
    public partial class frmProductADD : Form
    {
        public frmProductADD()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("请正确输入备件名！");
                return;
            }
            if (string.IsNullOrEmpty(tbxSize.Text))
            {
                MessageBox.Show("请正确输入备件规格！");
                return;
            }
            if (string.IsNullOrEmpty(tbxType.Text))
            {
                MessageBox.Show("请正确输入备件类别！");
                return;
            }
            if (string.IsNullOrEmpty(tbxManufacturer.Text))
            {
                MessageBox.Show("请正确输入备件厂商！");
                return;
            }
            if (string.IsNullOrEmpty(tbxUnit.Text))
            {
                MessageBox.Show("请正确输入备件单位！");
                return;
            }
            WProductInfo wProductInfo = DbContext.MySql.Select<WProductInfo>().Where(a => a.PName == this.tbxName.Text
                                                                                        && a.PSize == this.tbxSize.Text
                                                                                        && a.Ptype == this.tbxType.Text
                                                                                        && a.PManufacturer == this.tbxManufacturer.Text
                                                                                        && a.PUnit == this.tbxUnit.Text).First();
            if (wProductInfo != null)
            {
                MessageBox.Show("该备件信息已经存在！请勿重新录入！");
                return;
            }
            else
            {
                WProductType wProduct = DbContext.MySql.Select<WProductType>().Where(p => p.PType == this.tbxType.Text
                                                                                   && p.PManufacturer == this.tbxManufacturer.Text
                                                                                   && p.PSize == this.tbxSize.Text).First();
                if (wProduct == null)
                {
                    WProductType wProductType = new WProductType()
                    {
                        PType = this.tbxType.Text,
                        PManufacturer = this.tbxManufacturer.Text,
                        PSize = this.tbxSize.Text,
                        CTime = DateTime.Now,
                        ValidFlag = 1
                    };
                    DbContext.MySql.Insert<WProductType>().AppendData(wProductType).ExecuteAffrows();
                }
                Thread.Sleep(50);
                wProduct = DbContext.MySql.Select<WProductType>().Where(p => p.PType == this.tbxType.Text
                                                                                   && p.PManufacturer == this.tbxManufacturer.Text
                                                                                   && p.PSize == this.tbxSize.Text).First();
                WProductInfo newProductInfo = new WProductInfo()
                {
                    PNo = CreatPNo(wProduct),
                    PName = tbxName.Text,
                    PSize = tbxSize.Text,
                    Ptype = tbxType.Text,
                    PManufacturer = tbxManufacturer.Text,
                    PUnit = tbxUnit.Text,
                    CTime = DateTime.Now,
                    ValidFlag = 1
                };
                DbContext.MySql.Insert<WProductInfo>().AppendData(newProductInfo).ExecuteAffrows();
                MessageBox.Show("备件库信息保存成功！");
                return;
            }

        }
        private string CreatPNo(WProductType wProduct)
        {
            string pNo = string.Empty;
            pNo = "KL" + wProduct.Id.ToString().PadLeft(4,'0') + DateTime.Now.ToString("yy") + DateTime.Now.DayOfYear.ToString().PadLeft(3, '0') + DateTime.Now.ToString("HHmmss");
            return pNo;
        }
    }
}
