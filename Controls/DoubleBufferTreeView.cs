using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arma3Launcher.Controls
{
    class DoubleBufferTreeView : System.Windows.Forms.TreeView
    {
        public DoubleBufferTreeView()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true
            );
        }
    }
}
