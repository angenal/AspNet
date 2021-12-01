using System;
using System.Windows;
using WindowsWPF.Interop;

namespace BigScreenBrowser
{
    public partial class WebApiActions
    {
        [RequestRoute("/api", Description = "接口文档")]
        public static void Document(HttpRequest req, HttpResponse resp)
        {
            //string act = req.Request.QueryString["act"];
            var jsonDocument = Newtonsoft.Json.JsonConvert.SerializeObject(WebApi.Document);
            resp.AddJsonHeader();
            resp.Write(jsonDocument);
        }

        [RequestRoute(Description = "执行内存优化")]
        public static void ClearMemory(HttpRequest req, HttpResponse resp)
        {
            if (App.MainWnd == null || App.MainWnd.IsLoaded == false) return;
            Application.Current.Dispatcher.BeginInvoke(new Action(() => WinApi.ClearMemory()));
        }

        [RequestRoute(Description = "显示或隐藏程序")]
        public static void ToggleApp(HttpRequest req, HttpResponse resp)
        {
            if (App.MainWnd == null || App.MainWnd.IsLoaded == false) return;
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ToggleApp()));
        }

        [RequestRoute(Description = "显示该应用程序")]
        public static void ShowApp(HttpRequest req, HttpResponse resp)
        {
            if (App.MainWnd == null || App.MainWnd.IsLoaded == false || App.MainWnd.IsVisible) return;
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ShowApp()));
        }

        [RequestRoute(Description = "隐藏该应用程序")]
        public static void HideApp(HttpRequest req, HttpResponse resp)
        {
            if (App.MainWnd == null || App.MainWnd.IsLoaded == false || App.MainWnd.IsVisible == false) return;
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.HideApp()));
        }
    }
}
