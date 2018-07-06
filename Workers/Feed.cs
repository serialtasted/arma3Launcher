using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;

using arma3Launcher.Controls;
using System.Net;

namespace arma3Launcher.Workers
{
    class Feed
    {
        private FlowLayoutPanel gflowrss;
        private string gfsource;

        private string gtitle;
        private string glabel;

        public Feed(FlowLayoutPanel FeedPanel, string FeedSource)
        {
            gflowrss = FeedPanel;
            gfsource = FeedSource;
        }

        public void GetRSSNews()
        {
            try
            {
                gflowrss.Controls.Clear();

                int forCount = 0;
                bool warningactive = false;
                bool hidecontent = false;
                XDocument xdoc = XDocument.Load(gfsource);

                foreach (var feedxml in xdoc.Descendants("FeedItem"))
                {
                    try
                    {
                        warningactive = Convert.ToBoolean(feedxml.Element("Active").Value);
                        
                        if(warningactive)
                            hidecontent = Convert.ToBoolean(feedxml.Element("HideContent").Value);
                    }
                    catch
                    {
                        warningactive = false;
                    }

                    string title = feedxml.Element("Title").Value;
                    string content = feedxml.Element("Content").Value;
                    string linkname = feedxml.Element("LinkName").Value;
                    string linkuri = feedxml.Element("LinkUrl").Value;
                    string label = feedxml.Element("Label").Value;

                    if (forCount == 0 && !warningactive)
                    { forCount++; continue; }

                    if (!hidecontent || (forCount == 0 && warningactive))
                    {
                        if (linkname != string.Empty)
                            gflowrss.Controls.Add(new NewsBlock(title, content, linkname + " >", linkuri, label));
                        else
                            gflowrss.Controls.Add(new NewsBlock(title, content, label));
                    }

                    forCount++;
                }

                Label Maring = new Label();
                Maring.MaximumSize = new Size(595, 10);
                gflowrss.Controls.Add(Maring);
            }
            catch (Exception ex)
            {
                TableLayoutPanel ErrorTable = new TableLayoutPanel();
                ErrorTable.Size = new Size(gflowrss.Size.Width-10, gflowrss.Size.Height-15);
                //ErrorTable.BackColor = Color.Red;

                Label ErrorRead = new Label();
                ErrorRead.Anchor = AnchorStyles.None;
                ErrorRead.ForeColor = Color.White;
                ErrorRead.MinimumSize = new Size(595, 170);
                ErrorRead.Font = new Font("Calibri", 9, FontStyle.Bold);
                ErrorRead.TextAlign = ContentAlignment.BottomCenter;
                ErrorRead.Text = "Unable to read the contents from the server!\n" + ex.Message;

                Button RefreshContent = new Button();
                RefreshContent.Anchor = AnchorStyles.Top;
                RefreshContent.Size = new Size(90, 30);
                RefreshContent.TextAlign = ContentAlignment.MiddleRight;
                RefreshContent.Image = Properties.Resources.reload;
                RefreshContent.ImageAlign = ContentAlignment.MiddleLeft;
                RefreshContent.ForeColor = Color.FromArgb(64, 64, 64);
                RefreshContent.Text = "Reload";
                RefreshContent.Click += RefreshContent_Click;
                RefreshContent.Padding = new Padding(5, 0, 5, 0);

                ErrorTable.Controls.Add(ErrorRead);
                ErrorTable.Controls.Add(RefreshContent);

                gflowrss.Controls.Add(ErrorTable);
            }
        }

        void RefreshContent_Click(object sender, EventArgs e)
        {
            GetRSSNews();
        }
    }
}
