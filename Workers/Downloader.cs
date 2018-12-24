using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using arma3Launcher.Workers;
using arma3Launcher.Controls;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using MaterialSkin.Controls;

namespace arma3Launcher.Workers
{
    class Downloader
    {
        // belongs to something not important
        public int WM_SYSCOMMAND = 0x0112;
        public int SC_MONITORPOWER = 0xF170;

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        // controls
        private Windows7ProgressBar progressFile;
        private Windows7ProgressBar progressAll;
        private Label progressCurFile;
        private Label progressText;
        private Label progressDetails;
        private DoubleBufferFlowPanel flowpanelAddonPacks;
        private PictureBox cancelButton;
        private Installer installer;
        private System.Windows.Forms.Timer totalSw;
        private MaterialFlatButton repoValidateBtn;

        // forms
        private MainForm2 mainForm;

        // background workers
        private BackgroundWorker calculateFiles = new BackgroundWorker();
        private BackgroundWorker downloadFiles = new BackgroundWorker();
        
        // download stuff
        private Queue<string> downloadUrls = new Queue<string>();
        private IEnumerable<string> listUrls = new List<string>();

        // folder paths
        //private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";
        private string AddonsFolder = Properties.Settings.Default.AddonsFolder;

        // ftp url
        private string ftpAddress = Properties.GlobalValues.S_RepoAddress;

        // ftp
        private WebClient client = new WebClient();
        private NetworkCredential networkCredential = new NetworkCredential("anonymous", "anonymous@example.com");
        private FtpWebRequest ftpRequest;
        private FtpWebResponse ftpResponse;

        // paramters
        private bool isLaunch = false;

        // controllers
        private bool downloadRunning = false;
        private int totalDownloads = 0;
        private int parsedDownloads = 0;
        private Int64 parsedBytes;
        private Int64 totalBytes;
        private int numTimesCancel = 0;
        private int secondsElapsed = 0;
        private string timeLeft = string.Empty;
        private bool isTFR = false;
        private bool cancelProcess = false;

        // converter
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024) / 1024;
        }

        // callbacks
        delegate void stringCallBack(string text);
        delegate void intCallBack(int number);

        // invokes
        private void progressBarFileStyle(ProgressBarStyle prbStyle)
        {
            if (this.progressFile.InvokeRequired)
            {
                this.progressFile.Invoke(new MethodInvoker(delegate { this.progressFile.Style = prbStyle; }));
            }
            else
            {
                this.progressFile.Style = prbStyle;
            }
        }

        private void progressBarFileState(ProgressBarState prbState)
        {
            if (this.progressFile.InvokeRequired)
            {
                this.progressFile.Invoke(new MethodInvoker(delegate { this.progressFile.State = prbState; }));
            }
            else
            {
                this.progressFile.State = prbState;
            }
        }

        private void currentFileText(string text)
        {
            if (this.progressCurFile.InvokeRequired)
            {
                this.progressCurFile.Invoke(new MethodInvoker(delegate { this.progressCurFile.Text = text; }));
            }
            else
            {
                this.progressCurFile.Text = text;
            }
        }

        private void progressStatusText(string text)
        {
            if (this.progressText.InvokeRequired)
            {
                this.progressText.Invoke(new MethodInvoker(delegate { this.progressText.Text = text; }));
            }
            else
            {
                this.progressText.Text = text;
            }
        }

        private void progressDetailsText(string text)
        {
            if (this.progressDetails.InvokeRequired)
            {
                this.progressDetails.Invoke(new MethodInvoker(delegate { this.progressDetails.Text = text; }));
            }
            else
            {
                this.progressDetails.Text = text;
            }
        }

        private void progressBarFileValue(int prbValue)
        {
            if (this.progressFile.InvokeRequired)
            {
                this.progressFile.Invoke(new MethodInvoker(delegate { this.progressFile.Value = prbValue; }));
            }
            else
            {
                this.progressFile.Value = prbValue;
            }
        }

        private void progressBarAllValue(int prbValue)
        {
            if (this.progressAll.InvokeRequired)
            {
                this.progressAll.Invoke(new MethodInvoker(delegate { this.progressAll.Value = prbValue; }));
            }
            else
            {
                this.progressAll.Value = prbValue;
            }
        }

        /// <summary>
        /// Constructor for MainForm
        /// </summary>
        /// <param name="mainForm"></param>
        /// <param name="progressFile"></param>
        /// <param name="progressAll"></param>
        /// <param name="progressText"></param>
        /// <param name="progressDetails"></param>
        /// <param name="launcherButton"></param>
        public Downloader (MainForm2 mainForm, Installer installerWorker, Windows7ProgressBar progressFile, Windows7ProgressBar progressAll, Label progressCurFile, Label progressText, Label progressDetails, DoubleBufferFlowPanel flowpanelAddonPacks, PictureBox cancelButton, MaterialFlatButton repoValidateBtn)
        {
            this.mainForm = mainForm;
            this.installer = installerWorker;

            // define controls
            this.progressCurFile = progressCurFile;
            this.progressFile = progressFile;
            this.progressAll = progressAll;
            this.progressText = progressText;
            this.progressDetails = progressDetails;
            this.cancelButton = cancelButton;
            this.repoValidateBtn = repoValidateBtn;
            this.flowpanelAddonPacks = flowpanelAddonPacks;

            // define calculate worker
            this.calculateFiles.DoWork += CalculateFiles_DoWork;
            this.calculateFiles.RunWorkerCompleted += CalculateFiles_RunWorkerCompleted;
            this.calculateFiles.WorkerSupportsCancellation = true;

            // define download worker
            this.downloadFiles.DoWork += DownloadFiles_DoWork;
            this.downloadFiles.RunWorkerCompleted += DownloadFiles_RunWorkerCompleted;
            this.downloadFiles.WorkerSupportsCancellation = true;
        }

        private void CalculateFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.cancelProcess)
            { e.Cancel = true; return; }

            // reset variables
            this.parsedBytes = 0;
            this.totalBytes = 0;

            foreach (var url in listUrls)
            {
                if (this.cancelProcess)
                { e.Cancel = true; return; }

                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + url));
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                ftpRequest.Credentials = networkCredential;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                this.totalBytes += Convert.ToInt64(ftpResponse.ContentLength);
                ftpResponse.Close();
            }

            // create addons folder
            if (!Directory.Exists(AddonsFolder))
                Directory.CreateDirectory(AddonsFolder);

            // create needed folders
            this.progressStatusText("Preparing the environment...");
            if (GlobalVar.folders2Create.Count > 0)
            {
                foreach (string folder in GlobalVar.folders2Create)
                {
                    Directory.CreateDirectory(AddonsFolder + folder);
                    this.currentFileText("Creating needed folders (" + folder.Split('\\')[0] + ")");
                }
            }
        }

        private void CalculateFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.secondsElapsed = 0;

            this.totalSw.Start();
            this.downloadFiles.RunWorkerAsync();
        }
        
        /// <summary>
        /// Download background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.cancelProcess)
            { e.Cancel = true; return; }

            // specify the URL of the file to download
            string url = this.ftpAddress + this.downloadUrls.Peek().Replace('\\', '/');

            // specify the output file name
            int outputFileArraySize = this.downloadUrls.Peek().Split('\\').Length;
            string outputFile = this.downloadUrls.Peek().Split('\\')[outputFileArraySize - 1];

            // looks for tfr
            if (outputFile.Contains("task_force_radio"))
                this.isTFR = true;

            // auxiliary variables
            string outputComplete = AddonsFolder + this.downloadUrls.Peek();
            string downloadSpeed = string.Empty;
            int progressPercentage = 0;

            // ftp login
            client.Credentials = networkCredential;

            // get the size of the file to download
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
            ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            ftpRequest.Credentials = networkCredential;
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            Int64 bytesTotal = Convert.ToInt64(ftpResponse.ContentLength);
            ftpResponse.Close();

            // download the file and write it to disk
            using (Stream stream = client.OpenRead(new Uri(url)))
            using (FileStream file = new FileStream(outputComplete, FileMode.Create))
            {
                var buffer = new byte[32768];
                int bytesRead;
                Int64 bytesReadComplete = 0;  // use Int64 for files larger than 2 gb

                // start a new StartWatch for measuring download time
                Stopwatch sw = Stopwatch.StartNew();

                // download file in chunks
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    if (this.cancelProcess)
                    { e.Cancel = true; break; }

                    bytesReadComplete += bytesRead;
                    parsedBytes += bytesRead;
                    file.Write(buffer, 0, bytesRead);
                    

                    if ((bytesReadComplete / 1024d / sw.Elapsed.TotalSeconds) > 999)
                        downloadSpeed = String.Format("{0:F1} mb/s", bytesReadComplete / 1048576d / sw.Elapsed.TotalSeconds);
                    else
                        downloadSpeed = String.Format("{0:F1} kb/s", bytesReadComplete / 1024d / sw.Elapsed.TotalSeconds);

                    progressPercentage = Convert.ToInt32(((double)bytesReadComplete / bytesTotal) * 100);

                    this.progressBarFileStyle(ProgressBarStyle.Continuous);
                    this.progressBarFileValue(progressPercentage);
                    this.progressBarAllValue(Convert.ToInt32(((double)parsedBytes / totalBytes) * 100));
                    this.progressStatusText(String.Format("Downloading ({0:F0}/{1:F0}) {2}... {3:F0}%", this.parsedDownloads, this.totalDownloads, outputFile, progressPercentage));
                    this.progressDetailsText(String.Format("{0:0}MB of {1:0}MB / {2}", ConvertBytesToMegabytes(bytesReadComplete), ConvertBytesToMegabytes(bytesTotal), downloadSpeed));
                }

                sw.Stop();
            }
        }

        private async void DownloadFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                this.downloadUrls.Dequeue();

                if (this.parsedDownloads < this.totalDownloads)
                    this.parsedDownloads++;

                if (this.downloadUrls.Count > 0)
                    this.downloadFiles.RunWorkerAsync();
                else
                {
                    this.totalSw.Stop();

                    this.progressDetailsText("");
                    this.currentFileText("");

                    this.downloadRunning = false;
                    GlobalVar.isDownloading = false;

                    installer.beginInstall(this.isLaunch, this.isTFR);
                }
            }
            else
            {
                this.progressStatusText("Download cancelled");
                this.progressDetailsText("");
                this.currentFileText("");

                this.progressBarFileStyle(ProgressBarStyle.Continuous);

                this.progressBarAllValue(0);
                this.progressBarFileValue(0);

                this.downloadRunning = false;
                GlobalVar.isDownloading = false;

                foreach (PackBlock item in flowpanelAddonPacks.Controls)
                {
                    item.enablePlayButton();
                }
                this.repoValidateBtn.Enabled = true;
                try { this.cancelButton.Enabled = false; this.cancelButton.Image = Properties.Resources.cancel_circle_big_inactive; } catch { }

                await taskDelay(1500);
                if (numTimesCancel == 1)
                { this.progressStatusText("Waiting for orders"); }
                else if (numTimesCancel == 2)
                { this.progressStatusText("Do you want to download the addons or not?"); }
                else if (numTimesCancel == 3)
                { this.progressStatusText("This is the third time you cancel me.. Show some respect"); }
                else if (numTimesCancel == 4)
                { this.progressStatusText("I'm not enjoying this"); }
                else if (numTimesCancel == 5)
                { this.progressStatusText("Come on you child!"); }
                else if (numTimesCancel == 6)
                { this.progressStatusText("I quit.. Bye"); }
                else if (numTimesCancel >= 7 && numTimesCancel <= 9)
                { this.progressStatusText(""); }
                else if (numTimesCancel == 10)
                { this.progressStatusText("Next time I'll just close the launcher..."); }
                else if (numTimesCancel == 11)
                { this.progressStatusText("You don't belive me? What about shutting down your computer?"); }
                else if (numTimesCancel == 12)
                { this.progressStatusText("Alright I'm done with this... Do it just one more time, and you'll see."); }
                else if (numTimesCancel == 13)
                { SendMessage(mainForm.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2); await taskDelay(3500); SendMessage(mainForm.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, -1); this.progressStatusText("Scared?"); }
                else if (numTimesCancel == 14)
                { this.progressStatusText("Should we stop now? Or do I need to format your computer too?"); }
                else if (numTimesCancel == 15)
                { this.progressStatusText("Alright... Bye bye"); await taskDelay(2500); this.mainForm.Close(); }

                await taskDelay(2000);
                this.mainForm.HideDownloadPanel();
            }
        }

        /// <summary>
        /// Checks if there are downloads running
        /// </summary>
        /// <returns> downloadRunning </returns>
        public bool isDownloading()
        {
            return this.downloadRunning;
        }

        /// <summary>
        /// Enqueue link into an already active download queue
        /// </summary>
        /// <param name="urlLink"></param>
        public void enqueueUrl(string urlLink)
        {
            this.downloadUrls.Enqueue(urlLink);
            this.totalDownloads++;
        }

        /// <summary>
        /// Begins the process to download
        /// </summary>
        /// <param name="urlsList"></param>
        /// <param name="isConfig"></param>
        public void beginDownload(IEnumerable<string> listUrls, bool isLaunch)
        {
            // update addons folder
            this.AddonsFolder = Properties.Settings.Default.AddonsFolder;

            // reset cancel var
            this.cancelProcess = false;

            // show download panel
            this.mainForm.ShowDownloadPanel();

            // initialize timer
            this.totalSw = new System.Windows.Forms.Timer();
            this.totalSw.Interval = 1000;
            this.totalSw.Tick += TotalSw_Tick;

            // lock controls
            foreach (PackBlock item in flowpanelAddonPacks.Controls)
            {
                item.disablePlayButton();
            }
            this.repoValidateBtn.Enabled = false;

            // report status
            this.progressStatusText("Connecting to the host...");
            this.currentFileText("Download server: FTP");
            this.progressBarFileStyle(ProgressBarStyle.Marquee);

            // define paramters
            this.isLaunch = isLaunch;
            this.isTFR = false;

            // fill urls list
            this.listUrls = listUrls;

            // define urls
            foreach (var url in listUrls)
            {
                this.downloadUrls.Enqueue(url);
            }

            // restart counters
            this.totalDownloads = downloadUrls.Count;
            this.parsedDownloads = 1;

            // begin download
            this.downloadRunning = true;
            GlobalVar.isDownloading = true;
            this.calculateFiles.RunWorkerAsync();

            // show cancel button if possible
            try { this.cancelButton.Enabled = true; this.cancelButton.Image = Properties.Resources.cancel_circle_big_white; } catch { }
        }

        /// <summary>
        /// Timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TotalSw_Tick(object sender, EventArgs e)
        {
            Int64 secondsLeft = 0;
            secondsElapsed++;
            try { secondsLeft = Convert.ToInt64((this.secondsElapsed / (double)this.parsedBytes) * (this.totalBytes - (double)this.parsedBytes)); } catch { }

            this.currentFileText(String.Format("Estimated time left: {0:00}:{1:00}:{2:00} | Time elapsed: {3:00}:{4:00}:{5:00}", ((secondsLeft / 60) / 60), ((secondsLeft / 60) % 60), (secondsLeft % 60), ((this.secondsElapsed / 60) / 60), ((this.secondsElapsed / 60) % 60), (this.secondsElapsed % 60)));
        }

        /// <summary>
        /// Cancel download
        /// </summary>
        public void cancelDownload()
        {
            this.totalSw.Stop();
            this.numTimesCancel++;
            this.progressStatusText("Cancelling download...");
            this.progressDetailsText("");
            this.currentFileText("");

            this.progressBarAllValue(0);
            this.progressBarFileValue(0);
            this.progressBarFileStyle(ProgressBarStyle.Marquee);

            this.cancelProcess = true;
            this.client.CancelAsync();
            this.mainForm.ReadRepo(true);
        }

        /// <summary>
        /// Simple custom delay
        /// </summary>
        /// <param name="delayMs"></param>
        /// <returns></returns>
        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
        }
    }
}
