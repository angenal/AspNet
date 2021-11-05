namespace FullScreenBrowser
{
    //WebViewItem is a DockItem, which is an item hosted by a DockView. In this
    //sample, the main DockView (whose IsDocumentView is set to true) is used 
    //to host one or multiple WebViewItem objects, each WebViewItem hosts a 
    //WebControl, which in turn hosts a WebView
    internal class WebViewItem : EO.Wpf.DockItem
    {
        private WebPage m_Page;

        public WebPage Page => m_Page;

        public WebViewItem(EO.WebBrowser.WebView webView)
        {
            m_Page = new WebPage(webView);

            //Load the WebControl into this DockItem
            Content = m_Page.WebControl;
        }

        //Override OnLoadState and OnSaveState to save the current Url in the
        //DockItem's StateData property. This property is being saved when the
        //DockContainer's SaveLayout method is called (see code in MainWindow)
        public override void OnLoadState()
        {
            m_Page.WebView.Url = StateData;
        }

        public override void OnSaveState()
        {
            StateData = m_Page.WebView.Url;
        }
    }
}
