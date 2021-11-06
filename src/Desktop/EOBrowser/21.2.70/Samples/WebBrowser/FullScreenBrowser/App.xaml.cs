using EO.WebEngine;
using System;
using System.IO;
using System.Reflection;
using System.Text;
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

            //Get the main exe folder
            string exePath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            ExeDir = Path.GetDirectoryName(exePath);

            #region Set default web engine options
            EO.Wpf.Runtime.AddLicense(FullScreenBrowser.Properties.Resources.L21);
            EO.WebBrowser.Runtime.AddLicense(FullScreenBrowser.Properties.Resources.L21);
            EngineOptions engine = EngineOptions.Default;
            //Sets additional plugin directories.
            //engine.AdditionalPluginsDirs = new string[] { Path.Combine(ExeDir, "plugins") };
            //Disable spell checker
            engine.DisableSpellChecker = true;

            //Uncomment the following two lines to use eowp.exe.
            //See here for more details:
            //https://www.essentialobjects.com/doc/common/eowp.aspx
            //string eowpPath = Path.Combine(ExeDir, "FullScreenBrowserEOWP.exe");
            //EO.Base.Runtime.InitWorkerProcessExecutable(eowpPath);

            //Clean up cache folders for older versions
            Engine.CleanUpCacheFolders(CacheFolderCleanUpPolicy.OlderVersionOnly);

            //Set remote debugging port. You only need this line if you
            //wish to use the remote debugging feature. You may need to
            //use a different port if this port is already in use on your system
            engine.RemoteDebugPort = 1234;
            //engine.CustomUserAgent = FullScreenBrowser.Properties.Resources.UserAgent;
            //System.Diagnostics.Debug.WriteLine(" >> Default::RemoteDebugPort: " + engine.RemoteDebugPort);
            System.Diagnostics.Debug.WriteLine(" >> Default::Custom-UserAgent: " + engine.CustomUserAgent);

            //By default remote debugging only accepts connection from localhost.
            //Set this property to true allows you to connect to remote debugging server from another computer.
            //Do not use this option in actual production application
            //engine.RemoteDebugAnyAddress = true;

            //Uncomment this line to support proprietary media formats.
            //See here for more details:
            //https://www.essentialobjects.com/doc/webbrowser/advanced/html5.aspx
            //engine.AllowProprietaryMediaFormats();
            #endregion

            #region Set default web browser options
            BrowserOptions options = new BrowserOptions();
            //Sets a value indicating whether JavaScript should be allowed.
            options.AllowJavaScript = true;
            //Sets a value indicating whether accessing clipboard from JavaScript should be allowed.
            options.AllowJavaScriptAccessClipboard = true;
            //Sets a value indicating whether using JavaScript to close a window that was not opened with JavaScript should be allowed.
            options.AllowJavaScriptCloseWindow = false;
            //Sets a value indicating whether pasting from clipboard is allowed.
            options.AllowJavaScriptDOMPaste = false;
            //Sets a value indicating whether any plug-in can be loaded.
            options.AllowPlugins = true;
            //Sets a value to determine whether user can use Ctrl + mouse wheel or +/- to zoom the current view.
            options.AllowZooming = false;
            //Sets the default page encoding.
            options.DefaultEncoding = Encoding.UTF8; // Encoding.GetEncoding("ISO-8859-1");
            //Sets a value indicating whether to enforce same-origin policy.
            //Default it does not allow JavaScript code from one site to access contents of a page from another site.
            options.EnableWebSecurity = false;
            //Sets a value indicating whether the browser engine should automatically load images.
            options.LoadImages = true;
            //Sets the additional style sheets to be applied to the document.
            //options.UserStyleSheet = "body { font-family: \"Microsoft Yahei\", Verdana, Arial, Helvetica, sans-serif !important;}";

            engine.SetDefaultBrowserOptions(options);
            #endregion

            //Startup main window
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
