using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Controls;
using MaterialSkin.Controls;

namespace arma3Launcher.Workers
{
    class AddonsLooker
    {
        private readonly Fonts customFonts = new Fonts();

        public void getAddonsFlowPanel(DoubleBufferFlowPanel flowpanel_detectedAddons, string folderToLook, ContextMenuStrip contextMenu)
        {
            try
            {
                flowpanel_detectedAddons.Controls.Clear();
                int count = 0;

                DirectoryInfo addonDir = new DirectoryInfo(folderToLook);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                foreach (DirectoryInfo dir in addonDir.GetDirectories())
                {
                    if (dir.Name.StartsWith("@"))
                    {
                        MaterialCheckBox addonItem = new MaterialCheckBox
                        {
                            Text = dir.Name,
                            AutoSize = true,
                            ContextMenuStrip = contextMenu
                        };
                        flowpanel_detectedAddons.Controls.Add(addonItem);
                        count++;
                    }
                    else { continue; }
                }

                if (count == 0)
                {
                    Label error = new Label()
                    {
                        AutoSize = true,
                        ForeColor = Color.DimGray,
                        Font = customFonts.getFont(Properties.Fonts.Lato_Regular, 11F, FontStyle.Regular),
                        Text = "No addons found at:"
                    };

                    Label dir = new Label()
                    {
                        AutoSize = true,
                        ForeColor = Color.DimGray,
                        Font = customFonts.getFont(Properties.Fonts.ClearSans_Thin, 9.25F, FontStyle.Regular),
                        Margin = new Padding(10, 0, 0, 0),
                        Text = "⮡  " + folderToLook
                    };

                    flowpanel_detectedAddons.Controls.Add(error);
                    flowpanel_detectedAddons.Controls.Add(dir);
                }
            }
            catch
            {
                Label error = new Label()
                {
                    AutoSize = true,
                    ForeColor = Color.DimGray,
                    Font = customFonts.getFont(Properties.Fonts.Lato_Regular, 11F, FontStyle.Regular),
                    Text = "Optional Addons folder not defined!"
                };

                flowpanel_detectedAddons.Controls.Add(error);
            }
        }

        public void getAddonsCheckListBox(CheckedListBox lBox_detectedAddons, string folderToLook)
        {
            try
            {
                lBox_detectedAddons.Items.Clear();
                int count = 0;

                DirectoryInfo addonDir = new DirectoryInfo(folderToLook);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                foreach (DirectoryInfo dir in addonDir.GetDirectories())
                {
                    if (dir.Name.StartsWith("@")) { lBox_detectedAddons.Items.Add(dir.Name); count++; }
                    else { continue; }
                }

                if (count == 0)
                {
                    Label error = new Label()
                    {
                        AutoSize = true,
                        ForeColor = Color.DimGray,
                        Font = customFonts.getFont(Properties.Fonts.Lato_Regular, 11F, FontStyle.Regular),
                        Text = "No addons found at:"
                    };

                    Label dir = new Label()
                    {
                        AutoSize = true,
                        ForeColor = Color.DimGray,
                        Font = customFonts.getFont(Properties.Fonts.ClearSans_Thin, 9.25F, FontStyle.Regular),
                        Margin = new Padding(10, 0, 0, 0),
                        Text = "⮡  " + folderToLook
                    };

                    lBox_detectedAddons.Items.Add(error);
                    lBox_detectedAddons.Items.Add(dir);
                }
            }
            catch
            {
                Label error = new Label()
                {
                    AutoSize = true,
                    ForeColor = Color.DimGray,
                    Font = customFonts.getFont(Properties.Fonts.Lato_Regular, 11F, FontStyle.Regular),
                    Text = "Arma 3 folder not defined!"
                };

                lBox_detectedAddons.Items.Add(error);
            }
        }
    }
}
