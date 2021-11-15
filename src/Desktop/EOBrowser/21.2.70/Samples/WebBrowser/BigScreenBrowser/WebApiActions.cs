using Newtonsoft.Json;
using System;
using System.Windows;

namespace BigScreenBrowser
{
    public partial class WebApiActions
    {
        [RequestRoute("/api", Description = "接口文档")]
        public static void Document(HttpRequest req, HttpResponse resp)
        {
            //string act = req.Request.QueryString["act"];
            var jsonDocument = JsonConvert.SerializeObject(WebApi.Document);
            resp.Response.WriteJson(jsonDocument);
            resp.Response.End();
        }

        [RequestRoute(Description = "执行内存优化")]
        public static void ClearMemory(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ClearMemory()));
            resp.Response.End();
        }

        [RequestRoute(Description = "显示或隐藏程序")]
        public static void ToggleApp(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ToggleApp()));
            resp.Response.End();
        }

        [RequestRoute(Description = "显示该应用程序")]
        public static void ShowApp(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ShowApp()));
            resp.Response.End();
        }

        [RequestRoute(Description = "隐藏该应用程序")]
        public static void HideApp(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.HideApp()));
            resp.Response.End();
        }
    }
}
