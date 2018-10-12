namespace arma3Launcher.Controls
{
    class DoubleBufferPanel : System.Windows.Forms.Panel
    {
        public DoubleBufferPanel()
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
