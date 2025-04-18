using KLWM.Auxiliary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace ProcessControlSystem
{
    /*===================================================
    * 类名称: ScanDriverContext
    * 类描述: 扫描枪，所有扫描枪扫描的东西都是通过驱动传到这里，这里在传到产线在通过产线分配给需要扫描的工位
    * 创建人: cp
    * 修改人:
    * 修改时间:
    * 版本： 1.0
    =====================================================*/
    public class ScanDriverContext
    {
        public delegate void RspBarcode(string barcode);
        public static event RspBarcode OnRspBarcode;

        public static TData InitScanDriver()
        {
            string port = ConfigurationManager.AppSettings["Comport"];
            int bps = Convert.ToInt32(ConfigurationManager.AppSettings["Bps"]);
            try
            {
                ScanDriver driver = new ScanDriver();
                if (!driver.Connection(port,bps))
                {
                    MessageBox.Show("扫码枪连接失败！请正确连接扫码枪！");
                }
                //return new TData() { Success = false, ExceptionMessage = item.Comport + "连接失败！" };
                driver.OnRspBarcode += Driver_OnRspBarcode;
                return new TData() { Success = true };
            }
            catch (Exception ex)
            {
                return new TData() { Success = false, ExceptionMessage = ex.Message };
            }
            
        }

        private static void Driver_OnRspBarcode(string barcode)
        {
            OnRspBarcode?.Invoke(barcode);
        }
    }
}
