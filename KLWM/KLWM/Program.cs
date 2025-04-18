using DevExpress.Skins;
using DevExpress.UserSkins;
using ProcessControlSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KLWM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ScanDriverContext.InitScanDriver();
            Application.Run(new frmMain());
        }
    }
}