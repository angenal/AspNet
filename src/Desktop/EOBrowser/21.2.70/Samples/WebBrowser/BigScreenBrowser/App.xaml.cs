using EO.WebEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using WindowsWPF.Controls;

namespace BigScreenBrowser
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        internal static Mutex mutex;
        internal static App Instance;
        internal static MainWindow MainWnd;
        internal static double Width, Height, Left, Top;
        internal static List<WebViewItemUrl> Urls;
        internal static Uri StartupUrl;
        internal static string[] StartupArgs;
        internal static DateTime StartupDateTime;
        internal static bool GridBackgroundUpdated;
        internal static object[] AssemblyAttributes;
        internal static string ExeDir;
        internal static int ExitCode;

        private string[] Init(string[] args)
        {
            if (args.Length == 1)
            {
                //自定义URL协议头
                string protocol = BigScreenBrowser.Properties.Resources.URLProtocol;
                if (args[0].StartsWith(protocol, StringComparison.OrdinalIgnoreCase) && Uri.TryCreate("http" + args[0].Substring(protocol.Length), UriKind.Absolute, out StartupUrl)) return new string[3] { StartupUrl.Authority, StartupUrl.AbsolutePath, StartupUrl.Query };
            }
            return args;
        }

        private void Application_Init(string[] args)
        {
            mutex = new Mutex(true, typeof(App).Assembly.GetName().Name, out bool createdNew);
            if (!createdNew)
            {
                var cp = Process.GetCurrentProcess();
                var ps = Process.GetProcessesByName(cp.ProcessName);
                var api = $"http://localhost:{BigScreenBrowser.Properties.Resources.HttpPort}/api/";
                foreach (Process pc in ps)
                {
                    if (pc.Id < 2 || pc.Id == cp.Id) continue;
                    if (StartupUrl == null || !StartupUrl.ToString().StartsWith(api, StringComparison.OrdinalIgnoreCase))
                    {
                        HttpRequest.Get($"{api}ShowApp");
                    }
                    else
                    {
                        HttpRequest.Get(StartupUrl.ToString());
                    }
                    // Activates the window and displays it in its current size and position.
                    //HotkeyRef.ShowWindow(pc.MainWindowHandle, 5);
                    //HotkeyRef.keybd_event((byte)System.Windows.Forms.Keys.LMenu, (byte)System.Windows.Forms.Keys.F11, 0x2, 0);
                    break;
                }
                Environment.Exit(0);
            }
            else
            {
                WebApi.Init();
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] args = Init(e.Args);
            Application_Init(args);
            StartupArgs = args;
            StartupDateTime = DateTime.Now;
            Instance = this;
            // Json Convert 驼峰命名(首字母小写)
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            //显示启动屏幕
            ShowSplash();

            //Get the main exe folder
            string exePath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            ExeDir = Path.GetDirectoryName(exePath);
            AssemblyAttributes = typeof(App).Assembly.GetCustomAttributes(false);

            #region Set default web engine options
            //Call this before any other code that uses EO.Wpf
            EO.Wpf.Runtime.AddLicense(BigScreenBrowser.Properties.Resources.L21);
            EO.WebBrowser.Runtime.AddLicense(BigScreenBrowser.Properties.Resources.L21);
            //Disable the automatic report
            EO.Base.Runtime.EnableCrashReport = false;
            //Handle CrashDataAvailable event
            EO.Base.Runtime.CrashDataAvailable += Runtime_CrashDataAvailable;
            //If your system has sufficient memory, please consider setting EO.Base.Runtime.EnableEOWP to true
            if (File.Exists(Path.Combine(ExeDir, "eowp.exe"))) EO.Base.Runtime.EnableEOWP = true;

            //Get default web engine options
            EngineOptions engine = EngineOptions.Default;//EO.WebBrowser.Runtime.DefaultEngineOptions
            SetWebEngineOptions(engine);
            EO.Wpf.Runtime.UICultureName = engine.UILanguage;
            EO.WebBrowser.Runtime.DefaultEngineOptions.UILanguage = engine.UILanguage;

            //Clean up cache folders for older versions
            Engine.CleanUpCacheFolders(CacheFolderCleanUpPolicy.OlderVersionOnly);

            Engine.Default.AllowRestart = true;
#if DEBUG
            Debug.WriteLine("");
            Debug.WriteLine(">> Browser::Custom-UserAgent: " + engine.CustomUserAgent);
            Debug.WriteLine("");
#endif
            #endregion

            // Set default web browser options
            // https://www.essentialobjects.com/doc/webbrowser/advanced/browser_options.aspx
            engine.SetDefaultBrowserOptions(GetBrowserOptions());

            //Startup main window
            Urls = new List<WebViewItemUrl>();
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
            //string ver = typeof(EO.WebBrowser.Runtime).Assembly.GetName().Version.ToString();
            //string path = Path.Combine(Path.GetTempPath(), "eo.webbrowser.cache." + ver);
            //engine.CachePath = path;

            //Sets custom user agent
            engine.CustomUserAgent = BigScreenBrowser.Properties.Resources.UserAgent;

            //Sets a value to whether disable the built-in spell checker
            engine.DisableSpellChecker = true;
            //engine.SpellCheckLanguages = "";

            //Sets the additional command line arguments to be passed to the Chrome browser engine
            //engine.ExtraCommandLineArgs = "--disable-databases --disable-local-storage"; //Disable HTML 5 DB support and local storage
            //engine.ExtraCommandLineArgs = "--disable-http2";

            //Sets the proxy information
            //engine.Proxy = new EO.Base.ProxyInfo(EO.Base.ProxyType.HTTP, "127.0.0.1", 12345);

            //Uncomment the following two lines to use eowp.exe.
            //See here for more details:
            //https://www.essentialobjects.com/doc/common/eowp.aspx
            //string eowpPath = Path.Combine(ExeDir, "FullScreenBrowserEOWP.exe");
            //EO.Base.Runtime.InitWorkerProcessExecutable(eowpPath);
#if DEBUG
            //Set remote debugging port. You only need this line if you
            //wish to use the remote debugging feature. You may need to
            //use a different port if this port is already in use on your system
            engine.RemoteDebugPort = 1234;
            //By default remote debugging only accepts connection from localhost.
            //Set this property to true allows you to connect to remote debugging server from another computer.
            //Do not use this option in actual production application
            //engine.RemoteDebugAnyAddress = true;
#endif
            //Uncomment this line to support proprietary media formats.
            //See here for more details:
            //https://www.essentialobjects.com/doc/webbrowser/advanced/html5.aspx
            engine.AllowProprietaryMediaFormats();
            //HTML5 Support proprietary media formats.
            Engine.Default.Options.AllowProprietaryMediaFormats();
            //Chrome command line starts arguments.
            Engine.Default.Options.ExtraCommandLineArgs = System.Windows.Commands.GetExtraCommandLineArgs(StartupArgs);

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
            //options.EnableXSSAuditor = false;
            //Sets a value indicating whether the browser engine should automatically load images.
            options.LoadImages = true;
            //Sets the additional style sheets to be applied to the document.
            //options.UserStyleSheet = "body { font-family: \"Microsoft Yahei\", Verdana, Arial, Helvetica, sans-serif !important;}";

            return options;
        }

        public void ShowSplash()
        {
            //显示启动屏幕(设定宽高会自动缩放)
            //TransparentSplash.Instance.Width = 737;
            //TransparentSplash.Instance.Height = 361;
            TransparentSplash.SetBackgroundImage(BigScreenBrowser.Properties.Resources.SplashImage);
            TransparentSplash.BeginDisplay();
        }

        public void HideSplash()
        {
            //关闭启动图
            Dispatcher.BeginInvoke(new Action(() => TransparentSplash.EndDisplay()));
        }

        internal static void Show(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal static void ShowError(Exception exception)
        {
            Instance.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(exception.Message, "异常", MessageBoxButton.OK, MessageBoxImage.Error)));
        }

        private void Runtime_CrashDataAvailable(object sender, EO.Base.CrashDataEventArgs e)
        {
            MainWnd.WebView_CrashDataAvailable(sender, e);
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
