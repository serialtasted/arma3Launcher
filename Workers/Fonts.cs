using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace arma3Launcher.Workers
{
    class Fonts
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private static void LoadFont(string FontResourceName)
        {
            // receive resource stream
            Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(FontResourceName);

            //create an unsafe memory block for the data
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            //create a buffer to read in to
            Byte[] fontData = new Byte[fontStream.Length];
            //fetch the font program from the resource
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, (int)fontStream.Length);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

            //pass the font to the font collection
            GlobalVar.private_fonts.AddMemoryFont(data, (int)fontStream.Length);
            //close the resource stream
            fontStream.Close();
            //free the unsafe memory
            Marshal.FreeCoTaskMem(data);

        }


        private static void LoadFont(Byte[] fontData)
        {

            //create an unsafe memory block for the data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontData.Length);
            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, fontData.Length);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

            //pass the font to the font collection
            GlobalVar.private_fonts.AddMemoryFont(data, fontData.Length);
            //free the unsafe memory
            Marshal.FreeCoTaskMem(data);

        }

        public void InitFonts()
        {
            GlobalVar.fontsList.Clear();

            GlobalVar.fontsList.Add(Properties.Fonts.BebasNeue_Book);
            GlobalVar.fontsList.Add(Properties.Fonts.ClearSans_Light);
            GlobalVar.fontsList.Add(Properties.Fonts.ClearSans_Medium);
            GlobalVar.fontsList.Add(Properties.Fonts.ClearSans_Regular);
            GlobalVar.fontsList.Add(Properties.Fonts.ClearSans_Thin);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Black);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Hairline);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Heavy);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Light);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Medium);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Regular);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Semibold);
            GlobalVar.fontsList.Add(Properties.Fonts.Lato_Thin);

            foreach (byte[] item in GlobalVar.fontsList)
            {
                LoadFont(item);
            }
        }

        public Font getFont(Byte[] font, float size, FontStyle style)
        {
            int i = 0;

            foreach (byte[] item in GlobalVar.fontsList)
            {
                if (font.SequenceEqual(item))
                { i = GlobalVar.fontsList.IndexOf(item); break; }
            }

            Font _font = new Font(GlobalVar.private_fonts.Families[i], size, style, GraphicsUnit.Point, 0, true);

            return _font;
        }
    }
}
