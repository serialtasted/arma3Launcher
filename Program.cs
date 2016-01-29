using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Workers;
using System.IO;

namespace arma3Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #if DEBUG
                GlobalVar.isDebug = true;
            #endif

            if (File.Exists("zUpdator.exe"))
                File.Delete("zUpdator.exe");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (args[0] == "-server") { GlobalVar.isServer = true; }
            }
            catch { }

            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.Run(new MainForm());

            SingleInstance.Stop();
        }
    }
}
