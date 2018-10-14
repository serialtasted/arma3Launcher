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
