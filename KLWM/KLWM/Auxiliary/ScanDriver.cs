using System;
using System.IO.Ports;
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

		private string CPort = string.Empty;

		private string BarCode = string.Empty;

		private SerialPort ScanGun;

		public bool Connection(string cPort, int bps)
		{
			try
			{
				CPort = cPort;

                ScanGun = new SerialPort(cPort, bps, Parity.None, 8, StopBits.One);
                ScanGun.ReceivedBytesThreshold = 1;
				ScanGun.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

				if (ScanGun.IsOpen)
				{
					ScanGun.Close();
				}
				ScanGun.Open();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		
		private String ReadData()
		{
			byte[] buffer = new byte[this.ScanGun.BytesToRead];
			this.ScanGun.Read(buffer, 0, buffer.Length);
			ScanGun.DiscardInBuffer();
			return Encoding.ASCII.GetString(buffer, 0, buffer.Length);

		}

		private void DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			Thread.Sleep(160);
			BarCode = ReadData().Replace("\r", String.Empty).Replace("\n", String.Empty);
			OnRspBarcode?.Invoke(BarCode);
		}
	}
}
