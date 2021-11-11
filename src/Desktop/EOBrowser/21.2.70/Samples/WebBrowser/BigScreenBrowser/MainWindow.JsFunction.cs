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
                // 打开其它应用程序
                case "runProcess":
                    if (e.Arguments.Length > 0 && e.Arguments[0].GetType() == typeof(string))
                    {
                        try
                        {
                            Process process;
                            if (e.Arguments.Length == 1)
                            {
                                process = Process.Start(e.Arguments[0].ToString());
                            }
                            else
                            {
                                process = Process.Start(e.Arguments[0].ToString(), string.Join(" ", e.Arguments.Skip(1).Where(s => s != null || !string.IsNullOrWhiteSpace(s.ToString()))));
                            }
                            e.ReturnValue = process.Responding;
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
                        string shell = e.Arguments[0].ToString(), args = e.Arguments.Length == 1 ? null : string.Join(" ", e.Arguments.Skip(1).Where(s => s != null || !string.IsNullOrWhiteSpace(s.ToString()))), result = null;
                        var psi = new ProcessStartInfo();
                        psi.FileName = shell;
                        psi.Arguments = args;
                        psi.RedirectStandardOutput = true;
                        psi.UseShellExecute = false;
                        psi.CreateNoWindow = true;
#if DEBUG
                        Debug.WriteLine($">> run CMD >> {string.Join(" ", e.Arguments)}");
#endif
                        try
                        {
                            using (var process = Process.Start(psi))
                            {
                                process?.WaitForExit();
                                result = process?.StandardOutput.ReadToEnd();
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
