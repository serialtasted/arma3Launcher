using System;
using System.Drawing;
using System.Windows.Forms;

namespace arma3Launcher.Effects
{
    class PanelIO
    {
        private Timer effectInInner = new Timer();
        private Timer effectOutInner = new Timer();

        private Timer effectInOutter = new Timer();
        private Timer effectOutOutter = new Timer();

        private Panel innerPanelObject;
        private Panel outterPanelObject;

        private int originalInnerValue = 0;
        private int originalOutterValue = 0;

        private int baseInnerValue = 0;
        private int baseOutterValue = 0;

        private bool isSide = false;

        private int velocity = 0;

        public PanelIO (Panel innerPanelObject, Panel outterPanelObject, int velocity)
        {
            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Tick += EffectInInner_Tick;
            effectOutInner.Tick += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Tick += EffectInOutter_Tick;
            effectOutOutter.Tick += EffectOutOutter_Tick;

            this.innerPanelObject = innerPanelObject;
            this.outterPanelObject = outterPanelObject;
            this.velocity = velocity;

            this.originalInnerValue = this.innerPanelObject.Height;
            this.originalOutterValue = this.outterPanelObject.Height;

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

        public PanelIO(Panel innerPanelObject, Panel outterPanelObject, int originalInnerValue, int originalOutterValue, int velocity)
        {
            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Tick += EffectInInner_Tick;
            effectOutInner.Tick += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Tick += EffectInOutter_Tick;
            effectOutOutter.Tick += EffectOutOutter_Tick;

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
            effectInInner.Interval = 1;
            effectOutInner.Interval = 1;

            effectInInner.Tick += EffectInInner_Tick;
            effectOutInner.Tick += EffectOutInner_Tick;

            effectInOutter.Interval = 1;
            effectOutOutter.Interval = 1;

            effectInOutter.Tick += EffectInOutter_Tick;
            effectOutOutter.Tick += EffectOutOutter_Tick;

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

        private void EffectInInner_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (innerPanelObject.Width < originalInnerValue)
                {
                    if (innerPanelObject.Width + velocity < originalInnerValue)
                        innerPanelObject.Width = innerPanelObject.Width + velocity;
                    else
                        innerPanelObject.Width++;
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
                    if (innerPanelObject.Height + velocity < originalInnerValue)
                        innerPanelObject.Height = innerPanelObject.Height + velocity;
                    else
                        innerPanelObject.Height++;
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
                    if (innerPanelObject.Width - velocity > baseInnerValue)
                        innerPanelObject.Width = innerPanelObject.Width - velocity;
                    else
                        innerPanelObject.Width--;
                }
                else
                { effectOutInner.Stop(); }

                if (innerPanelObject.Width < 5)
                { effectOutOutter.Start(); }
            }
            else
            {
                if (innerPanelObject.Height > baseInnerValue)
                {
                    if (innerPanelObject.Height - velocity > baseInnerValue)
                        innerPanelObject.Height = innerPanelObject.Height - velocity;
                    else
                        innerPanelObject.Height--;
                }
                else
                { effectOutInner.Stop(); }

                if (innerPanelObject.Height < 5)
                { effectOutOutter.Start(); }
            }
        }

        private void EffectInOutter_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (outterPanelObject.Width < originalOutterValue)
                {
                    if (outterPanelObject.Width + velocity < originalOutterValue)
                        outterPanelObject.Width = outterPanelObject.Width + velocity;
                    else
                        outterPanelObject.Width++;
                }
                else
                { effectInOutter.Stop(); }

                if (Math.Round((double)(outterPanelObject.Width / originalOutterValue) * 100) > 10)
                { effectInInner.Start(); }
            }
            else
            {
                if (outterPanelObject.Height < originalOutterValue)
                {
                    if (outterPanelObject.Height + velocity < originalOutterValue)
                        outterPanelObject.Height = outterPanelObject.Height + velocity;
                    else
                        outterPanelObject.Height++;
                }
                else
                { effectInOutter.Stop(); }

                if (Math.Round((double)(outterPanelObject.Height / originalOutterValue) * 100) > 10)
                { effectInInner.Start(); }
            }
        }

        private void EffectOutOutter_Tick(object sender, EventArgs e)
        {
            if (this.isSide)
            {
                if (outterPanelObject.Width > baseOutterValue)
                {
                    if (outterPanelObject.Width - velocity > baseOutterValue)
                        outterPanelObject.Width = outterPanelObject.Width - velocity;
                    else
                        outterPanelObject.Width--;
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
                    if (outterPanelObject.Height - velocity > baseOutterValue)
                        outterPanelObject.Height = outterPanelObject.Height - velocity;
                    else
                        outterPanelObject.Height--;
                }
                else
                {
                    effectOutOutter.Stop();
                    GlobalVar.isAnimating = false;
                }
            }
        }

        public void showPanel ()
        {
            GlobalVar.isAnimating = true;
            effectInOutter.Start();
        }

        public void hidePanel ()
        {
            GlobalVar.isAnimating = true;
            effectOutInner.Start();
        }
    }
}
