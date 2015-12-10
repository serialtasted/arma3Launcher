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
using CG.Web.MegaApiClient;
using System.Diagnostics;
using System.IO;

namespace arma3Launcher.Workers
{
    class Downloader
    {
        // controls
        private Windows7ProgressBar progressFile;
        private Windows7ProgressBar progressAll;
        private Label progressText;
        private Label progressDetails;
        private PictureBox launcherButton;
        private MegaApiClient megaClient;

        // forms
        private MainForm mainForm;

        // background workers
        private BackgroundWorker downloadFiles = new BackgroundWorker();
        
        // download stuff
        private Queue<string> downloadUrls = new Queue<string>();

        // folder paths
        private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";

        // paramters
        private bool isConfig = false;
        private bool isLaunch = false;

        // controllers
        private bool downloadRunning = false;
        private int totalDownloads = 0;
        private int parsedDownloads = 0;

        // error report
        private EmailReporter reportError;

        // converter
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024) / 1024;
        }

        // callbacks
        delegate void stringCallBack(string text);
        delegate void intCallBack(int number);

        // invokes
        private void progressStatusText(string text)
        {
            if (this.progressText.InvokeRequired)
            {
                stringCallBack d = new stringCallBack(progressStatusText);
                this.mainForm.Invoke(d, new object[] { text });
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
                stringCallBack d = new stringCallBack(progressDetailsText);
                this.mainForm.Invoke(d, new object[] { text });
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
                intCallBack d = new intCallBack(progressBarFileValue);
                this.mainForm.Invoke(d, new object[] { prbValue });
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
                intCallBack d = new intCallBack(progressBarAllValue);
                this.mainForm.Invoke(d, new object[] { prbValue });
            }
            else
            {
                this.progressAll.Value = prbValue;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainForm"></param>
        /// <param name="progressFile"></param>
        /// <param name="progressAll"></param>
        /// <param name="progressText"></param>
        /// <param name="progressDetails"></param>
        /// <param name="launcherButton"></param>
        public Downloader (MainForm mainForm, Windows7ProgressBar progressFile, Windows7ProgressBar progressAll, Label progressText, Label progressDetails, PictureBox launcherButton)
        {
            this.mainForm = mainForm;

            this.megaClient = new MegaApiClient();

            // construct error report
            this.reportError = new EmailReporter();

            // define controls
            this.progressFile = progressFile;
            this.progressAll = progressAll;
            this.progressText = progressText;
            this.progressDetails = progressDetails;
            this.launcherButton = launcherButton;

            // define background worker
            this.downloadFiles.DoWork += DownloadFiles_DoWork;
            this.downloadFiles.RunWorkerCompleted += DownloadFiles_RunWorkerCompleted;
        }

        /// <summary>
        /// Download background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            // specify the URL of the file to download
            var url = this.downloadUrls.Peek();

            // specify the output file name
            string outputFile = "ace.zip";

            // create output directory (if necessary)
            string outputFolder = this.TempFolder;
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // auxiliary variables
            string outputComplete = outputFolder + outputFile;
            string downloadSpeed = "";
            int progressPercentage = 0;


            // download the file and write it to disk
            using (Stream webStream = megaClient.Download(new Uri(url)))
            using (FileStream fileStream = new FileStream(outputComplete, FileMode.Create))
            {
                var buffer = new byte[32768];
                int bytesRead;
                Int64 bytesReadComplete = 0;  // use Int64 for files larger than 2 gb

                // get the size of the file to download
                Int64 bytesTotal = Convert.ToInt64(webStream.Length);

                // start a new StartWatch for measuring download time
                Stopwatch sw = Stopwatch.StartNew();

                // download file in chunks
                while ((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bytesReadComplete += bytesRead;
                    fileStream.Write(buffer, 0, bytesRead);

                    progressPercentage = Convert.ToInt32(((double)bytesReadComplete / bytesTotal) * 100);

                    if ((bytesReadComplete / 1024d / sw.Elapsed.TotalSeconds) > 999)
                        downloadSpeed = String.Format("{0:F1} mb/s", bytesReadComplete / 1048576d / sw.Elapsed.TotalSeconds);
                    else
                        downloadSpeed = String.Format("{0:F1} kb/s", bytesReadComplete / 1024d / sw.Elapsed.TotalSeconds);

                    progressBarFileValue(progressPercentage);
                    progressStatusText(String.Format("Downloading ({0:F0}/{1:F0}) {2}... {3:F0}%", this.parsedDownloads, this.totalDownloads, outputFile, progressPercentage));
                    progressDetailsText(String.Format("{0:0}MB of {1:0}MB / {2}", ConvertBytesToMegabytes(bytesReadComplete), ConvertBytesToMegabytes(bytesTotal), downloadSpeed));
                }

                sw.Stop();
            }
        }

        private void DownloadFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.downloadUrls.Dequeue();
            this.SaveDownloadQueue();

            this.parsedDownloads++;
            progressBarAllValue((this.parsedDownloads / this.totalDownloads) * 100);

            if (this.downloadUrls.Count > 0)
                this.downloadFiles.RunWorkerAsync();
            else
            {
                this.downloadRunning = false;
                this.megaClient.Logout();
                this.mainForm.runInstaller(this.isLaunch);
            }
        }

        /// <summary>
        /// Saves download queue to allow download resume after crash or failure
        /// </summary>
        public void SaveDownloadQueue()
        {
            if (this.downloadUrls.Count != 0)
            {
                string aux_downloadQueue = "";
                foreach (var item in this.downloadUrls)
                {
                    if (aux_downloadQueue == "")
                        aux_downloadQueue = item + ",";
                    else
                        aux_downloadQueue = aux_downloadQueue + item + ",";
                }
                Properties.Settings.Default.downloadQueue = aux_downloadQueue;
            }
            else
            { Properties.Settings.Default.downloadQueue = ""; }

            Properties.Settings.Default.Save();
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
        public void beginDownload(IEnumerable<string> urlsList, bool isConfig, bool isLaunch)
        {
            // lock controls
            this.launcherButton.Enabled = false;

            // report status
            this.progressStatusText("Connecting to the host...");

            // define paramters
            this.isConfig = isConfig;
            this.isLaunch = isLaunch;

            // define urls
            foreach (var url in urlsList)
            {
                this.downloadUrls.Enqueue(url);
            }

            // restart counters
            this.totalDownloads = downloadUrls.Count;
            this.parsedDownloads = 0;

            // begin download
            this.downloadRunning = true;
            this.megaClient.LoginAnonymous();
            this.downloadFiles.RunWorkerAsync();
        }
    }
}
