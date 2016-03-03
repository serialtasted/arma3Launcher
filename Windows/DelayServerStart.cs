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
    public partial class DelayServerStart : Form
    {
        private Timer countdown = new Timer();
        private int countdownLimit = 10;

        public DelayServerStart()
        {
            InitializeComponent();
            this.countdown.Interval = 1000;
            this. countdown.Tick += Countdown_Tick;
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            this.txt_title.Text = "Engaging autopilot in " + this.countdownLimit + " seconds...";

            if(this.countdownLimit == 0)
            {
                this.countdown.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.countdownLimit--;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.countdown.Stop();
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void DelayServerStart_Shown(object sender, EventArgs e)
        {
            this.countdown.Start();
        }
    }
}
