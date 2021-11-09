using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using WindowsWPF.Controls;

namespace WPF.FullScreen
{
    /// <summary></summary>
    public partial class App : Application
    {
        internal static Mutex mutex;
        internal static App Instance;
        internal static int ExitCode;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mutex = new Mutex(true, typeof(App).Assembly.GetName().Name, out bool createdNew);
            if (!createdNew) Environment.Exit(0);
            Instance = this;

            DFoXDotNeBrowser.DFoX_DotNetBrowser.DFoXModificaMemoria();

            //Assembly assembly = Assembly.Load(FullScreen.Properties.Resources.DFoXDotNeBrowser);
            //var type = assembly.GetType("DFoXDotNeBrowser.DFoX_DotNetBrowser");
            //type.GetMethods().First().Invoke(null, new object[0]);
            //System.Diagnostics.Debug.WriteLine(">> Application Startup");
            //DispatcherUnhandledException += App_DispatcherUnhandledException;

            //显示启动屏幕(设定宽高会自动缩放)
            //Add the transparency splash image1
            //TransparentSplash.Instance.Width = 256;
            //TransparentSplash.Instance.Height = 256;
            //TransparentSplash.Instance.TextAreaX = 32;
            //TransparentSplash.Instance.TextAreaY = 96;
            //TransparentSplash.Instance.TextAreaWidth = 192;
            //TransparentSplash.Instance.TextAreaHeight = 64;
            //TransparentSplash.Instance.ForeColor = Color.White;
            //TransparentSplash.Instance.TransparencyColor = Color.Black;
            //TransparentSplash.SetBackgroundImage(FullScreen.Properties.Resources.SplashImage1);
            //TransparentSplash.SetTitleString("");

            //Add the transparency splash image2
            //TransparentSplash.Instance.Width = 530;
            //TransparentSplash.Instance.Height = 205;
            TransparentSplash.SetBackgroundImage(FullScreen.Properties.Resources.SplashImage2);

            TransparentSplash.BeginDisplay();
        }

        internal static void ShowError(Exception exception)
        {
            Instance.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(exception.Message, "异常", MessageBoxButton.OK, MessageBoxImage.Error)));
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ExitCode = 1;
            e.Handled = true;
            ShowError(e.Exception);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            e.ApplicationExitCode = ExitCode;
        }
    }
}
