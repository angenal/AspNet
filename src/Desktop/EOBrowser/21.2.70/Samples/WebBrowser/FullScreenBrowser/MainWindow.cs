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
        private static int m_HomeCommand = CommandIds.RegisterUserCommand("home");
        private ObservableCollection<DownloadItem> m_Downloads = new ObservableCollection<DownloadItem>();
        private ObservableCollection<WebPage> m_Pages = new ObservableCollection<WebPage>();
        private WebPage m_CurPage;
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
            //Load the DockView layout.
            dockContainer.LoadLayout(m_LayoutFileName);
            //If we do not have any page loaded, load an empty page
            if (m_WebViewsHost == null || !m_WebViewsHost.HasItems) dockContainer.ActivateItem(WebViewItemIdPrefix);
            //模板可视化
            panels.ApplyTemplate();
            //关闭启动屏幕
            TransparentSplash.EndDisplay();
        }

        private void Window_SourceInitialized()
        {
        }

        private void Window_Closing(System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
            try
            {
                //Save the docking view UI layout
                dockContainer.SaveLayout(m_LayoutFileName);
                //Release resources
                TransparentSplash.Instance.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统异常:" + ex.ToString());
            }
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (m_CurPage != null) m_CurPage.WebView.Print();
        }
    }
}
