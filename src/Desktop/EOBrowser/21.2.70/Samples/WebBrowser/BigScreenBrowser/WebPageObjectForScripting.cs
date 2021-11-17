using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BigScreenBrowser
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

        /// <summary>获取当前时间</summary>
        public DateTime Now()
        {
            return DateTime.Now;
        }

        /// <summary>获取应用程序信息</summary>
        public string GetAppInfo()
        {
            return _GetAppInfo();
        }
        internal static string _GetAppInfo()
        {
            var app = typeof(App).Assembly.GetName();
            var a0 = App.AssemblyAttributes.FirstOrDefault(t => t is GuidAttribute);
            var a1 = App.AssemblyAttributes.FirstOrDefault(t => t is AssemblyProductAttribute);
            var wnd = App.MainWnd;
            var process = Process.GetCurrentProcess();
            return JsonConvert.SerializeObject(new
            {
                Id = a0 != null ? ((GuidAttribute)a0).Value : Guid.Empty.ToString(),
                Name = a1 != null ? ((AssemblyProductAttribute)a1).Product : app.Name,
                Version = app.Version.ToString(),
                Location = new { App.Rect.X, App.Rect.Y },
                Size = new { wnd.Width, wnd.Height },
                wnd.Topmost,
                wnd.IsVisible,
                ProcessId = process.Id,
                process.ProcessName,
                App.StartupArgs,
                Threads = process.Threads.Count,
                Memory = (process.WorkingSet64 / 1024.0 / 1024).ToString("f0") + "MB",
                Environment.ProcessorCount,
                Environment.Is64BitProcess,
                Environment.MachineName,
                OSVersion = Environment.OSVersion.ToString(),
                Startup = App.StartupDateTime.ToString("G"),
                Uptime = (DateTime.Now - App.StartupDateTime).ToString().Split('.')[0],
                ApiUrl = $"http://localhost:{WebApi.Httpd.Port}",
                ApiDocument = JsonConvert.SerializeObject(WebApi.Document)
            });
        }

        /// <summary>获取访问历史记录</summary>
        public string GetUrls()
        {
            return _GetUrls();
        }
        internal static string _GetUrls()
        {
            return JsonConvert.SerializeObject(App.Urls);
        }

        /// <summary>强制下载PDF开关</summary>
        /// <param name="forceDownload">下载还是直接打开PDF?</param>
        public bool ForceDownloadPDF(bool forceDownload)
        {
            return Page.ForceDownloadPDF = forceDownload;
        }

        /// <summary>关闭应用程序</summary>
        public void CloseApp()
        {
            App.MainWnd.Window_ComfirmExit();
        }

        /// <summary>退出应用程序</summary>
        public void ExitApp()
        {
            App.MainWnd.Window_Exit();
        }
    }
}
