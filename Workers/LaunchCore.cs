using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace arma3Launcher.Workers
{
    class LaunchCore
    {
        private BackgroundWorker waitEndGame = new BackgroundWorker();
        private string GameFolder = Properties.Settings.Default.Arma3Folder;
        private string AddonsFolder = Properties.Settings.Default.AddonsFolder;
        private string TSFolder = Properties.Settings.Default.TS3Folder;
        private string Arguments = "";

        private Process auxProcess;
        private Form auxMainForm;
        private PictureBox auxLaunch;
        private Label auxStatus;

        public LaunchCore(bool noLogs,
            bool noPause,
            bool noSplash,
            bool noCB,
            bool enableHT,
            bool skipIntro,
            bool window,
            bool winxp,
            bool showScriptErrors,
            bool noBenchmark,
            bool world,
            string s_world,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool maxVRAM,
            string s_maxVRAM,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = AggregateArguments(noLogs, noPause, noSplash, noCB, enableHT, skipIntro, window, winxp,
                showScriptErrors, noBenchmark, world, s_world, maxMem, s_maxMem, malloc, s_malloc, maxVRAM, s_maxVRAM, exThreads, s_exThreads, cpuCount, s_cpuCount);

            if (auxCombinedArguments != "") Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);
        }

        public LaunchCore(bool noLogs, 
            bool noPause, 
            bool noSplash, 
            bool noCB, 
            bool enableHT, 
            bool skipIntro, 
            bool window, 
            bool winxp, 
            bool showScriptErrors, 
            bool noBenchmark,
            bool world,
            string s_world, 
            bool maxMem,
            string s_maxMem, 
            bool malloc,
            string s_malloc, 
            bool maxVRAM,
            string s_maxVRAM, 
            bool exThreads,
            string s_exThreads, 
            bool cpuCount,
            string s_cpuCount,
            bool jsrs,
            string s_jsrs,
            bool blastcore,
            string s_blastcore,
            ListBox activeAddons,
            List<string> modsList)
        {
            string auxCombinedArguments = AggregateArguments(noLogs, noPause, noSplash, noCB, enableHT, skipIntro, window, winxp, 
                showScriptErrors, noBenchmark, world, s_world, maxMem, s_maxMem, malloc, s_malloc, maxVRAM, s_maxVRAM, exThreads, s_exThreads, cpuCount, s_cpuCount);
            string auxCombinedAddons = "";
            string auxCoreMods = "-mod=\"";
            int i = 0;

            if (auxCombinedArguments != "") Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);

            if (jsrs)
                auxCombinedAddons = ";" + AddonsFolder + s_jsrs;

            if (blastcore)
                if (auxCombinedAddons != "")
                    auxCombinedAddons = auxCombinedAddons + ";" + AddonsFolder + s_blastcore;
                else
                    auxCombinedAddons = ";" + AddonsFolder + s_blastcore;

            //MessageBox.Show(s_modsFolder);

            if (activeAddons.Items.Count > 0 && activeAddons.Enabled)
            {
                do
                {
                    if (auxCombinedAddons != "") auxCombinedAddons = auxCombinedAddons + ";" + AddonsFolder + activeAddons.Items[i].ToString();
                    else auxCombinedAddons = ";" + AddonsFolder + activeAddons.Items[i].ToString();
                    i++;
                } while (i != activeAddons.Items.Count);
            }

            foreach (string mod in modsList)
            {
                if (mod != null)
                    if (auxCoreMods != "-mod=\"")
                        auxCoreMods = auxCoreMods + ";" + AddonsFolder + mod;
                    else
                        auxCoreMods = auxCoreMods + AddonsFolder + mod;
                else
                    break;
            }

            if (Arguments != "") Arguments = Arguments + " " + auxCoreMods + auxCombinedAddons + "\"";
            else Arguments = auxCoreMods + auxCombinedAddons;

            //MessageBox.Show(Arguments);
        }

        private string AggregateArguments(bool noLogs,
            bool noPause,
            bool noSplash,
            bool noCB,
            bool enableHT,
            bool skipIntro,
            bool window,
            bool winxp,
            bool showScriptErrors,
            bool noBenchmark,
            bool world,
            string s_world,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool maxVRAM,
            string s_maxVRAM,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = "";

            if (noLogs) auxCombinedArguments = auxCombinedArguments + "-noLogs ";
            if (noPause) auxCombinedArguments = auxCombinedArguments + "-noPause ";
            if (noSplash) auxCombinedArguments = auxCombinedArguments + "-noSplash ";
            if (noCB) auxCombinedArguments = auxCombinedArguments + "-noCB ";
            if (enableHT) auxCombinedArguments = auxCombinedArguments + "-enableHT ";
            if (skipIntro) auxCombinedArguments = auxCombinedArguments + "-skipIntro ";
            if (window) auxCombinedArguments = auxCombinedArguments + "-window ";
            if (winxp) auxCombinedArguments = auxCombinedArguments + "-winxp ";
            if (showScriptErrors) auxCombinedArguments = auxCombinedArguments + "-showScriptErrors ";
            if (noBenchmark) auxCombinedArguments = auxCombinedArguments + "-noBenchmark ";

            if (world && s_world != "") auxCombinedArguments = auxCombinedArguments + "-world=" + s_world + " ";
            if (maxMem && s_maxMem != "") auxCombinedArguments = auxCombinedArguments + "-maxMem=" + s_maxMem + " ";
            if (malloc && s_malloc != "") auxCombinedArguments = auxCombinedArguments + "-malloc=" + s_malloc + " ";
            if (maxVRAM && s_maxVRAM != "") auxCombinedArguments = auxCombinedArguments + "-maxVRAM=" + s_maxVRAM + " ";
            if (exThreads && s_exThreads != "") auxCombinedArguments = auxCombinedArguments + "-exThreads=" + s_exThreads + " ";
            if (cpuCount && s_cpuCount != "") auxCombinedArguments = auxCombinedArguments + "-cpuCount=" + s_cpuCount + " ";

            return auxCombinedArguments;
        }

        public string GetArguments()
        {
            return Arguments;
        }
        
        public bool isModPackInstalled(List<string> modsList, List<string> modsUrl)
        {
            bool aux_isAll = false;

            foreach (string mod in modsList)
            {
                if (mod != null)
                    foreach (string d in Directory.GetDirectories(AddonsFolder))
                    {
                        if (d.Contains(mod)) { aux_isAll = true; break; }
                        else { aux_isAll = false; continue; }
                    }
                else
                    break;

                if (!aux_isAll)
                    break;
            }

            if (aux_isAll && modsUrl.Count == 0) return true;
            else return false;
        }

        public void LaunchGame(string Arguments, Form mainForm, Label Status, PictureBox Launch, string[] serverInfo, string[] tsInfo, bool autoJoin)
        {
            /* 
            Array content list:
                serverInfo[0]: server ip
                serverInfo[1]: server port
                serverInfo[2]: server password

                tsInfo[0]: server ip
                tsInfo[1]: server port
                tsInfo[2]: server password
                tsInfo[3]: default channel
            */

            waitEndGame.WorkerSupportsCancellation = true;
            waitEndGame.WorkerReportsProgress = true;
            waitEndGame.DoWork += WaitEndGame_DoWork;
            waitEndGame.RunWorkerCompleted += WaitEndGame_RunWorkerCompleted;

            auxMainForm = mainForm;
            auxLaunch = Launch;
            auxStatus = Status;

            string aux_Arguments = "";
            Ping ping = new Ping();

            if ((serverInfo[0] != "" && serverInfo[2] != "") && autoJoin)
            {
                /*PingReply pingresult = ping.Send(serverInfo[0]);
                if (pingresult.Status == IPStatus.Success)
                {*/
                    if (serverInfo[2] != "")
                        aux_Arguments = "-connect=" + serverInfo[0] + " -port=" + serverInfo[1] + " -password=\"" + serverInfo[2] + "\" " + Arguments;
                    else
                        aux_Arguments = "-connect=" + serverInfo[0] + " -port=" + serverInfo[1] + " " + Arguments;
                /*}
                else
                {
                    aux_Arguments = Arguments;
                }*/
            }
            else
                aux_Arguments = Arguments;

            //Clipboard.SetText(aux_Arguments);

            if (Process.GetProcessesByName("ts3client_win64").Length <= 0 && Process.GetProcessesByName("ts3client_win32").Length <= 0)
            {
                if (Directory.Exists(TSFolder) && (File.Exists(TSFolder + "ts3client_win64.exe") || File.Exists(TSFolder + "ts3client_win32.exe")))
                {
                    try
                    {
                        var fass = new ProcessStartInfo();
                        fass.WorkingDirectory = TSFolder;

                        if (tsInfo[0] != "" && tsInfo[2] != "")
                            fass.Arguments = "ts3server://\"" + tsInfo[0] + "/?port=" + tsInfo[1] + "&channel=" + tsInfo[3] + "\"";
                        else if (tsInfo[0] != "")
                            fass.Arguments = "ts3server://\"" + tsInfo[0] + "/?port=" + tsInfo[1] + "&password=" + tsInfo[2] + "&channel=" + tsInfo[3] + "\"";

                        if (File.Exists(TSFolder + "ts3client_win64.exe"))
                            fass.FileName = "ts3client_win64.exe";

                        if (File.Exists(TSFolder + "ts3client_win32.exe"))
                            fass.FileName = "ts3client_win32.exe";

                        var process = new Process();
                        process.StartInfo = fass;

                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("TeamSpeak directory doesn't exist or executable not there. Please check your TeamSpeak directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Process[] pname = Process.GetProcessesByName("steam");
            if (pname.Length == 0)
            {
                try
                {
                    Status.Text = "Starting Steam...";

                    var fass = new ProcessStartInfo();
                    fass.WorkingDirectory = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString().Replace(@"/", @"\") + @"\";
                    fass.FileName = "steam.exe";
                    fass.Arguments = Arguments;

                    var process = new Process();
                    process.StartInfo = fass;
                    process.Start();
                    Thread.SpinWait(2000);
                    Thread.Sleep(2000);
                }
                catch { }
            }

            if (Directory.Exists(GameFolder) && File.Exists(GameFolder + "arma3battleye.exe"))
            {
                try
                {
                    var fass = new ProcessStartInfo();
                    fass.WorkingDirectory = GameFolder;
                    fass.FileName = "arma3battleye.exe";
                    fass.Arguments = "2 1 " + aux_Arguments;

                    var process = new Process();
                    process.StartInfo = fass;
                    auxProcess = process;
                    process.Start();

                    Thread.Sleep(500);

                    GC.Collect();

                    Status.Text = "Game running...";
                    Launch.Enabled = false;
                    mainForm.WindowState = FormWindowState.Minimized;
                    mainForm.Cursor = Cursors.Default;
                    waitEndGame.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Game directory doesn't exist or executable not there. Please check your Arma 3 directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Launch.Enabled = true;
            }
        }

        private void WaitEndGame_DoWork(object sender, DoWorkEventArgs e)
        {
            auxProcess.WaitForExit();
        }

        private void WaitEndGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            auxMainForm.WindowState = FormWindowState.Normal;
            auxMainForm.Focus();
            auxLaunch.Enabled = true;
            auxStatus.Text = "Waiting for orders...";
        }
    }
}
