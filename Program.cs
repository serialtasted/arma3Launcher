using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Workers;
using System.IO;
using System.Diagnostics;

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

            if (File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.Length - Process.GetCurrentProcess().MainModule.ModuleName.Length) + "zUpdator.exe"))
                File.Delete(Application.ExecutablePath.Remove(Application.ExecutablePath.Length - Process.GetCurrentProcess().MainModule.ModuleName.Length) + "zUpdator.exe");

            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (Properties.Settings.Default.isServerMode) { GlobalVar.isServer = true; }
            }
            catch { }

            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.Run(new MainForm2());

            SingleInstance.Stop();
        }
    }
}
