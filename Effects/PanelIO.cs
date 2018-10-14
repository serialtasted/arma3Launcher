using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Effects
{
    class PanelIO
    {
        private System.Timers.Timer effectInInner = new System.Timers.Timer() { Interval = 1 };
        private System.Timers.Timer effectOutInner = new System.Timers.Timer() { Interval = 1 };

        private System.Timers.Timer effectInOutter = new System.Timers.Timer() { Interval = 1 };
        private System.Timers.Timer effectOutOutter = new System.Timers.Timer() { Interval = 1 };

        private readonly Panel InnerPanelObject = null;
        private readonly Panel OutterPanelObject = null;

        private readonly int MaxInnerValue = 0;
        private readonly int MaxOutterValue = 0;

        private readonly int MinInnerValue = 0;
        private readonly int MinOutterValue = 0;

        private bool isSide = false;
        private bool isDual = false;

        private readonly int Increment = 0;

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
        public PanelIO(Panel innerPanelObject, int Increment, int MaxInnerValue, int MinInnerValue = 0)
        {
            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            this.InnerPanelObject = innerPanelObject;
            this.Increment = Increment;

            this.MaxInnerValue = MaxInnerValue;

            if (InnerPanelObject.Dock == DockStyle.Left || InnerPanelObject.Dock == DockStyle.Right)
                this.isSide = true;

            if (this.isSide)
                this.InnerPanelObject.Width = MinInnerValue;
            else
                this.InnerPanelObject.Height = MinInnerValue;
        }

        //-------------
        // DUAL PANEL
        //-------------
        public PanelIO(Panel InnerPanelObject, Panel OutterPanelObject, int Increment, int MaxInnerValue, int MaxOutterValue = 0, int MinInnerValue = 0, int MinOutterValue = 0)
        {
            effectInInner.Elapsed += EffectInInner_Tick;
            effectOutInner.Elapsed += EffectOutInner_Tick;

            effectInOutter.Elapsed += EffectInOutter_Tick;
            effectOutOutter.Elapsed += EffectOutOutter_Tick;

            this.InnerPanelObject = InnerPanelObject;
            this.OutterPanelObject = OutterPanelObject;
            this.Increment = Increment;

            this.MaxInnerValue = MaxInnerValue;

            if (MaxOutterValue > 0)
                this.MaxOutterValue = MaxOutterValue;
            else
                this.MaxOutterValue = MaxInnerValue;

            if (InnerPanelObject.Dock == DockStyle.Left || InnerPanelObject.Dock == DockStyle.Right)
                this.isSide = true;

            if (isSide)
            {
                this.InnerPanelObject.Width = MinInnerValue;
                this.OutterPanelObject.Width = MinOutterValue;
            }
            else
            {
                this.InnerPanelObject.Height = MinOutterValue;
                this.OutterPanelObject.Height = MinOutterValue;
            }
        }

        //-------------
        // ANIMATION HANDLE
        //-------------
        private void EffectInInner_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (InnerPanelObject.Width < MaxInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (InnerPanelObject.Width + Increment < MaxInnerValue)
                            setPanelWidth(InnerPanelObject, InnerPanelObject.Width + Increment);
                        else
                            setPanelWidth(InnerPanelObject, InnerPanelObject.Width + 1);
                    }
                    else
                    { setPanelWidth(InnerPanelObject, MaxInnerValue); }
                }
                else
                {
                    effectInInner.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
            else
            {
                if (InnerPanelObject.Height < MaxInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (InnerPanelObject.Height + Increment < MaxInnerValue)
                            setPanelHeight(InnerPanelObject, InnerPanelObject.Height + Increment);
                        else
                            setPanelHeight(InnerPanelObject, InnerPanelObject.Height + 1);
                    }
                    else
                    { setPanelHeight(InnerPanelObject, MaxInnerValue); }
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
                if (InnerPanelObject.Width > MinInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (InnerPanelObject.Width - Increment > MinInnerValue)
                            setPanelWidth(InnerPanelObject, InnerPanelObject.Width - Increment);
                        else
                            setPanelWidth(InnerPanelObject, InnerPanelObject.Width - 1);
                    }
                    else
                    { setPanelWidth(InnerPanelObject, MinInnerValue); }
                }
                else
                {
                    effectOutInner.Stop();

                    if (!this.isDual)
                    { GlobalVar.isAnimating = false; }
                }

                if ((Math.Round((double)(InnerPanelObject.Width)) / MaxOutterValue) * 100 < 10 && this.isDual)
                { effectOutOutter.Start(); }
            }
            else
            {
                if (InnerPanelObject.Height > MinInnerValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (InnerPanelObject.Height - Increment > MinInnerValue)
                            setPanelHeight(InnerPanelObject, InnerPanelObject.Height - Increment);
                        else
                            setPanelHeight(InnerPanelObject, InnerPanelObject.Height - 1);
                    }
                    else
                    { setPanelHeight(InnerPanelObject, MinInnerValue); }
                }
                else
                {
                    effectOutInner.Stop();

                    if (!this.isDual)
                    { GlobalVar.isAnimating = false; }
                }

                if ((Math.Round((double)(InnerPanelObject.Height)) / MaxOutterValue) * 100 < 10 && this.isDual)
                { effectOutOutter.Start(); }
            }
        }

        private void EffectInOutter_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (OutterPanelObject.Width < MaxOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (OutterPanelObject.Width + Increment < MaxOutterValue)
                            setPanelWidth(OutterPanelObject, OutterPanelObject.Width + Increment);
                        else
                            setPanelWidth(OutterPanelObject, OutterPanelObject.Width + 1);
                    }
                    else
                    { setPanelWidth(OutterPanelObject, MaxOutterValue); }
                }
                else
                { effectInOutter.Stop(); }
                if ((Math.Round((double)(OutterPanelObject.Width)) / MaxOutterValue) * 100 > 90)
                { effectInInner.Start(); }
            }
            else
            {
                if (OutterPanelObject.Height < MaxOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (OutterPanelObject.Height + Increment < MaxOutterValue)
                            setPanelHeight(OutterPanelObject, OutterPanelObject.Height + Increment);
                        else
                            setPanelHeight(OutterPanelObject, OutterPanelObject.Height + 1);
                    }
                    else
                    { setPanelHeight(OutterPanelObject, MaxOutterValue); }
                }
                else
                { effectInOutter.Stop(); }

                if ((Math.Round((double)(OutterPanelObject.Height)) / MaxOutterValue) * 100 > 90)
                { effectInInner.Start(); }
            }
        }

        private void EffectOutOutter_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (OutterPanelObject.Width > MinOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (OutterPanelObject.Width - Increment > MinOutterValue)
                            setPanelWidth(OutterPanelObject, OutterPanelObject.Width - Increment);
                        else
                            setPanelWidth(OutterPanelObject, OutterPanelObject.Width - 1);
                    }
                    else
                    { setPanelWidth(OutterPanelObject, MinOutterValue); }
                }
                else
                {
                    effectOutOutter.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
            else
            {
                if (OutterPanelObject.Height > MinOutterValue)
                {
                    if (!GlobalVar.disableAnimations)
                    {
                        if (OutterPanelObject.Height - Increment > MinOutterValue)
                            setPanelHeight(OutterPanelObject, OutterPanelObject.Height - Increment);
                        else
                            setPanelHeight(OutterPanelObject, OutterPanelObject.Height - 1);
                    }
                    else
                    { setPanelHeight(OutterPanelObject, MinOutterValue); }
                }
                else
                {
                    effectOutOutter.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
        }



        /// <summary>
        /// SHOW / HIDE Functions for panels
        /// </summary>
        public void ShowPanel()
        {
            GlobalVar.isAnimating = true;

            if (OutterPanelObject != null)
            { this.isDual = true; effectInOutter.Start(); }
            else
            { effectInInner.Start(); }
        }

        public void HidePanel()
        {
            GlobalVar.isAnimating = true;
            effectOutInner.Start();
        }
    }
}