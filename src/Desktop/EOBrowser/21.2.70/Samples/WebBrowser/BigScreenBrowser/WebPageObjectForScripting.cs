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
        public object GetAppInfo()
        {
            var app = typeof(App).Assembly.GetName();
            var a0 = App.AssemblyAttributes.FirstOrDefault(t => t is GuidAttribute);
            var a1 = App.AssemblyAttributes.FirstOrDefault(t => t is AssemblyProductAttribute);
            var process = Process.GetCurrentProcess();
            return new
            {
                Id = a0 != null ? ((GuidAttribute)a0).Value : Guid.Empty.ToString(),
                Name = a1 != null ? ((AssemblyProductAttribute)a1).Product : app.Name,
                Version = app.Version.ToString(),
                ProcessId = process.Id,
                process.ProcessName,
                App.StartupArgs,
                Threads = process.Threads.Count,
                Memory = (process.WorkingSet64 / 1024.0 / 1024).ToString("f1") + " MB",
                Environment.ProcessorCount,
                Environment.Is64BitProcess,
                process.MachineName,
                OSVersion = Environment.OSVersion.ToString(),
                Startup = App.StartupDateTime.ToString("G"),
                Uptime = (DateTime.Now - App.StartupDateTime).ToString()
            };
        }

        /// <summary>
        /// 强制下载PDF开关
        /// </summary>
        /// <param name="forceDownload">下载还是直接打开PDF?</param>
        public void ForceDownloadPDF(bool forceDownload)
        {
            Page.ForceDownloadPDF = forceDownload;
        }

        /// <summary>退出应用程序</summary>
        public void ExitApp()
        {
            App.MainWnd.Window_ComfirmExit();
        }
    }
}
