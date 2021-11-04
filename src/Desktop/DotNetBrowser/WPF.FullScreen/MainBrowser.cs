namespace WPF.FullScreen
{
    /// <summary>
    /// Calling .NET from javaScript in browser main frame
    /// </summary>
    public class MainBrowser
    {
        private MainWindow window;

        /// <summary></summary>
        public MainBrowser(MainWindow window)
        {
            this.window = window;
        }

        /// <summary>
        /// 截图
        /// </summary>
        public void cut()
        {
            new WindowsWPF.Controls.ScreenCut().ShowDialog();
        }

        /// <summary>
        /// 询问关闭该应用程序
        /// </summary>
        public void close()
        {
            window.Window_ComfirmExit();
        }
        /// <summary>
        /// 直接退出该应用程序
        /// </summary>
        public void exit()
        {
            window.Window_Exit();
        }
    }
}
