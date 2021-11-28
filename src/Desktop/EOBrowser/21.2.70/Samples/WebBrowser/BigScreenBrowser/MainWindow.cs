using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
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
        private const int s_Index = 0;
        private int m_CurIndex = 0;
        private bool m_Forward = true;
        private bool m_Download = false;
        private bool m_LaunchUrl = false;
        private string m_SaveFilePath;

        /// <summary>
        /// Gets the notification message manager.
        /// </summary>
        public readonly NotificationManager notifier = new NotificationManager();

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
            //状态栏
            object a1 = App.AssemblyAttributes.FirstOrDefault(t => t is AssemblyProductAttribute);
            if (a1 != null) notifyIcon.ToolTipText = ((AssemblyProductAttribute)a1).Product;
            //窗体
            App.Left = Left; App.Top = Top;
            App.Width = grid.Width = grid.MaxWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            App.Height = grid.Height = grid.MaxHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //加载网页
            webPanel.Children.Add(NewWebViewItem(new EO.WebBrowser.WebView() { Url = m_HomeURL }));
            //下载默认目录
            m_SaveFilePath = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), "Downloads");
            if (!Directory.Exists(m_SaveFilePath)) m_SaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists(m_SaveFilePath)) App.ShowError(new Exception("没有权限访问“桌面”"));
            App.Instance.HideSplash(2000);
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            //添加快捷键功能
            RegisterHotkey();
        }

        private void Window_SetBackground()
        {
            //设置背景
            Times.Delay(1000);
            Style style = new Style(GetType());
            Setter setter = new Setter(BackgroundProperty, Brushes.Black);
            style.Setters.Add(setter);
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#FFFFFF"); //bc.ConvertFromString("White");
            brush.Freeze();
            grid.Background = brush;
            //webPanel.Background = Brushes.White;
            UpdateLayout();
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
                altF1?.Dispose();
                altF2?.Dispose();
                altF5?.Dispose();
                altF11?.Dispose();
                //altA?.Dispose();
                altQ?.Dispose();
                altT?.Dispose();
                //保存访问历史
                //dockwebPanel.SaveLayout(m_LayoutFileName);
                //释放资源
                TransparentSplash.Instance?.Dispose();
                notifyIcon?.Dispose();
                m_WebView?.Dispose();
                WebApi.Dispose();
            }
            catch (Exception ex)
            {
                App.ShowError(ex);
            }
            finally
            {
                //关闭
                //Close();
                //退出应用程序
                Environment.Exit(0);
            }
        }
    }
}
