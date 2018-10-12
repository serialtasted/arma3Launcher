using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Effects
{
    class PanelIO
    {
        private System.Timers.Timer effectInInner = new System.Timers.Timer();
        private System.Timers.Timer effectOutInner = new System.Timers.Timer();

        private System.Timers.Timer effectInOutter = new System.Timers.Timer();
        private System.Timers.Timer effectOutOutter = new System.Timers.Timer();

        private Panel innerPanelObject;
        private Panel outterPanelObject;

        private int originalInnerValue = 0;
        private int originalOutterValue = 0;

        private readonly int baseInnerValue = 0;
        private readonly int baseOutterValue = 0;

        private readonly bool isSide = false;
        private readonly bool isDual = false;

        private readonly int velocity = 0;

        private readonly Form form = null;

        /// <summary>
        /// Simple custom delay with fixed ammount
        /// </summary>
        /// <param name="delayMs"></param>
        /// <returns></returns>
        private async Task taskDelay()
        {
            await Task.Delay(250);
        }

        /// <summary>
        /// Invoke required controls for threading
        /// </summary>
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

        private void setPanelHeight(Panel control, int height)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.Height = height; }));
            }
            else
            {
                control.Height = height;
            }
        }


        //-------------
        // SINGLE PANEL
        //-------------
        public PanelIO(Panel innerPanelObject, int velocity)
        {
            this.isDual = false;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            this.innerPanelObject = innerPanelObject;
            this.velocity = velocity;

            this.baseInnerValue = 0;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.originalInnerValue = this.innerPanelObject.Width;

                this.innerPanelObject.Width = 0;
                this.isSide = true;
            }
            else
            {
                this.originalInnerValue = this.innerPanelObject.Height;

                this.innerPanelObject.Height = 0;
                this.isSide = false;
            }
        }

        public PanelIO(Panel innerPanelObject, Form form, int velocity)
        {
            this.isDual = false;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            this.innerPanelObject = innerPanelObject;
            this.velocity = velocity;
            this.form = form;

            this.baseInnerValue = 0;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.originalInnerValue = this.form.Width;

                this.innerPanelObject.Width = 0;
                this.isSide = true;
            }
            else
            {
                this.originalInnerValue = this.form.Height;

                this.innerPanelObject.Height = 0;
                this.isSide = false;
            }
        }

        public PanelIO(Panel innerPanelObject, int originalInnerValue, int velocity)
        {
            this.isDual = false;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            this.innerPanelObject = innerPanelObject;
            this.velocity = velocity;

            this.originalInnerValue = originalInnerValue;

            this.baseInnerValue = 0;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.innerPanelObject.Width = 0;
                this.isSide = true;
            }
            else
            {
                this.innerPanelObject.Height = 0;
                this.isSide = false;
            }
        }

        public PanelIO(Panel innerPanelObject, int originalInnerValue, int baseInnerValue, int velocity)
        {
            this.isDual = false;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            this.innerPanelObject = innerPanelObject;
            this.velocity = velocity;

            this.originalInnerValue = originalInnerValue;

            this.baseInnerValue = baseInnerValue;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.innerPanelObject.Width = baseInnerValue;
                this.isSide = true;
            }
            else
            {
                this.innerPanelObject.Height = baseInnerValue;
                this.isSide = false;
            }
        }

        //-------------
        // DUAL PANEL
        //-------------
        public PanelIO(Panel innerPanelObject, Panel outterPanelObject, int velocity)
        {
            this.isDual = true;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Elapsed += EffectInOutter_Tick;
            effectOutOutter.Elapsed += EffectOutOutter_Tick;

            this.innerPanelObject = innerPanelObject;
            this.outterPanelObject = outterPanelObject;
            this.velocity = velocity;

            this.baseInnerValue = 0;
            this.baseOutterValue = 0;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.originalInnerValue = this.innerPanelObject.Width;
                this.originalOutterValue = this.outterPanelObject.Width;

                this.innerPanelObject.Width = 0;
                this.outterPanelObject.Width = 0;
                this.isSide = true;
            }
            else
            {
                this.originalInnerValue = this.innerPanelObject.Height;
                this.originalOutterValue = this.outterPanelObject.Height;

                this.innerPanelObject.Height = 0;
                this.outterPanelObject.Height = 0;
                this.isSide = false;
            }
        }

        public PanelIO (Panel innerPanelObject, Panel outterPanelObject, Form form, int velocity)
        {
            this.isDual = true;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Elapsed += EffectInOutter_Tick;
            effectOutOutter.Elapsed += EffectOutOutter_Tick;

            this.innerPanelObject = innerPanelObject;
            this.outterPanelObject = outterPanelObject;
            this.velocity = velocity;
            this.form = form;

            this.baseInnerValue = 0;
            this.baseOutterValue = 0;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.originalInnerValue = this.form.Width;
                this.originalOutterValue = this.form.Width;

                this.innerPanelObject.Width = 0;
                this.outterPanelObject.Width = 0;
                this.isSide = true;
            }
            else
            {
                this.originalInnerValue = this.form.Height;
                this.originalOutterValue = this.form.Height;

                this.innerPanelObject.Height = 0;
                this.outterPanelObject.Height = 0;
                this.isSide = false;
            }
        }

        public PanelIO(Panel innerPanelObject, Panel outterPanelObject, int originalInnerValue, int originalOutterValue, int velocity)
        {
            this.isDual = true;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Elapsed += EffectInOutter_Tick;
            effectOutOutter.Elapsed += EffectOutOutter_Tick;

            this.innerPanelObject = innerPanelObject;
            this.outterPanelObject = outterPanelObject;
            this.velocity = velocity;

            this.originalInnerValue = originalInnerValue;
            this.originalOutterValue = originalOutterValue;

            this.baseInnerValue = 0;
            this.baseOutterValue = 0;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.innerPanelObject.Width = 0;
                this.outterPanelObject.Width = 0;
                this.isSide = true;
            }
            else
            {
                this.innerPanelObject.Height = 0;
                this.outterPanelObject.Height = 0;
                this.isSide = false;
            }
        }

        public PanelIO(Panel innerPanelObject, Panel outterPanelObject, int originalInnerValue, int originalOutterValue, int baseInnerValue, int baseOutterValue, int velocity)
        {
            this.isDual = true;

            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Elapsed += EffectInOutter_Tick;
            effectOutOutter.Elapsed += EffectOutOutter_Tick;

            this.innerPanelObject = innerPanelObject;
            this.outterPanelObject = outterPanelObject;
            this.velocity = velocity;

            this.originalInnerValue = originalInnerValue;
            this.originalOutterValue = originalOutterValue;

            this.baseInnerValue = baseInnerValue;
            this.baseOutterValue = baseOutterValue;

            if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
            {
                this.innerPanelObject.Width = baseInnerValue;
                this.outterPanelObject.Width = baseOutterValue;
                this.isSide = true;
            }
            else
            {
                this.innerPanelObject.Height = baseInnerValue;
                this.outterPanelObject.Height = baseOutterValue;
                this.isSide = false;
            }
        }

        //-------------
        // ANIMATION HANDLE
        //-------------
        private void EffectInInner_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (innerPanelObject.Width < originalInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (innerPanelObject.Width + velocity < originalInnerValue)
                            setPanelWidth(innerPanelObject, innerPanelObject.Width + velocity);
                        else
                            setPanelWidth(innerPanelObject, innerPanelObject.Width + 1);
                    }
                    else
                    { setPanelWidth(innerPanelObject, originalInnerValue); }
                }
                else
                {
                    effectInInner.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
            else
            {
                if (innerPanelObject.Height < originalInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (innerPanelObject.Height + velocity < originalInnerValue)
                            setPanelHeight(innerPanelObject, innerPanelObject.Height + velocity);
                        else
                            setPanelHeight(innerPanelObject, innerPanelObject.Height + 1);
                    }
                    else
                    { setPanelHeight(innerPanelObject, originalInnerValue); }
                }
                else
                {
                    effectInInner.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
        }

        private void EffectOutInner_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (innerPanelObject.Width > baseInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (innerPanelObject.Width - velocity > baseInnerValue)
                            setPanelWidth(innerPanelObject, innerPanelObject.Width - velocity);
                        else
                            setPanelWidth(innerPanelObject, innerPanelObject.Width - 1);
                    }
                    else
                    { setPanelWidth(innerPanelObject, baseInnerValue); }
                }
                else
                {
                    effectOutInner.Stop();

                    if (!this.isDual)
                    { GlobalVar.isAnimating = false; }
                }

                if ((Math.Round((double)(innerPanelObject.Width)) / originalOutterValue) * 100 < 10 && this.isDual)
                { effectOutOutter.Start(); }
            }
            else
            {
                if (innerPanelObject.Height > baseInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (innerPanelObject.Height - velocity > baseInnerValue)
                            setPanelHeight(innerPanelObject, innerPanelObject.Height - velocity);
                        else
                            setPanelHeight(innerPanelObject, innerPanelObject.Height - 1);
                    }
                    else
                    { setPanelHeight(innerPanelObject, baseInnerValue); }
                }
                else
                {
                    effectOutInner.Stop();

                    if (!this.isDual)
                    { GlobalVar.isAnimating = false; }
                }

                if ((Math.Round((double)(innerPanelObject.Height)) / originalOutterValue) * 100 < 10 && this.isDual)
                { effectOutOutter.Start(); }
            }
        }

        private void EffectInOutter_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (outterPanelObject.Width < originalOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (outterPanelObject.Width + velocity < originalOutterValue)
                            setPanelWidth(outterPanelObject, outterPanelObject.Width + velocity);
                        else
                            setPanelWidth(outterPanelObject, outterPanelObject.Width + 1);
                    }
                    else
                    { setPanelWidth(outterPanelObject, originalOutterValue); }
                }
                else
                { effectInOutter.Stop(); }
                if ((Math.Round((double)(outterPanelObject.Width)) / originalOutterValue) * 100 > 90)
                { effectInInner.Start(); }
            }
            else
            {
                if (outterPanelObject.Height < originalOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (outterPanelObject.Height + velocity < originalOutterValue)
                            setPanelHeight(outterPanelObject, outterPanelObject.Height + velocity);
                        else
                            setPanelHeight(outterPanelObject, outterPanelObject.Height + 1);
                    }
                    else
                    { setPanelHeight(outterPanelObject, originalOutterValue); }
                }
                else
                { effectInOutter.Stop(); }

                if ((Math.Round((double)(outterPanelObject.Height)) / originalOutterValue) * 100 > 90)
                { effectInInner.Start(); }
            }
        }

        private void EffectOutOutter_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (outterPanelObject.Width > baseOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (outterPanelObject.Width - velocity > baseOutterValue)
                            setPanelWidth(outterPanelObject, outterPanelObject.Width - velocity);
                        else
                            setPanelWidth(outterPanelObject, outterPanelObject.Width - 1);
                    }
                    else
                    { setPanelWidth(outterPanelObject, baseOutterValue); }
                }
                else
                {
                    effectOutOutter.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
            else
            {
                if (outterPanelObject.Height > baseOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (outterPanelObject.Height - velocity > baseOutterValue)
                            setPanelHeight(outterPanelObject, outterPanelObject.Height - velocity);
                        else
                            setPanelHeight(outterPanelObject, outterPanelObject.Height - 1);
                    }
                    else
                    { setPanelHeight(outterPanelObject, baseOutterValue); }
                }
                else
                {
                    effectOutOutter.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
        }



        /// <summary>
        /// SHOW / HIDE Functions for single panels
        /// </summary>
        public void ShowPanelSingle()
        {
            GlobalVar.isAnimating = true;

            if(form != null)
            {
                if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
                {
                    this.originalInnerValue = this.form.Width;
                }
                else
                {
                    this.originalInnerValue = this.form.Height;
                }
            }

            effectInInner.Start();
        }

        public void HidePanelSingle()
        {
            GlobalVar.isAnimating = true;
            effectOutInner.Start();
        }

        /// <summary>
        /// SHOW / HIDE Functions for dual panels
        /// </summary>
        public void ShowPanelDual ()
        {
            GlobalVar.isAnimating = true;

            if (form != null)
            {
                if (innerPanelObject.Dock == DockStyle.Left || innerPanelObject.Dock == DockStyle.Right)
                {
                    this.originalInnerValue = this.form.Width;
                    this.originalOutterValue = this.form.Width;
                }
                else
                {
                    this.originalInnerValue = this.form.Height;
                    this.originalOutterValue = this.form.Height;
                }
            }

            effectInOutter.Start();
        }

        public void HidePanelDual ()
        {
            GlobalVar.isAnimating = true;
            effectOutInner.Start();
        }
    }
}
