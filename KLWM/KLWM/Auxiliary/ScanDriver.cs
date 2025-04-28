using Microsoft.Win32.SafeHandles;
using RJCP.IO.Ports;
using System;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Threading;

namespace ProcessControlSystem
{
	/*===================================================
	* 类名称: ScanDriver
	* 类描述: 扫描枪驱动
	* 创建人: cp
	* 修改人:
	* 修改时间:
	* 版本： 1.0
	=====================================================*/
	public class ScanDriver
	{
		public delegate void RspBarcode(string barcode);
		public event RspBarcode OnRspBarcode;

		private string BarCode = string.Empty;


        SerialPortStream serialPortStream;

        public bool Connection(string cPort, int bps)
		{
            try
            {
                serialPortStream = new SerialPortStream(cPort, bps, 8, Parity.None, StopBits.One);

                serialPortStream.RtsEnable = true;
                serialPortStream.ReceivedBytesThreshold = 1;
                serialPortStream.DataReceived += SerialPortStream_DataReceived;
                serialPortStream.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void CloseSerialPort()
        {
            if (serialPortStream != null && serialPortStream.IsOpen)
            {
                try
                {
                    // 1. 禁用流控制信号
                    serialPortStream.RtsEnable = false;
                    serialPortStream.DtrEnable = false;

                    // 2. 清空缓冲区
                    serialPortStream.DiscardInBuffer();
                    serialPortStream.DiscardOutBuffer();

                    // 3. 关闭端口
                    serialPortStream.Close();

                    // 4. 等待完全关闭
                    int retry = 0;
                    while (serialPortStream.IsOpen && retry++ < 5)
                    {
                        Thread.Sleep(100);
                    }

                    // 5. 强制释放资源
                    if (serialPortStream.IsOpen)
                    {
                        var handle = serialPortStream.GetType().GetField("m_Handle",
                                  System.Reflection.BindingFlags.NonPublic |
                                  System.Reflection.BindingFlags.Instance)?
                                  .GetValue(serialPortStream) as SafeFileHandle;

                        handle?.Close();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"关闭串口异常: {ex.Message}");
                }
                finally
                {
                    serialPortStream.Dispose();
                }
            }
        }

public static void ResetComPort(string portName)
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher(
                $"SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%{portName}%'"))
            {
                foreach (ManagementObject device in searcher.Get())
                {
                    device.InvokeMethod("Disable", null);
                    Thread.Sleep(500);
                    device.InvokeMethod("Enable", null);
                    Thread.Sleep(1000); // 等待设备重新初始化
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"重置端口失败: {ex.Message}");
        }
    }


    private void SerialPortStream_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(160);
            BarCode = ReadData().Replace("\r", String.Empty).Replace("\n", String.Empty);
            OnRspBarcode?.Invoke(BarCode);
        }

        private String ReadData()
		{
            byte[] buffer = new byte[this.serialPortStream.BytesToRead];
            this.serialPortStream.Read(buffer, 0, buffer.Length);
            serialPortStream.DiscardInBuffer();
            return Encoding.ASCII.GetString(buffer, 0, buffer.Length);

        }
	}
}
