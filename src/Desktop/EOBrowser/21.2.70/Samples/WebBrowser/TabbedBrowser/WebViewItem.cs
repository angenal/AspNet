using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.IO;
using EO.Wpf;
using EO.WebBrowser;

namespace EO.TabbedBrowser
{
    //WPF wrapper class that maintains various UI related information and 
    //servers as the "Data Item" for the TabItem
    internal class WebPage: DependencyObject
    {
        //The Wpf WebControl
        private EO.Wpf.WebControl m_WebControl;

        //The core WebView object
        private EO.WebBrowser.WebView m_WebView;

        //The main tab controls
        private EO.Wpf.TabControl m_TabControl;

        //All messages output by the WebView
        private ObservableCollection<string> m_Messages = new ObservableCollection<string>();

        //Title property for data binding purpose. This property
        //is synced with WebView.Title
        private static readonly DependencyPropertyKey TitlePropertyKey =
            DependencyProperty.RegisterReadOnly("Title", typeof(string), typeof(WebPage), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty = TitlePropertyKey.DependencyProperty;

        //Favicon property for data binding purpose. This property
        //is synced with WebView.Favicon
        private static readonly DependencyPropertyKey FaviconPropertyKey =
            DependencyProperty.RegisterReadOnly("Favicon", typeof(BitmapSource), typeof(WebPage), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty FaviconProperty = FaviconPropertyKey.DependencyProperty;

        //Demo object for WebView.ObjectForScripting property. This object exposes three
        //methods that can be called from JavaScript
        private class ObjectForScriptingDemo
        {
            public void Hello(string s)
            {
                MessageBox.Show("Hello From Script:" + s);
            }

            public DateTime GetTime()
            {
                return DateTime.Now;
            }

            public void HandleMouseClick(int x, int y)
            {
                string s = string.Format("Click From JavaScript, x = {0}, y = {1}", x, y);
                MessageBox.Show(s);
            }
        }

        public WebPage(EO.WebBrowser.WebView webView, EO.Wpf.TabControl tabControl)
        {
            //Create the WebControl and WebView
            m_WebControl = new EO.Wpf.WebControl();
            if (webView == null)
            {
                webView = new EO.WebBrowser.WebView();
                webView.Title = "New Tab";
            }
            m_WebView = webView;
            m_WebControl.WebView = m_WebView;

            //Handle various UI related events
            m_WebView.TitleChanged += new EventHandler(m_WebView_TitleChanged);
            m_WebView.FaviconChanged += new EventHandler(m_WebView_FaviconChanged);
            m_WebView.ConsoleMessage += new ConsoleMessageHandler(m_WebView_ConsoleMessage);

            //Register the custom protocol handler
            m_WebView.RegisterResourceHandler(new SampleHandler());

            m_WebView.ObjectForScripting = new ObjectForScriptingDemo();

            m_TabControl = tabControl;

            m_WebView_TitleChanged(null, EventArgs.Empty);
        }

        void m_WebView_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            string message = string.Format("({0}) - {1} line# {2}:{3}", e.Severity, e.Source, e.LineNumber, e.Message);
            m_Messages.Add(message);
        }

        private void RelayoutTabHeaders()
        {
            UIElement header = m_TabControl.HeaderElement;
            if (header != null)
            {
                EO.Wpf.Primitives.TabStripPanel panel = GetTabStripPanel(header);
                if (panel != null)
                    panel.InvalidateMeasure();
            }
        }

        private EO.Wpf.Primitives.TabStripPanel GetTabStripPanel(DependencyObject obj)
        {
            if (obj is EO.Wpf.Primitives.TabStripPanel)
                return (EO.Wpf.Primitives.TabStripPanel)obj;

            int n = System.Windows.Media.VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < n; i++)
            {
                DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(obj, i);
                EO.Wpf.Primitives.TabStripPanel panel = GetTabStripPanel(child);
                if (panel != null)
                    return panel;
            }

            return null;
        }

        void m_WebView_FaviconChanged(object sender, EventArgs e)
        {
            if (m_WebView.Favicon == null)
                Favicon = null;
            else
            {
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
            RelayoutTabHeaders();
        }

        void m_WebView_TitleChanged(object sender, EventArgs e)
        {
            Title = m_WebView.Title;
            RelayoutTabHeaders();
        }

        public EO.Wpf.WebControl WebControl
        {
            get
            {
                return m_WebControl;
            }
        }

        public EO.WebBrowser.WebView WebView
        {
            get
            {
                return m_WebView;
            }
        }

        public ObservableCollection<string> Messages
        {
            get
            {
                return m_Messages;
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            private set { SetValue(TitlePropertyKey, value); }
        }

        public BitmapSource Favicon
        {
            get { return (BitmapSource)GetValue(FaviconProperty); }
            private set { SetValue(FaviconPropertyKey, value); }
        }
    }

    //Custom Resource handler
    internal class SampleHandler : ResourceHandler
    {
        public const string SampleUrlPrefix = "sample://";
        public const string EmbeddedPageUrl = "sample://embedded_page/index.html";

        public override bool Match(ResourceHandlerContext context)
        {
            //Return true if the request Url matches our scheme. In that
            //case ProcessRequest will be called to handle the request
            return context.Request.Url.StartsWith(SampleUrlPrefix, StringComparison.OrdinalIgnoreCase);
        }

        public override void ProcessRequest(ResourceHandlerContext context)
        {
            //Only process EmbeddedPageUrl
            if (string.Compare(context.Request.Url, EmbeddedPageUrl, true) == 0)
            {
                //Set content type
                context.Response.ContentType = "text/html";
                context.Response.WriteResource(typeof(SampleHandler).Assembly, "EO.TabbedBrowser.EmbeddedPage.htm", "text/html");
            }
        }
    }

    //WebViewItem is a DockItem, which is an item hosted by a DockView. In this
    //sample, the main DockView (whose IsDocumentView is set to true) is used 
    //to host one or multiple WebViewItem objects, each WebViewItem hosts a 
    //WebControl, which in turn hosts a WebView
    internal class WebViewItem : DockItem
    {
        private WebPage m_Page;

        public WebViewItem(EO.WebBrowser.WebView webView, EO.Wpf.TabControl tabControl)
        {
            m_Page = new WebPage(webView, tabControl);

            //Load the WebControl into this DockItem
            Content = m_Page.WebControl;
        }

        public WebPage Page
        {
            get
            {
                return m_Page;
            }
        }

        //Override OnLoadState and OnSaveState to save the current Url in the
        //DockItem's StateData property. This property is being saved when the
        //DockContainer's SaveLayout method is called (see code in MainWindow)
        public override void OnLoadState()
        {
            m_Page.WebView.Url = (string)StateData;
        }

        public override void OnSaveState()
        {
            StateData = m_Page.WebView.Url;
        }
    }
}