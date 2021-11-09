using System;
using System.Windows;
using WindowsWPF.Controls;

namespace BigScreenBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private const string WebViewItemIdPrefix = "WebView:";
        private static string m_HomeURL = Properties.Resources.URL;
        private WebPage m_CurPage;

        public void InitializeWebBrowser()
        {
            if (string.IsNullOrWhiteSpace(m_HomeURL))
            {
                App.ShowError(new Exception("资源配置“首页网址”未找到！"));
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //彻底去除关闭按钮
            RemoveCloseButton();
            //窗体一直置顶
            //SetTopMost();
            EO.WebBrowser.WebView webView = new EO.WebBrowser.WebView() { Url = m_HomeURL };
            var item = NewWebViewItem(webView);
            //Load the WebControl into this window
            Content = item.Page.WebControl;
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            //添加快捷键功能
            RegisterHotkey();
        }

        //private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    //打印当前WebView
        //    var m_WebView = m_CurPage.WebView;
        //    if (!string.IsNullOrEmpty(m_WebView.Url)) m_WebView.Print();
        //}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; //取消关闭事件(Alt+F4)
        }

        /// <summary>
        /// 询问关闭该应用程序
        /// </summary>
        public void Window_ComfirmExit()
        {
            if (m_Window_ComfirmExit) return;
            m_Window_ComfirmExit = true;
            MessageBoxResult result = MessageBox.Show(this, "是否退出该应用程序？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            m_Window_ComfirmExit = false;
            if (result == MessageBoxResult.Yes) Window_Exit();
        }
        private bool m_Window_ComfirmExit = false;

        /// <summary>
        /// 退出该应用程序时，释放系统资源。
        /// </summary>
        public void Window_Exit()
        {
            try
            {
                //隐藏
                Hide();
                //注销快捷键
                if (altA != null) altA.Dispose();
                if (altQ != null) altQ.Dispose();
                //保存访问历史
                //dockContainer.SaveLayout(m_LayoutFileName);
                //释放资源
                if (TransparentSplash.Instance != null) TransparentSplash.Instance.Dispose();
                m_CurPage.WebView.Dispose();
            }
            catch (Exception ex)
            {
                App.ShowError(ex);
            }
            finally
            {
                //关闭
                Close();
                //退出应用程序
                Environment.Exit(0);
            }
        }
    }
}
