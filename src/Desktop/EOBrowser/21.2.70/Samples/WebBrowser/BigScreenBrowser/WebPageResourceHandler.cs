using EO.WebBrowser;
using System;

namespace BigScreenBrowser
{
    //Custom Resource handler
    internal class WebPageResourceHandler : ResourceHandler
    {
        public const string UrlPrefix = "app://";
        public const string DefaultPage = "app://index.htm";

        public override bool Match(ResourceHandlerContext context)
        {
            //Return true if the request Url matches our scheme. In that case ProcessRequest will be called to handle the request
            return context.Request.Url.StartsWith(UrlPrefix, StringComparison.OrdinalIgnoreCase);
        }

        public override void ProcessRequest(Request request, Response response)
        {
            base.ProcessRequest(request, response);
        }

        public override void ProcessRequest(ResourceHandlerContext context)
        {
            switch (context.Request.Url)
            {
                case DefaultPage: //项目文件属性:生成操作:嵌入的资源
                    context.Response.ContentType = "text/html";
                    context.Response.WriteResource(typeof(WebPageResourceHandler).Assembly, "FullScreenBrowser.wwwroot.index.htm", "text/html");
                    break;
                default:
                    base.ProcessRequest(context);
                    break;
            }
        }
    }
}
