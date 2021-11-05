using System;

namespace FullScreenBrowser
{
    //Scripting object for WebView.ObjectForScripting property.
    //This object exposes three methods that can be called from JavaScript.
    internal class WebPageObjectForScripting
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
