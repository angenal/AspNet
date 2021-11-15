using System;
using System.Windows;

namespace BigScreenBrowser
{
    public partial class WebApiActions
    {
        /// <summary>
        /// 执行内存优化
        /// </summary>
        [RequestRoute(RequestMethod.GET, "/api/clearMemory")]
        public static void ClearMemory(HttpRequest req, HttpResponse resp)
        {
            //string act = req.Request.QueryString["act"];
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ClearMemory()));
            resp.Response.OutputStream.Close();
        }

        /// <summary>
        /// 显示/隐藏
        /// </summary>
        [RequestRoute(RequestMethod.GET, "/api/toggleApp")]
        public static void ToggleApp(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ToggleApp()));
            resp.Response.OutputStream.Close();
        }

        /// <summary>
        /// 显示该应用程序
        /// </summary>
        [RequestRoute(RequestMethod.GET, "/api/showApp")]
        public static void ShowApp(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.ShowApp()));
            resp.Response.OutputStream.Close();
        }

        /// <summary>
        /// 隐藏该应用程序
        /// </summary>
        [RequestRoute(RequestMethod.GET, "/api/hideApp")]
        public static void HideApp(HttpRequest req, HttpResponse resp)
        {
            App.MainWnd.Dispatcher.BeginInvoke(new Action(() => App.MainWnd.HideApp()));
            resp.Response.OutputStream.Close();
        }
    }
}
