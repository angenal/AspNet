using System;
using System.IO;
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
        private EO.WebBrowser.WebView m_WebView;
        private WebPage m_CurPage;
        private bool m_Forward = true;
        private int m_CurIndex = 0;
        private string tmpSaveFilename;
        private string tmpSaveFilePath;

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
            //Load the WebControl
            App.Left = Left; App.Top = Top;
            App.Width = grid.Width = grid.MaxWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            App.Height = grid.Height = grid.MaxHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            grid.Children.Add(NewWebViewItem(new EO.WebBrowser.WebView() { Url = m_HomeURL }));
            //下载默认目录
            tmpSaveFilePath = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), "Downloads");
            if (!Directory.Exists(tmpSaveFilePath)) tmpSaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists(tmpSaveFilePath)) App.ShowError(new Exception("没有权限访问“桌面”"));
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            //添加快捷键功能
            RegisterHotkey();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //显示或隐藏后
            //Topmost = (bool)e.NewValue;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
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
                if (altF1 != null) altF1.Dispose();
                if (altF2 != null) altF2.Dispose();
                if (altF5 != null) altF5.Dispose();
                if (altF11 != null) altF11.Dispose();
                if (altA != null) altA.Dispose();
                if (altQ != null) altQ.Dispose();
                if (altT != null) altT.Dispose();
                //保存访问历史
                //dockContainer.SaveLayout(m_LayoutFileName);
                //释放资源
                if (TransparentSplash.Instance != null) TransparentSplash.Instance.Dispose();
                m_WebView.Dispose();
                WebApi.Dispose();
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
