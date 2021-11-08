using DotNetBrowser;
using DotNetBrowser.WPF;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WPF.FullScreen
{
    /// <summary>
    /// Calling .NET from javaScript in browser main frame
    /// </summary>
    public class MainBrowser
    {
        private MainWindow window;

        /// <summary></summary>
        public MainBrowser(MainWindow window)
        {
            this.window = window;
        }

        /// <summary>
        /// 截图
        /// </summary>
        public void cut()
        {
            new WindowsWPF.Controls.ScreenCut().ShowDialog();
        }

        /// <summary>
        /// 询问关闭该应用程序
        /// </summary>
        public void close()
        {
            window.Window_ComfirmExit();
        }
        /// <summary>
        /// 直接退出该应用程序
        /// </summary>
        public void exit()
        {
            window.Window_Exit();
        }
    }
    /// <summary></summary>
    public class MainLoadHandler : DefaultLoadHandler
    {
        public override bool OnCertificateError(CertificateErrorParams errorParams)
        {
            //Certificate certificate = errorParams.Certificate;

            //System.Diagnostics.Debug.WriteLine("ErrorCode = " + errorParams.CertificateError);
            //System.Diagnostics.Debug.WriteLine("SerialNumber = " + certificate.SerialNumber);
            //System.Diagnostics.Debug.WriteLine("FingerPrint = " + certificate.FingerPrint);
            //System.Diagnostics.Debug.WriteLine("CAFingerPrint = " + certificate.CAFingerPrint);
            //System.Diagnostics.Debug.WriteLine("Subject = " + certificate.Subject);
            //System.Diagnostics.Debug.WriteLine("Issuer = " + certificate.Issuer);
            //System.Diagnostics.Debug.WriteLine("KeyUsages = " + string.Join(", ", certificate.KeyUsages));
            //System.Diagnostics.Debug.WriteLine("ExtendedKeyUsages = " + string.Join(", ", certificate.ExtendedKeyUsages));
            //System.Diagnostics.Debug.WriteLine("HasExpired = " + certificate.HasExpired);

            // Return false to ignore certificate error.
            return false;
        }
    }
    /// <summary></summary>
    public class MainContextMenuHandler : ContextMenuHandler
    {
        WPFBrowserView view;
        public MainContextMenuHandler(WPFBrowserView view)
        {
            this.view = view;
        }
        public void ShowContextMenu(ContextMenuParams parameters)
        {
            Browser browser = parameters.Browser;
            var popupMenu = new System.Windows.Forms.ContextMenu();

            popupMenu.MenuItems.Add(new MenuItem("刷新", delegate
            {
                browser.Reload();
            })
            {
                Enabled = !string.IsNullOrEmpty(browser.URL)
            });

            popupMenu.MenuItems.Add(new MenuItem("首页", delegate
            {
                browser.LoadURL(Properties.Resources.URL);
            })
            {
                Enabled = !Properties.Resources.URL.Equals(browser.URL)
            });

            popupMenu.MenuItems.Add(new MenuItem("后退", delegate
            {
                browser.GoBack();
            })
            {
                Enabled = browser.CanGoBack()
            });

            popupMenu.MenuItems.Add(new MenuItem("前进", delegate
            {
                browser.GoForward();
            })
            {
                Enabled = browser.CanGoForward()
            });

            popupMenu.MenuItems.Add(new MenuItem("源码", delegate
            {
                var path = Path.GetTempFileName();
                var contents = browser.GetHTML();
                File.WriteAllText(path, contents, Encoding.UTF8);
                System.Diagnostics.Process.Start(path);
            })
            {
                Enabled = !string.IsNullOrEmpty(browser.URL) && (browser.Loading == false)
            });
        }
    }
    /// <summary></summary>
    public class MainNetworkDelegate : DefaultNetworkDelegate
    {
        public override void OnBeforeURLRequest(BeforeURLRequestParams parameters)
        {
            // If navigate to teamdev.com, then change URL to google.com.
            //if (parameters.Url == "http://www.teamdev.com/")
            //{
            //    parameters.SetUrl("www.baidu.com");
            //}
        }
        public override void OnBeforeSendHeaders(BeforeSendHeadersParams parameters)
        {
            // If navigate to google.com, then print User-Agent header value.
            //if (parameters.Url == "https://www.baidu.com/")
            //{
            //    HttpHeaders headers = parameters.Headers;
            //    System.Diagnostics.Debug.WriteLine("User-Agent: " + headers.GetHeader("User-Agent"));
            //}
        }
    }
    /// <summary></summary>
    public class MainCertificateVerifier : CertificateVerifier
    {
        public CertificateVerifyResult Verify(CertificateVerifyParams parameters)
        {
            //if (parameters.HostName.Contains("*.com")) return CertificateVerifyResult.INVALID;
            return CertificateVerifyResult.OK;
        }
    }
    /// <summary></summary>
    public class MainMediaStreamDeviceProvider : MediaStreamDeviceProvider
    {
        public void OnRequestDefaultDevice(MediaStreamDeviceRequest request)
        {
            // Set first available device as default.
            List<MediaStreamDevice> availableDevices = request.Devices;
            if (availableDevices.Count > 0)
            {
                MediaStreamDevice defaultDevice = availableDevices[0];
                request.SetDefaultMediaStreamDevice(defaultDevice);
            }
        }
    }
}
