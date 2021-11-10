using EO.WebBrowser;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BigScreenBrowser
{
    public partial class MainWindow
    {
        //JavaScript code
        void WebView_JSExtInvoke(object sender, JSExtInvokeArgs e)
        {
            switch (e.FunctionName)
            {
                // 获取应用程序信息
                case "appInfo":
                    e.ReturnValue = GetAppInfo();
                    break;
                // 执行内存优化
                case "clearMemory":
                    ClearMemory();
                    break;
                // 显示
                case "showApp":
                    ShowApp();
                    break;
                // 隐藏
                case "hideApp":
                    HideApp();
                    break;
                // 显示/隐藏
                case "toggleApp":
                    ToggleApp();
                    break;
                // 打开其它应用程序
                case "startProcess":
                    if (e.Arguments.Length == 1 && e.Arguments[0].GetType() == typeof(string))
                    {
                        Process.Start(e.Arguments[0].ToString());
                    }
                    break;
                // 执行命令行程序
                case "startCMD":
                    break;
            }
        }

        /// <summary>获取应用程序信息</summary>
        private object GetAppInfo()
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
    }
}
