using EO.WebBrowser;
using System;

namespace FullScreenBrowser
{
    //Custom Resource handler
    internal class WebPageResourceHandler : ResourceHandler
    {
        public const string SampleUrlPrefix = "app://";
        public const string EmbeddedPageUrl = "app://index.html";

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
                context.Response.WriteResource(typeof(WebPageResourceHandler).Assembly, "FullScreenBrowser.index.html", "text/html");
            }
        }
    }
}
