using System;

namespace FullScreenBrowser
{
    //Scripting object for WebView.ObjectForScripting property.
    //This object exposes three methods that can be called from JavaScript.
    internal class WebPageObjectForScripting
    {
        public WebPage Page { get; private set; }

        public WebPageObjectForScripting(WebPage page)
        {
            Page = page;
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }

        public void ForceDownloadPDF()
        {
            Page.ForceDownloadPDF = true;
        }
    }
}
