using System;
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
                port = Process.GetCurrentProcess().Id % 30000;
            Httpd = new HttpServer(4, port);
            Httpd.Route("/api", "GET", ApiHandler);
            Httpd.Start();
        }

        internal static void ApiHandler(HttpRequest req, HttpResponse resp)
        {
            if (req.Request.HttpMethod.ToUpper() == "GET")
            {
                string act = req.Request.QueryString["act"];
                if (!string.IsNullOrEmpty(act))
                {
                    switch (act)
                    {
                        // 执行内存优化
                        case "clearMemory":
                            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ClearMemory()));
                            break;
                        // 显示/隐藏
                        case "toggleApp":
                            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ToggleApp()));
                            break;
                        // 显示该应用程序
                        case "showApp":
                            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ShowApp()));
                            break;
                        // 隐藏该应用程序
                        case "hideApp":
                            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.HideApp()));
                            break;
                        default:
                            break;
                    }
                }
            }
            resp.Response.OutputStream.Close();
        }

        internal static void Dispose()
        {
            Httpd?.Stop();
        }
    }
}
