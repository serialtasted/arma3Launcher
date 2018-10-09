using System;
using System.Drawing;
using System.Windows.Forms;

namespace arma3Launcher.Effects
{
    class WindowIO
    {
        private System.Timers.Timer effectIn = new System.Timers.Timer();
        private System.Timers.Timer effectOut = new System.Timers.Timer();
        private Form formObject;
        private bool closeEnd = false;

        /// <summary>
        /// Invoke required controls for threading
        /// </summary>
        private void setWindowOpacity(Form control, double opacity)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.Opacity = opacity; }));
            }
            else
            {
                control.Opacity = opacity;
            }
        }

        private void setWindowLocation(Form control, int locationX, int locationY)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.Location = new Point(locationX, locationY); }));
            }
            else
            {
                control.Location = new Point(locationX, locationY);
            }
        }

        private void setWindowState(Form control, FormWindowState windowState)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.WindowState = windowState; }));
            }
            else
            {
                control.WindowState = windowState;
            }
        }

        public WindowIO (Form formObject)
        {
            effectIn.Interval = 10;
            effectOut.Interval = 10;

            effectIn.Elapsed += EffectIn_Tick;
            effectOut.Elapsed += EffectOut_Tick;

            this.formObject = formObject;
            this.formObject.Opacity = 0;
        }

        private void EffectIn_Tick(object sender, EventArgs e)
        {
            if (formObject.Opacity < 1)
            {
                setWindowOpacity(formObject, formObject.Opacity + 0.1);
                setWindowLocation(formObject, formObject.Location.X, formObject.Location.Y - 1);
            }
            else
            { effectIn.Stop(); }
        }

        private void EffectOut_Tick(object sender, EventArgs e)
        {
            if (formObject.Opacity > 0)
            {
                setWindowOpacity(formObject, formObject.Opacity - 0.1);
                setWindowLocation(formObject, formObject.Location.X, formObject.Location.Y + 1);
            }
            else
            {
                effectOut.Stop();
                if (closeEnd)
                {
                    if (formObject != Application.OpenForms[0])
                    {
                        if (formObject.InvokeRequired)
                        {
                            formObject.Invoke(new MethodInvoker(delegate {
                                formObject.Tag = "close";
                                formObject.Close();
                            }));
                        }
                        else
                        {
                            formObject.Tag = "close";
                            formObject.Close();
                        }
                    }
                    else { Application.Exit(); }
                }
                else { setWindowState(formObject, FormWindowState.Minimized); }
            }
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
