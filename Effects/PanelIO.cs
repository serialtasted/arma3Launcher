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

        private int originalInnerHeight = 0;
        private int originalOutterHeight = 0;

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

            this.originalInnerHeight = this.innerPanelObject.Height;
            this.originalOutterHeight = this.outterPanelObject.Height;

            this.innerPanelObject.Height = 0;
            this.outterPanelObject.Height = 0;
        }

        public PanelIO(Panel innerPanelObject, Panel outterPanelObject, int originalInnerHeight, int originalOutterHeight, int velocity)
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

            this.originalInnerHeight = originalInnerHeight;
            this.originalOutterHeight = originalOutterHeight;

            this.innerPanelObject.Height = 0;
            this.outterPanelObject.Height = 0;
        }

        private void EffectInInner_Tick(object sender, EventArgs e)
        {
            if (innerPanelObject.Height < originalInnerHeight)
            {
                if (innerPanelObject.Height + velocity < originalInnerHeight)
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

        private void EffectOutInner_Tick(object sender, EventArgs e)
        {
            if (innerPanelObject.Height > 0)
            {
                if (innerPanelObject.Height - velocity > 0)
                    innerPanelObject.Height = innerPanelObject.Height - velocity;
                else
                    innerPanelObject.Height--;
            }
            else
            { effectOutInner.Stop(); }

            if (innerPanelObject.Height < 5)
            { effectOutOutter.Start(); }
        }

        private void EffectInOutter_Tick(object sender, EventArgs e)
        {
            if (outterPanelObject.Height < originalOutterHeight)
            {
                if (outterPanelObject.Height + velocity < originalOutterHeight)
                    outterPanelObject.Height = outterPanelObject.Height + velocity;
                else
                    outterPanelObject.Height++;
            }
            else
            { effectInOutter.Stop(); }

            if (Math.Round((double)(outterPanelObject.Height / originalOutterHeight) * 100) > 10)
            { effectInInner.Start(); }
        }

        private void EffectOutOutter_Tick(object sender, EventArgs e)
        {
            if (outterPanelObject.Height > 0)
            {
                if (outterPanelObject.Height - velocity > 0)
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
