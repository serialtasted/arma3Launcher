using System;
using System.Windows.Forms;
using arma3Launcher.Effects;
using arma3Launcher.Workers;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using arma3Launcher.Windows;
using System.Threading.Tasks;
using System.Drawing;

namespace arma3Launcher.Controls
{
    public partial class PackBlock : UserControl
    {
        private Timer effectIn = new Timer();

        private FlowLayoutPanel packsPan;
        private MainForm2 mainForm;

        private List<string> addonsName = new List<string>();
        private bool isOptionalAllowed = false;

        private PanelIO moreInfoPanelIO;
        private PanelIO packInfoPanelIO;

        private Fonts customFont = new Fonts();

        private int alpha = 255;
        private Random rnd = new Random();

        private string packID = string.Empty;

        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
        }

        /// <summary>
        /// Invoke required controls for threading
        /// </summary>
        private void setPanelVisibility(Panel control, bool visible)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.Visible = visible; }));
            }
            else
            {
                control.Visible = visible;
            }
        }

        private void setPanelWidth(Panel control, int width)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.Width = width; }));
            }
            else
            {
                control.Width = width;
            }
        }

        public async void fadeIn()
        {
            while (GlobalVar.isAnimating)
                await taskDelay(100);

            await taskDelay(rnd.Next(350, 700));
            effectIn.Interval = 7;
            effectIn.Tick += EffectIn_Tick;
            effectIn.Start();
        }

        private void EffectIn_Tick(object sender, EventArgs e)
        {
            if (panel_effectFade.BackColor.A > 0 && !GlobalVar.disableAnimations)
            {
                alpha = alpha - 5;
                int flash = rnd.Next(50, 150);
                this.panel_effectFade.BackColor = Color.FromArgb(alpha, flash + 10, flash + 20, flash);
            }
            else
            {
                setPanelVisibility(panel_effectFade, false);
                this.effectIn.Stop();

                if (flowpanel_packContent.VerticalScroll.Visible)
                {
                    setPanelWidth(flowpanel_packContent, flowpanel_packContent.Width + SystemInformation.VerticalScrollBarWidth);

                    if (scroll_packContent.InvokeRequired)
                    {
                        scroll_packContent.Invoke(new MethodInvoker(delegate
                        {
                            scroll_packContent.Visible = true;
                            scroll_packContent.Minimum = flowpanel_packContent.VerticalScroll.Minimum;
                            scroll_packContent.Maximum = flowpanel_packContent.VerticalScroll.Maximum;
                            scroll_packContent.LargeChange = flowpanel_packContent.VerticalScroll.LargeChange;
                        }));
                    }
                    else
                    {
                        scroll_packContent.Visible = true;
                        scroll_packContent.Minimum = flowpanel_packContent.VerticalScroll.Minimum;
                        scroll_packContent.Maximum = flowpanel_packContent.VerticalScroll.Maximum;
                        scroll_packContent.LargeChange = flowpanel_packContent.VerticalScroll.LargeChange;
                    }
                }

                this.moreInfoPanelIO.showPanelSingle();
            }
        }

        public PackBlock(MainForm2 mainForm, string packTitle, string packID, string packDescription, XmlDocument RemoteXmlInfo, FlowLayoutPanel packsPanel, bool isOptionalAllowed, List<string> addonsName)
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true
            );

            InitializeComponent();

            this.panel_effectFade.Size = new Size(410, 200);

            this.flowpanel_packContent.Controls.Clear();

            this.moreInfoPanelIO = new PanelIO(panel_moreInfo, 120, 33);
            this.packInfoPanelIO = new PanelIO(panel_packInfo, 410, 33);

            this.packsPan = packsPanel;
            this.txt_title.Text = packTitle;
            this.packID = packID;
            this.txt_content.Text = packDescription;
            this.mainForm = mainForm;

            this.isOptionalAllowed = isOptionalAllowed;
            this.addonsName = addonsName;

            txt_title.Font = customFont.getFont(Properties.Fonts.Lato_Semibold, 10F, FontStyle.Regular);
            lbl_packcontent.Font = customFont.getFont(Properties.Fonts.Lato_Semibold, 10F, FontStyle.Regular);
            txt_content.Font = customFont.getFont(Properties.Fonts.ClearSans_Light, 9F, FontStyle.Regular);

            foreach (string addonName in addonsName)
            {
                if (addonName != "@dummy")
                {
                    Label addon = new Label
                    {
                        AutoSize = true,
                        Text = addonName,
                        Font = customFont.getFont(Properties.Fonts.ClearSans_Light, 9F, FontStyle.Regular)
                    };
                    int bgColor = rnd.Next(60, 120);
                    addon.BackColor = Color.FromArgb(150, bgColor, bgColor, bgColor);

                    Padding margin = addon.Margin;
                    margin.Left = 0;
                    margin.Right = 0;
                    margin.Top = 0;
                    margin.Bottom = 3;
                    addon.Margin = margin;

                    this.flowpanel_packContent.Controls.Add(addon);
                }
            }

            if (packID == "arma3")
                btn_addonsOptionsClose.Visible = false;

            loadbackground(packID);

            if (isOptionalAllowed)
            {
                Label addon = new Label
                {
                    AutoSize = true,
                    Text = "✓ Optional addons allowed",
                    Font = customFont.getFont(Properties.Fonts.ClearSans_Light, 9F, FontStyle.Regular)
                };
                int bgColor = rnd.Next(60, 120);
                addon.BackColor = Color.FromArgb(150, bgColor, bgColor, bgColor);

                Padding margin = addon.Margin;
                margin.Left = 0;
                margin.Right = 0;
                margin.Top = 0;
                margin.Bottom = 3;
                addon.Margin = margin;

                this.flowpanel_packContent.Controls.Add(addon);
            }

            this.packInfoPanelIO.showPanelSingle();
        }

        public void disablePlayButton()
        {
            btn_playTop.Enabled = false;
            btn_playBot.Enabled = false;
            btn_playTop.Image = Properties.Resources.play_btn_disabled_top;
            btn_playBot.Image = Properties.Resources.play_btn_disabled_bot;
        }

        public void enablePlayButton()
        {
            btn_playTop.Enabled = true;
            btn_playBot.Enabled = true;
            btn_playTop.Image = Properties.Resources.play_btn_idle_top;
            btn_playBot.Image = Properties.Resources.play_btn_idle_bot;
        }

        private void loadbackground(string packID)
        {
            try
            {
                PictureBox panelBG = new PictureBox();
                panelBG.Load(Properties.GlobalValues.S_PackImgsDir + packID + ".jpg");
                panel_packImage.BackgroundImage = panelBG.Image;
            }
            catch { }
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 110;
        }

        private void btn_addonsOptionsClose_Click(object sender, EventArgs e)
        {
            this.packInfoPanelIO.hidePanelSingle();
        }

        private void btn_addonsOptionsClose_MouseEnter(object sender, EventArgs e)
        {
            this.btn_addonsOptionsClose.ForeColor = Color.Silver;
            this.btn_addonsOptionsClose.BackColor = Color.FromArgb(55, 55, 55);
        }

        private void btn_addonsOptionsClose_MouseLeave(object sender, EventArgs e)
        {
            this.btn_addonsOptionsClose.ForeColor = Color.WhiteSmoke;
            this.btn_addonsOptionsClose.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btn_addonsOptionsOpen_Click(object sender, EventArgs e)
        {
            this.packInfoPanelIO.showPanelSingle();
        }

        private void btn_addonsOptionsOpen_MouseEnter(object sender, EventArgs e)
        {
            this.btn_addonsOptionsOpen.ForeColor = Color.Silver;
            this.btn_addonsOptionsOpen.BackColor = Color.FromArgb(55, 55, 55);
        }

        private void btn_addonsOptionsOpen_MouseLeave(object sender, EventArgs e)
        {
            this.btn_addonsOptionsOpen.ForeColor = Color.WhiteSmoke;
            this.btn_addonsOptionsOpen.BackColor = Color.FromArgb(45, 45, 45);

        }

        private void flowpanel_packContent_Paint(object sender, PaintEventArgs e)
        {
            this.scroll_packContent.Value = this.flowpanel_packContent.AutoScrollPosition.Y * -1;
        }

        private void scroll_packContent_Scroll(object sender, ScrollEventArgs e)
        {
            this.flowpanel_packContent.Refresh();
            this.flowpanel_packContent.AutoScrollPosition = new Point(this.flowpanel_packContent.AutoScrollPosition.Y, e.NewValue);
        }

        private void btn_playBot_MouseEnter(object sender, EventArgs e)
        {
            if (btn_playBot.Enabled)
            {
                this.btn_playBot.Image = Properties.Resources.play_btn_hover_bot;
                this.btn_playTop.Image = Properties.Resources.play_btn_hover_top;
            }
        }

        private void btn_playTop_MouseEnter(object sender, EventArgs e)
        {
            if (btn_playBot.Enabled)
            {
                this.btn_playBot.Image = Properties.Resources.play_btn_hover_bot;
                this.btn_playTop.Image = Properties.Resources.play_btn_hover_top;
            }
        }

        private void btn_playBot_MouseLeave(object sender, EventArgs e)
        {
            if (btn_playBot.Enabled)
            {
                this.btn_playBot.Image = Properties.Resources.play_btn_idle_bot;
                this.btn_playTop.Image = Properties.Resources.play_btn_idle_top;
            }
        }

        private void btn_playTop_MouseLeave(object sender, EventArgs e)
        {
            if (btn_playBot.Enabled)
            {
                this.btn_playBot.Image = Properties.Resources.play_btn_idle_bot;
                this.btn_playTop.Image = Properties.Resources.play_btn_idle_top;
            }
        }

        private void panel_moreInfo_Paint(object sender, PaintEventArgs e)
        {
            if (!btn_playTop.Visible) { btn_playTop.Visible = true; }
            btn_playTop.Location = new Point(btn_playBot.Location.X, panel_moreInfo.Location.Y - btn_playTop.Height);
        }

        private void btn_playBot_Click(object sender, EventArgs e)
        {
            if (btn_playBot.Enabled)
            {
                playAction();
            }
        }

        private void btn_playTop_Click(object sender, EventArgs e)
        {
            if (btn_playBot.Enabled)
            {
                playAction();
            }
        }

        private void playAction()
        {
            Properties.Settings.Default.lastAddonPack = packID;
            Properties.Settings.Default.Save();
            this.mainForm.LaunchGame(false);
        }
    }
}
