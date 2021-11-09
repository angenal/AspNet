using EO.Wpf;
using System;
using System.Windows.Controls;

namespace FullScreenBrowser
{
    public partial class MainWindow
    {
        private void dockContainer_DockViewAdded(object sender, DockViewEventArgs e)
        {
            if (e.DockView.IsDocumentView)
            {
                m_WebViewsHost = e.DockView;
                m_WebViewsHost.HeaderVisible = false;
                m_WebViewsHost.AutoItemIdPrefix = WebViewItemIdPrefix;
            }
            else if (m_ToolViews == null)
            {
                m_ToolViews = e.DockView;
            }
        }

        private void dockContainer_DockViewNeeded(object sender, DockViewNeededEventArgs e)
        {
            if (e.ItemId.StartsWith(WebViewItemIdPrefix))
            {
                if (m_WebViewsHost == null)
                {
                    m_WebViewsHost = new DockView();
                    m_WebViewsHost.IsDocumentView = true;
                }
                e.DockView = m_WebViewsHost;
            }
            else
            {
                if (m_ToolViews == null)
                {
                    m_ToolViews = new DockView();
                    m_ToolViews.Height = 200;
                    m_ToolViews.Dock = Dock.Bottom;
                    //m_ToolViews.State = DockViewState.Float;
                }
                e.DockView = m_ToolViews;
            }
        }

        private void dockContainer_DockItemNeeded(object sender, DockItemNeededEventArgs e)
        {
            switch (e.ItemId)
            {
                case "Downloads":
                    e.Item = DockItem.LoadFrom(new Uri("/FullScreenBrowser;component/DownloadsPane.xaml", UriKind.Relative), "Downloads");
                    DownloadsPane downloadsPane = (DownloadsPane)e.Item.Content;
                    downloadsPane.Bind(m_Downloads);
                    break;
                case "Console":
                    e.Item = DockItem.LoadFrom(new Uri("/FullScreenBrowser;component/ConsolePane.xaml", UriKind.Relative), "Console");
                    m_ConsolePane = (ConsolePane)e.Item.Content;
                    break;
                case "Objects":
                    break;
                default:
                    if (e.ItemId.StartsWith(WebViewItemIdPrefix))
                    {
                        var webView = new EO.WebBrowser.WebView();
                        if (e.ItemId.Length == WebViewItemIdPrefix.Length)
                        {
                            if (isFullScreen)
                            {
                                webView.Url = m_HomeURL;
                                System.Diagnostics.Debug.WriteLine($">> {e.ItemId}{m_HomeURL}");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($">> {WebViewItemIdPrefix} load an empty page");
                            }
                        }
                        else
                        {
                            var url = e.ItemId.Substring(WebViewItemIdPrefix.Length);
                            System.Diagnostics.Debug.WriteLine($">> {e.ItemId}");
                            if (url.StartsWith("http")) webView.Url = url;
                        }
                        e.Item = NewWebViewItem(webView);
                    }
                    break;
            }
        }
    }
}
