using System.Windows.Forms;

namespace arma3Launcher.Controls
{
    class DoubleBufferFlowPanel : FlowLayoutPanel
    {
        protected override void OnScroll(ScrollEventArgs se)
        {
            if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                this.VerticalScroll.Value = se.NewValue;
            }
            else if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.HorizontalScroll.Value = se.NewValue;
            }
        }

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
