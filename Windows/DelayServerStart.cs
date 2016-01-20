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
            countdown.Interval = 1000;
            countdown.Tick += Countdown_Tick;
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            txt_title.Text = "Engaging autopilot in " + countdownLimit + " seconds...";

            if(countdownLimit == 0)
            {
                countdown.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                countdownLimit--;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DelayServerStart_Shown(object sender, EventArgs e)
        {
            countdown.Start();
        }
    }
}
