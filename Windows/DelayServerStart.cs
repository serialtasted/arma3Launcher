using arma3Launcher.Effects;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Windows
{
    public partial class DelayServerStart : MaterialForm
    {
        private WindowIO windowIO;
        private Timer countdown = new Timer();
        private int countdownLimit = 10;
        private DialogResult holdResult;

        public DelayServerStart()
        {
            // Material Skin properties
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red400, Primary.Red900, Primary.Red500, Accent.Lime200, TextShade.WHITE);

            InitializeComponent();

            windowIO = new WindowIO(this);
            this.countdown.Interval = 1000;
            this.countdown.Tick += Countdown_Tick;
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            this.lbl_text.Text = "Engaging autopilot in " + this.countdownLimit + " seconds...";

            if (this.countdownLimit > 0)
            { this.countdownLimit--; }
            else
            {
                this.countdown.Stop();
                this.holdResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.countdown.Stop();
            this.holdResult = DialogResult.Abort;
            this.Close();
        }

        private void DelayServerStart_Shown(object sender, EventArgs e)
        {
            windowIO.windowIn();
            this.countdown.Start();
        }

        private void DelayServerStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((string)this.Tag != "close")
            {
                windowIO.windowOut(true);
                e.Cancel = true;
            }
            else
            {
                this.DialogResult = holdResult;
                GC.Collect(2, GCCollectionMode.Forced);
                this.Dispose();
            }
        }
    }
}
