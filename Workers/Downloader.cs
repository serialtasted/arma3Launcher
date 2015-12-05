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

namespace arma3Launcher.Workers
{
    class Downloader
    {
        // controls
        private Windows7ProgressBar progressFile;
        private Windows7ProgressBar progressAll;
        private Label progressText;
        private Label progressDetails;
        private FtpClient ftpClient;

        // forms
        private MainForm mainForm;

        // background workers
        private BackgroundWorker downloadQueue;
        
        // download stuff
        private IEnumerable<string> urlsList;
        private bool isConfig;

        // error report
        private EmailReporter reportError;

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="progressFile"></param>
        /// <param name="progressAll"></param>
        /// <param name="progressText"></param>
        public Downloader (MainForm mainForm, Windows7ProgressBar progressFile, Windows7ProgressBar progressAll, Label progressText, Label progressDetails)
        {
            this.mainForm = mainForm;

            // construct error report
            reportError = new EmailReporter();

            // define controls
            this.progressFile = progressFile;
            this.progressAll = progressAll;
            this.progressText = progressText;

            // define ftp client
            this.ftpClient = new FtpClient();
            this.ftpClient.Username = Properties.GlobalValues.FTP_Username;
            this.ftpClient.Password = Properties.GlobalValues.FTP_Password;
            this.ftpClient.BinaryMode = true;
            this.ftpClient.Server = "spnlauncher.serveftp.com";

            // define background workers
            this.downloadQueue = new BackgroundWorker();
            this.downloadQueue.DoWork += DownloadQueue_DoWork;
            this.downloadQueue.RunWorkerCompleted += DownloadQueue_RunWorkerCompleted;
        }

        /// <summary>
        /// Define download queue process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadQueue_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            bool EndedWithError = false;

            do
            {
                try { this.ftpClient.Login(); break; }
                catch (Exception ex)
                {
                    if (ex.Message == "421")
                    {
                        progressStatusText("Download queue full. Retrying... ");
                        progressDetailsText("Attempts made: " + i);
                    }
                    else
                    {
                        progressStatusText(ex.Message);
                        this.reportError.sendReport("Ftp Exception\n\n" + ex.Message);
                        EndedWithError = true;
                        break;
                    }
                }

                i++;
                Thread.Sleep(10000);
            } while (true);

            if (EndedWithError)
                e.Cancel = true;
        }

        /// <summary>
        /// Define download queue after process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadQueue_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
                this.Download();
        }

        /// <summary>
        /// Begins the process to download
        /// </summary>
        /// <param name="urlsList"></param>
        /// <param name="isConfig"></param>
        public void beginDownload(IEnumerable<string> urlsList, bool isConfig)
        {
            // define paramters
            this.urlsList = urlsList;
            this.isConfig = isConfig;

            // determine if there's space for conection
            this.downloadQueue.RunWorkerAsync();
        }

        /// <summary>
        /// Download the files
        /// </summary>
        private void Download ()
        {
            
        }
    }
}
