using System;
using System.IO;
using System.Reflection;
using System.Windows;
using WindowsWPF.Controls;

namespace FullScreenBrowser
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        internal static int ExitCode;
        internal static MainWindow MainWnd;
        internal static string ExeDir { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //启动屏幕(设定宽高会自动缩放)
            //TransparentSplash.Instance.Width = 737;
            //TransparentSplash.Instance.Height = 361;
            TransparentSplash.SetBackgroundImage(FullScreenBrowser.Properties.Resources.SplashImage);
            TransparentSplash.BeginDisplay();

            //Set default options
            EO.Wpf.Runtime.AddLicense(FullScreenBrowser.Properties.Resources.L21);
            EO.WebBrowser.Runtime.AddLicense(FullScreenBrowser.Properties.Resources.L21);
            EO.WebEngine.EngineOptions options = EO.WebEngine.EngineOptions.Default;
            //Disable spell checker
            options.DisableSpellChecker = true;

            //Get the main exe folder
            string exePath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            ExeDir = Path.GetDirectoryName(exePath);

            //Uncomment the following two lines to use eowp.exe.
            //See here for more details:
            //https://www.essentialobjects.com/doc/common/eowp.aspx
            //string eowpPath = Path.Combine(ExeDir, "FullScreenBrowserEOWP.exe");
            //EO.Base.Runtime.InitWorkerProcessExecutable(eowpPath);

            //Clean up cache folders for older versions
            EO.WebEngine.Engine.CleanUpCacheFolders(EO.WebEngine.CacheFolderCleanUpPolicy.OlderVersionOnly);

            //Set remote debugging port. You only need this line if you
            //wish to use the remote debugging feature. You may need to
            //use a different port if this port is already in use on your system
            options.RemoteDebugPort = 1234;
            //options.CustomUserAgent = FullScreenBrowser.Properties.Resources.UserAgent;
            //System.Diagnostics.Debug.WriteLine(" >> Default::RemoteDebugPort: " + options.RemoteDebugPort);
            System.Diagnostics.Debug.WriteLine(" >> Default::Custom-UserAgent: " + options.CustomUserAgent);

            //By default remote debugging only accepts connection from localhost.
            //Set this property to true allows you to connect to remote debugging server from another computer.
            //Do not use this option in actual production application
            //options.RemoteDebugAnyAddress = true;

            //Uncomment this line to support proprietary media formats.
            //See here for more details:
            //https://www.essentialobjects.com/doc/webbrowser/advanced/html5.aspx
            //options.AllowProprietaryMediaFormats();

            MainWnd = new MainWindow();
            MainWnd.Show();
        }

        internal static void ShowError(Exception exception)
        {
            MainWnd.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(exception.Message, "异常", MessageBoxButton.OK, MessageBoxImage.Error)));
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ExitCode = 1;
            ShowError(e.Exception);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            e.ApplicationExitCode = ExitCode;
        }
    }
}
