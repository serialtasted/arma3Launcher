using arma3Launcher.Effects;
using arma3Launcher.Workers;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Windows
{
    public partial class MessageBox : MaterialForm
    {
        private System.Timers.Timer animatedImage = new System.Timers.Timer();
        private WindowIO windowIO;
        private DialogResult holdResult;
        private Fonts customFont = new Fonts();

        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
        }

        public MessageBox()
        {
            InitializeComponent();
            windowIO = new WindowIO(this);
            animatedImage.Interval = 40;
            animatedImage.Elapsed += AnimatedImage_Elapsed;

            this.Message.Font = this.customFont.getFont(Properties.Fonts.ClearSans_Light, 9F, FontStyle.Regular);
        }

        private void MessageBox_Shown(object sender, EventArgs e)
        {
            windowIO.WindowIn();

            if (!GlobalVar.disableAnimations)
                animatedImage.Start();
        }

        private void MessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((string)this.Tag != "close")
            {
                holdResult = this.DialogResult;
                windowIO.WindowOut(true);
                e.Cancel = true;
            }
            else
            {
                this.DialogResult = holdResult;
                GC.Collect(2, GCCollectionMode.Forced);
                this.Dispose();
            }
        }

        public DialogResult Show(string Message)
        {
            this.Text = "";
            this.Message.Text = Message;
            diagImg.Image = Properties.MessageIcons.msg_info;

            // Material Skin properties
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Lime200, TextShade.WHITE);

            // Initialize buttons
            option_1.Text = "OK";
            option_1.DialogResult = DialogResult.OK;
            option_1.Visible = true;

            this.ShowDialog();
            return this.DialogResult;
        }

        public DialogResult Show(string Message, string Title)
        {
            this.Text = Title;
            this.Message.Text = Message;
            diagImg.Image = Properties.MessageIcons.msg_info;

            // Material Skin properties
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Lime200, TextShade.WHITE);

            // Initialize buttons
            option_1.Text = "OK";
            option_1.DialogResult = DialogResult.OK;
            option_1.Visible = true;

            this.ShowDialog();
            return this.DialogResult;
        }

        public DialogResult Show(string Message, string Title, MessageBoxButtons Buttons, MessageIcon Icon )
        {
            this.Text = Title;
            this.Message.Text = Message;
            Primary primeColor = Primary.LightGreen800;
            Primary darkThemeColor = Primary.LightGreen900;
            Primary lightThemeColor = Primary.LightGreen500;
            Accent accentColor = Accent.Lime200;

            // Initialize icon and set color for Form
            if (Icon == MessageIcon.None)
            {
                diagImg.Image = Properties.MessageIcons.msg_none;
            }
            else if (Icon == MessageIcon.Hand)
            {
                primeColor = Primary.Orange800;
                darkThemeColor = Primary.DeepOrange800;
                lightThemeColor = Primary.DeepOrange500;
                diagImg.Image = Properties.MessageIcons.msg_hand;
            }
            else if (Icon == MessageIcon.Question)
            {
                primeColor = Primary.Purple700;
                darkThemeColor = Primary.Purple800;
                lightThemeColor = Primary.Purple500;
                diagImg.Image = Properties.MessageIcons.msg_question;
            }
            else if (Icon == MessageIcon.Exclamation)
            {
                primeColor = Primary.Yellow800;
                darkThemeColor = Primary.Yellow900;
                lightThemeColor = Primary.Yellow500;
                diagImg.Image = Properties.MessageIcons.msg_exclamation;
            }
            else if (Icon == MessageIcon.Asterisk)
            { 
                primeColor = Primary.BlueGrey800;
                darkThemeColor = Primary.BlueGrey900;
                lightThemeColor = Primary.BlueGrey500;
                diagImg.Image = Properties.MessageIcons.msg_asterisk;
            }
            else if (Icon == MessageIcon.Stop)
            {
                primeColor = Primary.Red600;
                darkThemeColor = Primary.Red900;
                lightThemeColor = Primary.Red500;
                diagImg.Image = Properties.MessageIcons.msg_stop;
            }
            else if (Icon == MessageIcon.Error)
            {
                primeColor = Primary.Red600;
                darkThemeColor = Primary.Red900;
                lightThemeColor = Primary.Red500;
                diagImg.Image = Properties.MessageIcons.msg_error;
            }
            else if (Icon == MessageIcon.Warning)
            {
                primeColor = Primary.Orange800;
                darkThemeColor = Primary.DeepOrange800;
                lightThemeColor = Primary.DeepOrange500;
                diagImg.Image = Properties.MessageIcons.msg_warning;
            }
            else if (Icon == MessageIcon.Information)
            {
                primeColor = Primary.Blue800;
                darkThemeColor = Primary.Blue900;
                lightThemeColor = Primary.Blue500;
                diagImg.Image = Properties.MessageIcons.msg_info;
            }

            // Material Skin properties
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(primeColor, darkThemeColor, lightThemeColor, accentColor, TextShade.WHITE);

            // Initialize buttons
            switch (Buttons)
            {
                case MessageBoxButtons.OK:
                    option_1.Text = "OK";
                    option_1.DialogResult = DialogResult.OK;
                    option_1.Visible = true;
                    break;
                case MessageBoxButtons.OKCancel:
                    option_1.Text = "OK";
                    option_1.DialogResult = DialogResult.OK;
                    option_1.Visible = true;
                    option_2.Text = "Cancel";
                    option_2.DialogResult = DialogResult.Cancel;
                    option_2.Visible = true;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    option_1.Text = "Abort";
                    option_1.DialogResult = DialogResult.Abort;
                    option_1.Visible = true;
                    option_2.Text = "Retry";
                    option_2.DialogResult = DialogResult.Retry;
                    option_2.Visible = true;
                    option_3.Text = "Ignore";
                    option_3.DialogResult = DialogResult.Ignore;
                    option_3.Visible = true;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    option_1.Text = "Yes";
                    option_1.DialogResult = DialogResult.Yes;
                    option_1.Visible = true;
                    option_2.Text = "No";
                    option_2.DialogResult = DialogResult.No;
                    option_2.Visible = true;
                    option_3.Text = "Cancel";
                    option_3.DialogResult = DialogResult.Cancel;
                    option_3.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    option_1.Text = "Yes";
                    option_1.DialogResult = DialogResult.Yes;
                    option_1.Visible = true;
                    option_2.Text = "No";
                    option_2.DialogResult = DialogResult.No;
                    option_2.Visible = true;
                    break;
                case MessageBoxButtons.RetryCancel:
                    option_1.Text = "Retry";
                    option_1.DialogResult = DialogResult.Retry;
                    option_1.Visible = true;
                    option_2.Text = "Cancel";
                    option_2.DialogResult = DialogResult.Cancel;
                    option_2.Visible = true;
                    break;
            }

            this.ShowDialog();
            return this.DialogResult;
        }


        private bool goDown = true;
        private void AnimatedImage_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (diagImg.Location.Y == -20)
            { goDown = true; }
            else if (diagImg.Location.Y == 20)
            { goDown = false; }

            if (goDown)
            {
                if (diagImg.InvokeRequired)
                {
                    diagImg.Invoke(new MethodInvoker(delegate { diagImg.Location = new Point(diagImg.Location.X, diagImg.Location.Y + 1); }));
                }
                else
                {
                    diagImg.Location = new Point(diagImg.Location.X, diagImg.Location.Y + 1);
                }
            }
            else
            {
                if (diagImg.InvokeRequired)
                {
                    diagImg.Invoke(new MethodInvoker(delegate { diagImg.Location = new Point(diagImg.Location.X, diagImg.Location.Y - 1); }));
                }
                else
                {
                    diagImg.Location = new Point(diagImg.Location.X, diagImg.Location.Y - 1);
                }
            }
        }
    }
}
