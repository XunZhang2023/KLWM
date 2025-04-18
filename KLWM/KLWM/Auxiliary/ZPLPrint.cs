using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace WinSDKDemo_ZPL
{
    public class ZPLPrint
    {
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern IntPtr PrinterCreator(ref IntPtr printer, string model);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ReleasePrinter(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int OpenPort(IntPtr intPtr, string port);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ClosePort(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int WriteData(IntPtr intPtr, byte[] buffer, int size);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int ListPrinters(IntPtr buffer, uint size, out uint needSize);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ReadDataTimeout(IntPtr intPtr, int timeout, IntPtr buffer, int size);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_StartFormat(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_EndFormat(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_Text(IntPtr intPtr, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_Pdf417(IntPtr intPtr, int xPos, int yPos, int orientation, int moduleWidth, int codeHeight, int securityLevel, int columns, int rows, char truncate, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_BarCode128(IntPtr intPtr, int xPos, int yPos, int orientation, int moduleWidth, int codeHeight, char line, char lineAboveCode, char checkDigit, char mode, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_QRCode(IntPtr intPtr, int xPos, int yPos, int orientation, int model, int dpi, char eccLevel, char input, char charMode, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_GraphicBox(IntPtr intPtr, int xPos, int yPos, int width, int height, int thickness, int rounding);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_PrintImage(IntPtr intPtr, int xPos, int yPos, string imgName);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_PrintConfigurationLabel(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_GetPrinterStatus(IntPtr intPtr, out int status);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidCalibration(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidWrite(IntPtr intPtr, char format, int begin, int size, char memoryBlock, String text);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidDefineFont(IntPtr intPtr, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidRead(IntPtr intPtr, char format, int begin, int size, char memoryBlock, int isPrint);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidSetPower(IntPtr intPtr, byte read, byte write);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidDefineEPC(IntPtr intPtr, IntPtr bits, int count);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_RfidSetParam(IntPtr intPtr, byte labelType, int pos, int len, int number, char err);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_Text_Block(IntPtr intPtr, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight, int textblockWidth, int textblockHeight, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ZPL_DataMatrixBarcode(IntPtr intPtr, int xPos, int yPos, int orientation, int codeHeight, int level, int columns, int rows, int formatId, int aspectRatio, string text);

        public delegate void MsgCallback(string message);

        private static string ParseStatus(int status)
        {
            if (status == 0)
            {
                return "Normal!";
            }
            else if ((status & 0b1) > 0)
            {
                return "Head opened!";
            }
            else if ((status & 0b10) > 0)
            {
                return "Paper jam!";
            }
            else if ((status & 0b100) > 0)
            {
                return "Out of paper!";
            }
            else if ((status & 0b1000) > 0)
            {
                return "Out of ribbon!";
            }
            else if ((status & 0b10000) > 0)
            {
                return "Pause!";
            }
            else if ((status & 0b100000) > 0)
            {
                return "Printing!";
            }
            else if ((status & 0b1000000) > 0)
            {
                return "Cover opened!";
            }
            else
            {
                return "Other error!";
            }
        }
        public static void GetStatus(IntPtr printer, MsgCallback callback)
        {
            int ret = ZPL_GetPrinterStatus(printer, out int status);
            if (ret == 0)
            {
                callback($"The printer status is {ParseStatus(status)}");
            }
            else
            {
                callback($"Get Error, Code is: {ret}");
            }
        }

        public static void PrintSample(IntPtr printer)
        {
            int xPos = 40;
            ZPL_StartFormat(printer);
            ZPL_Text(printer, xPos, 50, 13, 0, 59, 53, "FROM:");
            ZPL_Text(printer, 200, 40, 3, 0, 18, 30, "Company Name");
            ZPL_Text(printer, 200, 80, 3, 0, 18, 30, "Street, City");
            ZPL_Text(printer, 200, 120, 3, 0, 18, 30, "Phone");
            ZPL_GraphicBox(printer, xPos, 170, 500, 8, 4, 0);
            ZPL_Text(printer, xPos, 200, 13, 0, 59, 53, "SHIP TO:");
            ZPL_Text(printer, 200, 190, 3, 0, 18, 30, "Company Name");
            ZPL_Text(printer, 200, 230, 3, 0, 18, 30, "Street, City");
            ZPL_Text(printer, 200, 270, 3, 0, 18, 30, "Phone");
            ZPL_GraphicBox(printer, xPos, 320, 500, 8, 4, 0);
            ZPL_Text(printer, xPos, 340, 13, 0, 59, 53, "WEIGHT:");
            ZPL_Text(printer, 200, 340, 3, 0, 18, 30, "1kg/2,2lb");
            ZPL_BarCode128(printer, 80, 410, 0, 5, 150, 'Y', 'N', 'N', 'A', "12345678");
            ZPL_EndFormat(printer);
        }

        public static void PrintQRCode(IntPtr printer)
        {
            ZPL_StartFormat(printer);
            ZPL_QRCode(printer, 120, 5, 0, 2, 5, 'Q', '0', 'B', "Welcome to the world of printing!");
            ZPL_EndFormat(printer);
        }

        public static void PrintBarCode(IntPtr printer)
        {
            ZPL_StartFormat(printer);
            ZPL_BarCode128(printer, 120, 10, 0, 3, 80, 'Y', 'N', 'N', 'A', "123456");
            ZPL_EndFormat(printer);
        }

        public static void PrintImage(IntPtr printer, string path)
        {
            ZPL_StartFormat(printer);
            ZPL_PrintImage(printer, 120, 10, path);
            ZPL_EndFormat(printer);
        }

        public static void rfidCalibration(IntPtr printer)
        {
            ZPL_StartFormat(printer);
            ZPL_RfidCalibration(printer);
            ZPL_EndFormat(printer);
        }

        public static void rfidWrite(IntPtr printer)
        {
            ZPL_StartFormat(printer);
            ZPL_RfidWrite(printer, 'H', 2, 8, 'E', "9922834455665588");
            ZPL_EndFormat(printer);
        }

        public static void rfidRead(IntPtr printer, MsgCallback callback)
        {
            ZPL_StartFormat(printer);
            ZPL_RfidDefineFont(printer, 70, 100, 0, 'n', 40, 40);
            ZPL_RfidRead(printer, 'H', 2, 8, 'E', 1);
            ZPL_EndFormat(printer);
            IntPtr buffer = Marshal.AllocHGlobal(128);
            int len = ReadDataTimeout(printer, 10000, buffer, 128);
            if (len > 0)
            {
                byte[] buf = new byte[len];
                Marshal.Copy(buffer, buf, 0, len);
                StringBuilder hexString = new StringBuilder(len * 2);
                foreach (byte b in buf)
                {
                    hexString.AppendFormat("{0:X2}", b);
                }
                callback.Invoke(hexString.ToString());
            }
            else
            {
                callback.Invoke("RFID Read Err!");
            }
        }
    }
}
