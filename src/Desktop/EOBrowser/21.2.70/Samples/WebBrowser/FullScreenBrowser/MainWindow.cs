using EO.WebBrowser;
using EO.Wpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using WindowsWPF.Controls;

namespace FullScreenBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private const string WebViewItemIdPrefix = "WebView:";
        private static string m_LayoutFileName = "UILayout.xml";
        private static string m_HomeURL = Properties.Resources.URL;
        private ObservableCollection<DownloadItem> m_Downloads = new ObservableCollection<DownloadItem>();
        //private ObservableCollection<WebPage> m_Pages = new ObservableCollection<WebPage>();
        private WebPage m_CurPage;
        private EO.WebBrowser.WebView m_WebView;
        private ConsolePane m_ConsolePane;
        private DockView m_WebViewsHost;
        private DockView m_ToolViews;

        public void InitializeWebBrowser()
        {
            if (!File.Exists(m_LayoutFileName))
            {
                string dir = ((GuidAttribute)App.AssemblyAttributes.FirstOrDefault(t => t is GuidAttribute)).Value;
                dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), dir);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                m_LayoutFileName = Path.Combine(dir, "UILayout.xml");
            }
        }

        private void Window_Loaded()
        {
            if (string.IsNullOrWhiteSpace(m_HomeURL))
            {
                App.ShowError(new Exception("资源配置“首页网址”未找到！"));
                return;
            }
            //Load the DockView layout.
            dockContainer.LoadLayout(m_LayoutFileName);
            //If we do not have any page loaded, load an empty page
            if (m_WebViewsHost == null || !m_WebViewsHost.HasItems) dockContainer.ActivateItem(WebViewItemIdPrefix);
            //模板可视化
            panels.ApplyTemplate();
            //窗体一直置顶
            //SetTopMost();
        }

        private void Window_SourceInitialized()
        {
            //添加快捷键功能
            RegisterHotkey();
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //打印当前WebView
            if (m_WebView != null && !string.IsNullOrEmpty(m_WebView.Url)) m_WebView.Print();
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
                if (keyF6 != null) keyF6.Dispose();
                if (altA != null) altA.Dispose();
                if (altQ != null) altQ.Dispose();
                if (altT != null) altT.Dispose();
                //保存访问历史
                //dockContainer.SaveLayout(m_LayoutFileName);
                //释放资源
                if (TransparentSplash.Instance != null) TransparentSplash.Instance.Dispose();
                if (m_WebView != null) m_WebView.Dispose();
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
