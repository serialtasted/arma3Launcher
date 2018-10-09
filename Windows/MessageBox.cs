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
    public partial class MessageBox : MaterialForm
    {
        private System.Timers.Timer animatedImage = new System.Timers.Timer();
        private WindowIO windowIO;

        public MessageBox()
        {
            InitializeComponent();
            windowIO = new WindowIO(this);
            animatedImage.Interval = 40;
            animatedImage.Elapsed += AnimatedImage_Elapsed;
        }

        public DialogResult Show(string Message)
        {
            windowIO.windowIn();

            if (!GlobalVar.disableAnimations)
                animatedImage.Start();

            this.Text = "";
            this.Message.Text = Message;
            diagImg.Image = Properties.MessageIcons.msg_info;

            // Material Skin properties
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Lime200, TextShade.WHITE);

            // Initialize buttons
            option_1.Text = "OK";
            option_1.DialogResult = DialogResult.OK;
            option_1.Visible = true;

            this.ShowDialog();
            return this.DialogResult;
        }

        public DialogResult Show(string Message, string Title)
        {
            windowIO.windowIn();

            if (!GlobalVar.disableAnimations)
                animatedImage.Start();

            this.Text = Title;
            this.Message.Text = Message;
            diagImg.Image = Properties.MessageIcons.msg_info;

            // Material Skin properties
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Lime200, TextShade.WHITE);

            // Initialize buttons
            option_1.Text = "OK";
            option_1.DialogResult = DialogResult.OK;
            option_1.Visible = true;

            this.ShowDialog();
            return this.DialogResult;
        }

        public DialogResult Show(string Message, string Title, MessageBoxButtons Buttons, MessageIcon Icon )
        {
            windowIO.windowIn();

            if (!GlobalVar.disableAnimations)
                animatedImage.Start();

            this.Text = Title;
            this.Message.Text = Message;
            Primary primeColor = Primary.LightGreen800;
            Primary darkThemeColor = Primary.LightGreen900;
            Primary lightThemeColor = Primary.LightGreen500;
            Accent accentColor = Accent.Lime200;

            // Initialize icon and set color for Form
            if (Icon == MessageIcon.None)
            { }
            else if (Icon == MessageIcon.Hand)
            {
                diagImg.Image = Properties.MessageIcons.msg_hand;
            }
            else if (Icon == MessageIcon.Question)
            {
                primeColor = Primary.Blue800;
                darkThemeColor = Primary.Blue900;
                lightThemeColor = Primary.Blue500;
                diagImg.Image = Properties.MessageIcons.msg_question;
            }
            else if (Icon == MessageIcon.Exclamation)
            {
                diagImg.Image = Properties.MessageIcons.msg_exclamation;
            }
            else if (Icon == MessageIcon.Asterisk)
            {
                diagImg.Image = Properties.MessageIcons.msg_asterisk;
            }
            else if (Icon == MessageIcon.Stop)
            {
                primeColor = Primary.Red400;
                darkThemeColor = Primary.Red900;
                lightThemeColor = Primary.Red500;
                diagImg.Image = Properties.MessageIcons.msg_stop;
            }
            else if (Icon == MessageIcon.Error)
            {
                primeColor = Primary.Red400;
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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(primeColor, darkThemeColor, lightThemeColor, accentColor, TextShade.WHITE);

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

        private void MessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((string)this.Tag != "close")
            {
                windowIO.windowOut(true);
                e.Cancel = true;
            }
            else
            {
                GC.Collect(2, GCCollectionMode.Forced);
                this.Dispose();
            }
        }
    }
}
