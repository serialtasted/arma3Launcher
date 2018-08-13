using System;
using System.Drawing;
using System.Windows.Forms;

namespace arma3Launcher.Effects
{
    class WindowIO
    {
        private Timer effectIn = new Timer();
        private Timer effectOut = new Timer();
        private Form formObject;
        private bool closeEnd = false;

        public WindowIO (Form formObject)
        {
            effectIn.Interval = 10;
            effectOut.Interval = 10;

            effectIn.Tick += EffectIn_Tick;
            effectOut.Tick += EffectOut_Tick;

            this.formObject = formObject;
            this.formObject.Opacity = 0;
        }

        private void EffectIn_Tick(object sender, EventArgs e)
        {
            if (formObject.Opacity < 1)
            {
                formObject.Opacity = formObject.Opacity + 0.1;
                formObject.Location = new Point(formObject.Location.X, formObject.Location.Y - 1);
            }
            else
            { effectIn.Stop(); }
        }

        private void EffectOut_Tick(object sender, EventArgs e)
        {
            if (formObject.Opacity > 0)
            {
                formObject.Opacity = formObject.Opacity - 0.1;
                formObject.Location = new Point(formObject.Location.X, formObject.Location.Y + 1);
            }
            else
            { effectOut.Stop(); if (closeEnd) { if (formObject != Application.OpenForms[0]) { formObject.Close(); } else { Application.Exit(); } } else { formObject.WindowState = FormWindowState.Minimized; } }
        }

        public void windowIn ()
        {
            effectIn.Start();
        }

        public void windowOut (bool closeEnd)
        {
            this.closeEnd = closeEnd;
            effectOut.Start();
        }
    }
}
