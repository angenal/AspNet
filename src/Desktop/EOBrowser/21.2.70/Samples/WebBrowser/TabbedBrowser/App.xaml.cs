using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ExeDir { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            Wpf.Runtime.AddLicense(EO.Licenses.V21x);
            WebBrowser.Runtime.AddLicense(EO.Licenses.V21x);

            //Get the main exe folder
            string exePath = Assembly.GetExecutingAssembly().GetName().CodeBase;
            exePath = new Uri(exePath).LocalPath;
            ExeDir = Path.GetDirectoryName(exePath);

            //Uncomment the following two lines to use eowp.exe. See here for
            //more details:
            //https://www.essentialobjects.com/doc/common/eowp.aspx
            //string eowpPath = Path.Combine(ExeDir, "TabbedBrowserEOWP.exe");
            //EO.Base.Runtime.InitWorkerProcessExecutable(eowpPath);

            //Clean up cache folders for older versions
            EO.WebEngine.Engine.CleanUpCacheFolders(WebEngine.CacheFolderCleanUpPolicy.OlderVersionOnly);

            //Set remote debugging port. You only need this line if you
            //wish to use the remote debugging feature. You may need to
            //use a different port if this port is already in use on your
            //system
            EO.WebEngine.EngineOptions.Default.RemoteDebugPort = 1234;

            //By default remote debugging only accepts connection from
            //localhost. Set this property to true allows you to connect
            //to remote debugging server from another computer. Do not
            //use this option in actual production application
            EO.WebEngine.EngineOptions.Default.RemoteDebugAnyAddress = true;

            //Uncomment this line to support proprietary media formats. See here
            //for more details:
            //https://www.essentialobjects.com/doc/webbrowser/advanced/html5.aspx
            EO.WebEngine.EngineOptions.Default.AllowProprietaryMediaFormats();

            MainWindow mainWnd = new MainWindow();
            mainWnd.Show();
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(e.Exception.ToString())));
        }
    }
}
