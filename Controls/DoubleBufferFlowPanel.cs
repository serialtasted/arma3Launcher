using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arma3Launcher.Controls
{
    class DoubleBufferFlowPanel : System.Windows.Forms.FlowLayoutPanel
    {
        public DoubleBufferFlowPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true
            );
        }
    }
}
