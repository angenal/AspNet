using EO.WebBrowser;
using System.Diagnostics;

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
                case "runProcess":
                    if (e.Arguments.Length == 1 && e.Arguments[0].GetType() == typeof(string))
                    {
                        Process.Start(e.Arguments[0].ToString());
                    }
                    break;
                // 执行命令行程序
                case "runCMD":
                    break;
            }
        }
    }
}
