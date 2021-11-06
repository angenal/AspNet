using EO.WebBrowser;
using EO.Wpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FullScreenBrowser
{
    //WPF wrapper class that maintains various UI related information and 
    //servers as the "Data Item" for the TabItem
    internal class WebPage : DependencyObject
    {
        //The Wpf WebControl
        private WebControl m_WebControl;

        //The core WebView object
        private EO.WebBrowser.WebView m_WebView;

        //Force download PDF files
        public bool ForceDownloadPDF { get; set; }

        //All messages output by the WebView
        private ObservableCollection<string> m_Messages = new ObservableCollection<string>();

        //Title property for data binding purpose. This property is synced with WebView.Title
        private static readonly DependencyPropertyKey TitlePropertyKey = DependencyProperty.RegisterReadOnly("Title", typeof(string), typeof(WebPage), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty = TitlePropertyKey.DependencyProperty;

        //Favicon property for data binding purpose. This property is synced with WebView.Favicon
        private static readonly DependencyPropertyKey FaviconPropertyKey = DependencyProperty.RegisterReadOnly("Favicon", typeof(BitmapSource), typeof(WebPage), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty FaviconProperty = FaviconPropertyKey.DependencyProperty;

        public WebPage(EO.WebBrowser.WebView webView)
        {
            if (webView == null)
            {
                webView = new EO.WebBrowser.WebView();
                webView.Title = "New Tab";
            }

            //Create the WebControl and WebView
            m_WebControl = new WebControl();
            m_WebControl.WebView = m_WebView = webView;

            //Handle various UI related events
            m_WebView.TitleChanged += new EventHandler(m_WebView_TitleChanged);
            m_WebView.FaviconChanged += new EventHandler(m_WebView_FaviconChanged);
            m_WebView.ConsoleMessage += new ConsoleMessageHandler(m_WebView_ConsoleMessage);

            //Handles various request events
            m_WebView.CertificateError += m_WebView_CertificateError;
            m_WebView.RequestPermissions += m_WebView_RequestPermissions;
            m_WebView.ShouldForceDownload += m_WebView_ShouldForceDownload;

            //Register the custom protocol handler
            m_WebView.RegisterResourceHandler(new WebPageResourceHandler());

            m_WebView.ObjectForScripting = new WebPageObjectForScripting(this);

            m_WebView_TitleChanged(null, EventArgs.Empty);
        }

        void m_WebView_TitleChanged(object sender, EventArgs e)
        {
            Title = m_WebView.Title;
        }

        void m_WebView_FaviconChanged(object sender, EventArgs e)
        {
            if (m_WebView.Favicon == null)
            {
                Favicon = null;
                return;
            }
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream ms = new MemoryStream())
            {
                m_WebView.Favicon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            Favicon = bitmapImage;
        }

        void m_WebView_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            string message = string.Format("({0}) - {1} line# {2}:{3}", e.Severity, e.Source, e.LineNumber, e.Message);
            m_Messages.Add(message);
        }

        void m_WebView_CertificateError(object sender, CertificateErrorEventArgs e)
        {
            e.Continue();
        }

        void m_WebView_RequestPermissions(object sender, RequestPermissionEventArgs e)
        {
            e.Allow();
        }

        //You can also check e.Url to force download certain Urls
        void m_WebView_ShouldForceDownload(object sender, ShouldForceDownloadEventArgs e)
        {
            //Force download PDF files
            if (e.MimeType == "application/pdf") e.ForceDownload = ForceDownloadPDF;
        }

        public WebControl WebControl => m_WebControl;

        public EO.WebBrowser.WebView WebView => m_WebView;

        public ObservableCollection<string> Messages => m_Messages;

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            private set => SetValue(TitlePropertyKey, value);
        }

        public BitmapSource Favicon
        {
            get => (BitmapSource)GetValue(FaviconProperty);
            private set => SetValue(FaviconPropertyKey, value);
        }
    }
}
