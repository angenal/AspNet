using EO.WebBrowser;
using System;
using System.Diagnostics;
using System.Linq;

namespace BigScreenBrowser
{
    public partial class MainWindow
    {
        //JavaScript code
        void WebView_JSExtInvoke(object sender, JSExtInvokeArgs e)
        {
            switch (e.FunctionName)
            {
                // 执行内存优化
                case "clearMemory":
                    ClearMemory();
                    break;
                // 显示/隐藏
                case "toggleApp":
                    ToggleApp();
                    break;
                // 显示该应用程序
                case "showApp":
                    ShowApp();
                    break;
                // 隐藏该应用程序
                case "hideApp":
                    HideApp();
                    break;
                // 拆分窗口为以前的一半
                case "halveApp":
                    HalveApp();
                    break;
                // 打开其它应用程序
                case "runProcess":
                    if (e.Arguments.Length > 0 && e.Arguments[0].GetType() == typeof(string))
                    {
                        try
                        {
                            string fileName = e.Arguments[0].ToString(), arguments = e.Arguments.Length == 1 ? null : string.Join(" ", e.Arguments.Skip(1).Where(s => s != null || !string.IsNullOrWhiteSpace(s.ToString())));
                            Process process = string.IsNullOrWhiteSpace(arguments) ? Process.Start(fileName) : Process.Start(fileName, arguments);
                            e.ReturnValue = process.HasExited ? 0 : process.Id;
                        }
                        catch (Exception ex)
                        {
                            e.ReturnValue = ex.Message;
                        }
                    }
                    break;
                // 执行命令行程序
                case "runCMD":
                    if (e.Arguments.Length > 0 && e.Arguments[0].GetType() == typeof(string))
                    {
                        try
                        {
                            string fileName = e.Arguments[0].ToString(), arguments = e.Arguments.Length == 1 ? null : string.Join(" ", e.Arguments.Skip(1).Where(s => s != null || !string.IsNullOrWhiteSpace(s.ToString())));
                            var psi = new ProcessStartInfo();
                            psi.FileName = fileName;
                            if (!string.IsNullOrWhiteSpace(arguments)) psi.Arguments = arguments;
                            psi.WindowStyle = ProcessWindowStyle.Hidden;
                            psi.CreateNoWindow = true;
                            psi.UseShellExecute = false;
                            psi.RedirectStandardInput = true;
                            psi.RedirectStandardOutput = true;
#if DEBUG
                            Debug.WriteLine($">> run CMD >> {string.Join(" ", e.Arguments)}");
#endif
                            string result = null;
                            using (var process = Process.Start(psi))
                            {
                                process.WaitForExit();
                                result = process.StandardOutput.ReadToEnd();
                            }
                            if (!string.IsNullOrWhiteSpace(result))
                            {
#if DEBUG
                                Debug.WriteLine($">> run CMD << {result}");
#endif
                                e.ReturnValue = result;
                            }
                            else
                            {
                                e.ReturnValue = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            e.ReturnValue = ex.Message;
                        }
                    }
                    break;
            }
        }
    }
}
