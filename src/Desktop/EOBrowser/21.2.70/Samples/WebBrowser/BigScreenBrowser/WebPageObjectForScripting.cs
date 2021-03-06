using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;

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
            MainWindow wnd = App.MainWnd;
            Window window = Application.Current.MainWindow;
            Process process = Process.GetCurrentProcess();
            AssemblyName app = typeof(App).Assembly.GetName();
            object a0 = App.AssemblyAttributes.FirstOrDefault(t => t is GuidAttribute);
            object a1 = App.AssemblyAttributes.FirstOrDefault(t => t is AssemblyProductAttribute);
            return JsonConvert.SerializeObject(new
            {
                Id = a0 != null ? ((GuidAttribute)a0).Value : Guid.Empty.ToString(),
                Name = a1 != null ? ((AssemblyProductAttribute)a1).Product : app.Name,
                Version = app.Version.ToString(),
                Location = new { X = wnd.Left, Y = wnd.Top },
                Size = new { wnd.Width, wnd.Height },
                State = new { Visible = wnd.IsVisible || window.IsVisible, Topmost = wnd.Topmost || window.Topmost },
                Start = new
                {
                    Url = $"{Properties.Resources.URLProtocol}://localhost:{WebApi.Httpd.Port}/api",
                    Args = App.StartupArgs,
                    Startup = App.StartupDateTime.ToString("G"),
                    Uptime = (DateTime.Now - App.StartupDateTime).ToString().Split('.')[0],
                    Now = DateTime.Now.ToString("G")
                },
                ProcessId = process.Id,
                process.ProcessName,
                Threads = process.Threads.Count,
                Memory = (process.WorkingSet64 / 1024.0 / 1024).ToString("f0") + "MB",
                Environment.ProcessorCount,
                Environment.Is64BitProcess,
                Environment.MachineName,
                OSVersion = Environment.OSVersion.ToString(),
                Api = new
                {
                    Url = $"http://localhost:{WebApi.Httpd.Port}",
                    Document = JsonConvert.SerializeObject(WebApi.Document)
                }
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
