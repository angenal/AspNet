using EO.WebBrowser;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WindowsWPF.Controls;
using WindowsWPF.Helpers;
using WindowsWPF.Interop;

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
                    WinApi.ClearMemory();
                    break;
                // 显示/隐藏
                case "toggleApp":
                    ToggleApp();
                    break;
                // 显示应用程序
                case "showApp":
                    ShowApp();
                    break;
                // 隐藏应用程序
                case "hideApp":
                    HideApp();
                    break;
                // 关闭应用程序
                case "closeApp":
                    Window_ComfirmExit();
                    break;
                // 退出应用程序
                case "exitApp":
                    Window_Exit();
                    break;
                // 拆分窗口为一半/还原
                case "halveApp":
                    HalveApp();
                    break;
                // 打开通知消息
                case "alert":
                    if (e.Arguments.Length > 0 && e.Arguments[0].GetType() == typeof(string))
                    {
                        try
                        {
                            HideWebBrowser();
                            TimeSpan expirationTime = TimeSpan.FromSeconds(5);
                            string areaName = "centerArea", badge = e.Arguments[0].ToString(), message = e.Arguments.Length == 1 ? badge : string.Join(" ", e.Arguments.Skip(1).Where(s => s != null || !string.IsNullOrWhiteSpace(s.ToString())));
                            if (e.Arguments.Length == 1)
                            {
                                notifier.Show(new NotificationContent { Message = message, Type = NotificationType.Information }, areaName, expirationTime, onClose: ShowWebBrowser);
                            }
                            else
                            {
                                notifier.Show(new NotificationContent { Message = message, Title = badge, Type = NotificationType.Information }, areaName, expirationTime, onClose: ShowWebBrowser);
                            }
                            e.ReturnValue = true;
                        }
                        catch (Exception ex)
                        {
                            e.ReturnValue = ex.Message;
                        }
                    }
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
                            Debug.WriteLine("");
                            Debug.WriteLine($">> run CMD >> {string.Join(" ", e.Arguments)}");
                            Debug.WriteLine("");
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
                                Debug.WriteLine("");
                                Debug.WriteLine($">> run CMD << {result}");
                                Debug.WriteLine("");
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

        private void HideWebBrowser()
        {
            var rect = new Rect { X = Left, Y = Top, Width = Width, Height = Height };
            var bitmap = rect.CopyAsBitmap();
            var image = bitmap.ToImageSource();
            notifyPanel.Background = new ImageBrush(image);
            notifyPanel.Visibility = Visibility.Visible;
            webPanel.Visibility = Visibility.Hidden;
        }

        private void ShowWebBrowser()
        {
            notifyPanel.Visibility = Visibility.Hidden;
            webPanel.Visibility = Visibility.Visible;
        }
    }
}
