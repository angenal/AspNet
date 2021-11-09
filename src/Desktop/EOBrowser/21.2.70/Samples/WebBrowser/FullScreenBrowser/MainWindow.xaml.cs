using System;
using System.Windows;

namespace FullScreenBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeWebBrowser();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window_Loaded();
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            Window_SourceInitialized();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; //取消关闭事件(Alt+F4)
        }
    }
}
