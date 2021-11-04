using System.Windows;
using System.Windows.Threading;
using WindowsWPF.Controls;

namespace WPF.FullScreen
{
    /// <summary></summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DFoXDotNeBrowser.DFoX_DotNetBrowser.DFoXModificaMemoria();
            //Assembly assembly = Assembly.Load(FullScreen.Properties.Resources.DFoXDotNeBrowser);
            //var type = assembly.GetType("DFoXDotNeBrowser.DFoX_DotNetBrowser");
            //type.GetMethods().First().Invoke(null, new object[0]);
            //System.Diagnostics.Debug.WriteLine(" >> Application Startup");
            //DispatcherUnhandledException += App_DispatcherUnhandledException;

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
            TransparentSplash.Instance.Width = 530;
            TransparentSplash.Instance.Height = 205;
            TransparentSplash.SetBackgroundImage(FullScreen.Properties.Resources.SplashImage2);

            TransparentSplash.BeginDisplay();
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
        }
    }
}
