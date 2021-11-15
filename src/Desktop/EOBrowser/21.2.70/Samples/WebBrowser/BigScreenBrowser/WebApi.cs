using System.Diagnostics;
using System.Windows;

namespace BigScreenBrowser
{
    public class WebApi
    {
        internal static HttpServer Httpd;

        internal static void Init()
        {
            if (!int.TryParse(Properties.Resources.HttpPort, out int port) && port < 1024)
                port = Process.GetCurrentProcess().Id % 30101;
            Httpd = new HttpServer(4, port);
            var handlers = RequestRouteHelper.GetRequestHandlers(typeof(WebApiActions));
            foreach (var a in handlers) Httpd.Route(a.Attribute.Path, a.Attribute.Method, a.Handler);
            Httpd.Start();
        }

        internal static void Dispose()
        {
            Httpd?.Stop();
        }
    }
}
