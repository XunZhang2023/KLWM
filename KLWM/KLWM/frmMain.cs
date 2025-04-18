using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using KLWM.Auxiliary;
using KLWM.UserControls;
using KLWM.UserFroms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KLWM
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Kanban Kanban = new Kanban();
        UInStorage UInStorage = new UInStorage();
        UOuttorage UOuttorage = new UOuttorage();
        UPeopleManager UopleManager = new UPeopleManager();
        UProductType UProductType = new UProductType();
        UStorages UStorages = new UStorages();
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitControl();
        }
        private void InitControl()
        {
            Kanban.Visible = true;
            Kanban.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(Kanban);

            UInStorage.Dock = DockStyle.Fill;
            UInStorage.Visible = false;
            fluentDesignFormContainer1.Controls.Add(UInStorage);

            UOuttorage.Dock = DockStyle.Fill;
            UOuttorage.Visible = false;
            fluentDesignFormContainer1.Controls.Add(UOuttorage);

            UopleManager.Dock = DockStyle.Fill;
            UopleManager.Visible = false;
            fluentDesignFormContainer1.Controls.Add(UopleManager);

            UProductType.Dock = DockStyle.Fill;
            UProductType.Visible = false;
            fluentDesignFormContainer1.Controls.Add(UProductType);

            UStorages.Dock = DockStyle.Fill;
            UStorages.Visible = false;
            fluentDesignFormContainer1.Controls.Add(UStorages);
        }
        private void accordionControl1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            AccordionControlElement accordionControlElement = (AccordionControlElement)sender;
            switch (accordionControlElement.Tag)
            {
                case "看板":
                    ShowControl(Kanban);
                    break;
                case "产品信息":
                    ShowControl(UProductType);
                    break;
                case "人员管理":
                    ShowControl(UopleManager);
                    break;
                case "入库":
                    ShowControl(UInStorage);
                    break;
                case "出库":
                    ShowControl(UOuttorage);
                    break;
                case "库存":
                    ShowControl(UStorages);
                    break;
                default:
                    break;
            }
            #region 密码屏蔽

            //case "功能码打印":
            //    dialog = new Password().ShowDialog();
            //    if (dialog == DialogResult.OK)
            //    {
            //        ShowControl(functionCodePrint);
            //    }
            //    break;
            #endregion
        }
        private void ShowControl(UserControl control)
        {
            foreach (var item in fluentDesignFormContainer1.Controls)
            {
                try
                {
                    if (item is UserControl)
                    {
                        UserControl tempControl = (UserControl)item;
                        if (tempControl.Name != control.Name)
                        {
                            tempControl.Visible = false;
                            continue;
                        }
                        control.Visible = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
