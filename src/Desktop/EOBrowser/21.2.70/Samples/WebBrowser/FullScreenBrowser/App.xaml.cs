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
        internal static object[] AssemblyAttributes { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //显示启动屏幕(设定宽高会自动缩放)
            //TransparentSplash.Instance.Width = 737;
            //TransparentSplash.Instance.Height = 361;
            TransparentSplash.SetBackgroundImage(FullScreenBrowser.Properties.Resources.SplashImage);
            TransparentSplash.BeginDisplay();

            //Get the main exe folder
            string exePath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            ExeDir = Path.GetDirectoryName(exePath);
            AssemblyAttributes = typeof(App).Assembly.GetCustomAttributes(false);

            #region Set default web engine options
            //Call this before any other code that uses EO.Wpf
            EO.Wpf.Runtime.AddLicense(FullScreenBrowser.Properties.Resources.L21);
            EO.WebBrowser.Runtime.AddLicense(FullScreenBrowser.Properties.Resources.L21);
            //Disable the automatic report
            EO.Base.Runtime.EnableCrashReport = false;
            //Handle CrashDataAvailable event
            EO.Base.Runtime.CrashDataAvailable += Runtime_CrashDataAvailable;
            //If your system has sufficient memory, please consider setting EO.Base.Runtime.EnableEOWP to true
            if (File.Exists(Path.Combine(ExeDir, "eowp.exe"))) EO.Base.Runtime.EnableEOWP = true;

            //Get default web engine options
            EngineOptions engine = EngineOptions.Default;
            SetWebEngineOptions(engine);
            EO.Wpf.Runtime.UICultureName = engine.UILanguage;
            EO.WebBrowser.Runtime.DefaultEngineOptions.UILanguage = engine.UILanguage;

            //Clean up cache folders for older versions
            Engine.CleanUpCacheFolders(CacheFolderCleanUpPolicy.OlderVersionOnly);

            Engine.Default.AllowRestart = true;
            System.Diagnostics.Debug.WriteLine(">> Default::Custom-UserAgent: " + engine.CustomUserAgent);
            #endregion

            // Set default web browser options
            // https://www.essentialobjects.com/doc/webbrowser/advanced/browser_options.aspx
            engine.SetDefaultBrowserOptions(GetBrowserOptions());

            //Startup main window
            MainWnd = new MainWindow();
            MainWnd.Show();
        }

        public static void SetWebEngineOptions(EngineOptions engine)
        {
            engine.UILanguage = "zh-CN";

            //Sets additional plugin directories
            //engine.AdditionalPluginsDirs = new string[] { Path.Combine(ExeDir, "plugins") };
            //By default will automatically load the built-in plug-ins (such as the built-in PDF plug-in)
            engine.DisableBuiltInPlugIns = false;

            //Sets the cache path
            //engine.CachePath = "";

            //Sets custom user agent
            engine.CustomUserAgent = FullScreenBrowser.Properties.Resources.UserAgent;

            //Sets a value to whether disable the built-in spell checker
            engine.DisableSpellChecker = true;
            //engine.SpellCheckLanguages = "";

            //Sets the additional command line arguments to be passed to the Chrome browser engine
            //engine.ExtraCommandLineArgs = "--disable-databases --disable-local-storage"; //Disable HTML 5 DB support and local storage

            //Sets the proxy information
            //engine.Proxy = new EO.Base.ProxyInfo(EO.Base.ProxyType.HTTP, "127.0.0.1", 12345);

            //Uncomment the following two lines to use eowp.exe.
            //See here for more details:
            //https://www.essentialobjects.com/doc/common/eowp.aspx
            //string eowpPath = Path.Combine(ExeDir, "FullScreenBrowserEOWP.exe");
            //EO.Base.Runtime.InitWorkerProcessExecutable(eowpPath);

            //Set remote debugging port. You only need this line if you
            //wish to use the remote debugging feature. You may need to
            //use a different port if this port is already in use on your system
            engine.RemoteDebugPort = 1234;
            //By default remote debugging only accepts connection from localhost.
            //Set this property to true allows you to connect to remote debugging server from another computer.
            //Do not use this option in actual production application
            //engine.RemoteDebugAnyAddress = true;

            //Uncomment this line to support proprietary media formats.
            //See here for more details:
            //https://www.essentialobjects.com/doc/webbrowser/advanced/html5.aspx
            engine.AllowProprietaryMediaFormats();

            engine.RegisterCustomSchemes(WebPageResourceHandler.UrlPrefix.Split(':')[0]);
        }

        public BrowserOptions GetBrowserOptions()
        {
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

            return options;
        }

        internal static void ShowError(Exception exception)
        {
            MainWnd.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(exception.Message, "异常", MessageBoxButton.OK, MessageBoxImage.Error)));
        }

        private void Runtime_CrashDataAvailable(object sender, EO.Base.CrashDataEventArgs e)
        {
            File.WriteAllBytes(Path.Combine(ExeDir, "crash.log"), e.Data);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
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
