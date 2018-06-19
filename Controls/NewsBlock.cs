using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace arma3Launcher.Controls
{
    public partial class NewsBlock : UserControl
    {
        public NewsBlock(string title, string content, string linktitle, string url, string label)
        {
            InitializeComponent();

            txt_title.Text = title;
            txt_content.Text = content;
            lnk_readmore.Text = linktitle;
            lnk_readmore.Tag = url;
            setlabel(label);

            setsize();
        }

        public NewsBlock(string title, string content, string label)
        {
            InitializeComponent();

            txt_title.Text = title;
            txt_content.Text = content;
            lnk_readmore.Visible = false;
            setlabel(label);

            setsize();
        }

        public NewsBlock(string title, string content, string label, string note)
        {
            InitializeComponent();

            txt_title.Text = title;
            txt_content.Text = content;
            lnk_readmore.Visible = false;
            txt_note.Visible = true;
            txt_note.Text = note;
            setlabel(label);
            setsize();
        }

        void setlabel(string label)
        {
            switch (label)
            {
                case "update":
                    //pic_badge.Image = Properties.Resources.bg_updav;
                    break;
                case "map":
                    //pic_badge.Image = Properties.Resources.bg_map;
                    break;
                case "launcher":
                    //pic_badge.Image = Properties.Resources.bg_launcher;
                    break;
                case "addon":
                    //pic_badge.Image = Properties.Resources.bg_addon;
                    break;
                case "wiki":
                    //pic_badge.Image = Properties.Resources.bg_wiki;
                    break;
                case "player":
                    //pic_badge.Image = Properties.Resources.bg_player;
                    break;
                case "mission":
                    //pic_badge.Image = Properties.Resources.bg_mission;
                    break;
                case "warning":
                    //this.BackgroundImage = Properties.Resources.bg_warning;
                    this.BackColor = Color.Maroon;
                    panel_bgTitle.Visible = false;
                    txt_content.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
                    txt_title.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
                    txt_title.ForeColor = Color.LightCoral;
                    txt_title.BackColor = Color.Transparent;
                    break;
                default:
                    pic_badge.Visible = false;
                    this.BackgroundImage = null;
                    break;
            }
        }

        private void lnk_readmore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                switch (lnk_readmore.Tag.ToString())
                {
                    case "goupdate":
                        //new Options().ShowDialog();
                        break;
                    default:
                        Process.Start(lnk_readmore.Tag.ToString());
                        break;
                }
            }
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 50;
        }
    }
}
