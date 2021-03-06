using EO.WebBrowser;
using System;
using System.Windows;
using System.Windows.Threading;

namespace BigScreenBrowser
{
    public partial class MainWindow
    {
        //This event handler is called when a context menu item or a hot key triggers a "command".
        //private static int m_F1Command = CommandIds.RegisterUserCommand("help");
        private static int m_DemoCommand = CommandIds.RegisterUserCommand("demo");
        private static int m_HomeCommand = CommandIds.RegisterUserCommand("home");
        private static int m_BackCommand = CommandIds.RegisterUserCommand("back");
        private static int m_ForwardCommand = CommandIds.RegisterUserCommand("forward");
        private static int m_GotoUrlCommand = CommandIds.RegisterUserCommand("gotoUrl");
        private static int m_ScreenCutCommand = CommandIds.RegisterUserCommand("screenCut");
        private static int m_HideCommand = CommandIds.RegisterUserCommand("hide");
        private static int m_ExitCommand = CommandIds.RegisterUserCommand("exit");
        private static Shortcut[] GetShortcuts()
        {
            return new Shortcut[]
            {
                //new Shortcut(m_F1Command, KeyCode.F1),
                new Shortcut(CommandIds.Reload, KeyCode.F5), //刷新网页
                new Shortcut(CommandIds.ReloadNoCache, KeyCode.F5, true, false, false),//刷新
                new Shortcut(CommandIds.Reload, KeyCode.R, true, false, false), //重新加载
                new Shortcut(m_ScreenCutCommand, KeyCode.A, false, true, false), //截图 Alt + A
                new Shortcut(m_DemoCommand, KeyCode.D, false, true, false), //演示页面 Alt + D
                new Shortcut(m_HomeCommand, KeyCode.Home), //返回首页 Home
                new Shortcut(m_BackCommand, KeyCode.BrowserBack, false, true, false), //返回 Alt + ←
                new Shortcut(m_ForwardCommand, KeyCode.BrowserForward, false, true, false), //向前 Alt + →
                new Shortcut(m_GotoUrlCommand, KeyCode.V, false, true, false), //剪切板 Alt + V
                new Shortcut(m_HideCommand, KeyCode.H, false, true, false), //隐藏 Alt + H
                new Shortcut(m_ExitCommand, KeyCode.End, false, true, false), //退出 Alt + End
            };
        }

        //This event is called when the user right clicks in a WebView and it needs
        //to display a context menu. Here we creates the context menu to be displayed
        void WebView_BeforeContextMenu(object sender, BeforeContextMenuEventArgs e)
        {
            WebView webView = (WebView)sender;

            //Clear the default context menu
            e.Menu.Items.Clear();

            if (e.Menu.Items.HasPluginMenuItems())
                e.Menu.Items.Add(MenuItem.CreateSeparator());

            //Create new context menu items. Each menu item is associated to
            //a "Command". When the menu item is selected, WebView_Command is
            //called (as event handler for the Command event) to handle the
            //corresponding command
            e.Menu.Items.Add(new MenuItem("返回", m_BackCommand) { Enabled = m_CurIndex > 0 });
            e.Menu.Items.Add(new MenuItem("前进", m_ForwardCommand) { Enabled = m_CurIndex < App.Urls.Count - 1 });
            e.Menu.Items.Add(new MenuItem("刷新", CommandIds.Reload) { Enabled = !string.IsNullOrEmpty(webView.Url) });
            e.Menu.Items.Add(MenuItem.CreateSeparator());
            if (!webView.Url.Equals(m_HomeURL, StringComparison.OrdinalIgnoreCase))
            {
                e.Menu.Items.Add(new MenuItem("首页", m_HomeCommand));
                e.Menu.Items.Add(MenuItem.CreateSeparator());
            }
            var textData = Clipboard.GetData(DataFormats.Text);
            if (textData != null && Uri.TryCreate(textData.ToString().Trim(), UriKind.Absolute, out Uri uri)
                && !webView.Url.Equals(uri.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                e.Menu.Items.Add(new MenuItem("粘贴并转到" + uri.Authority, m_GotoUrlCommand));
                e.Menu.Items.Add(MenuItem.CreateSeparator());
            }
            e.Menu.Items.Add(new MenuItem("截图", m_ScreenCutCommand) { Enabled = !isScreenCut });
            e.Menu.Items.Add(MenuItem.CreateSeparator());
            e.Menu.Items.Add(new MenuItem("隐藏", m_HideCommand));
            e.Menu.Items.Add(new MenuItem("退出", m_ExitCommand));

            //e.Menu.Items.Add(new MenuItem("源码", CommandIds.ViewSource));
            ////e.Menu.Items.Add(MenuItem.CreateSeparator());
            ////e.Menu.Items.Add(new MenuItem("打印", CommandIds.Print));

            //if (e.MenuInfo.Suggestions.Length > 0)
            //{
            //    e.Menu.Items.Add(MenuItem.CreateSeparator());
            //    e.Menu.Items.AddSpellCheckSuggstions(e.MenuInfo.Suggestions);
            //    e.Menu.Items.Add(MenuItem.CreateSeparator());
            //    e.Menu.Items.Add(new MenuItem("Add To Dictionary", CommandIds.SpellCheckAddToDictionary));
            //}
        }

        //Here we only handle our own custom commands
        void WebView_Command(object sender, CommandEventArgs e)
        {
            //演示页面 Alt + D
            if (e.CommandId == m_DemoCommand)
            {
                e.Handled = true;
                WebView webView = (WebView)sender;
                webView.Url = WebPageResourceHandler.DefaultPage;
                return;
            }
            //返回首页 Home
            if (e.CommandId == m_HomeCommand)
            {
                e.Handled = true;
                WebView webView = (WebView)sender;
                webView.Url = m_HomeURL;
                return;
            }
            //返回 Alt + ←
            if (e.CommandId == m_BackCommand || e.CommandId == CommandIds.Back)
            {
                e.Handled = true;
                WebView_Back(sender);
                return;
            }
            //向前 Alt + →
            if (e.CommandId == m_ForwardCommand || e.CommandId == CommandIds.Forward)
            {
                e.Handled = true;
                WebView_Forward(sender);
                return;
            }
            //剪切板网址跳转
            if (e.CommandId == m_GotoUrlCommand)
            {
                e.Handled = true;
                var textData = Clipboard.GetData(DataFormats.Text);
                if (textData != null && Uri.TryCreate(textData.ToString().Trim(), UriKind.Absolute, out Uri uri))
                {
                    WebView webView = (WebView)sender;
                    webView.Url = uri.ToString();
                    return;
                }
            }
            //截图
            if (e.CommandId == m_ScreenCutCommand)
            {
                e.Handled = true;
                isScreenCut = true;
                App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(ScreenCut));
                return;
            }
            //隐藏
            if (e.CommandId == m_HideCommand)
            {
                e.Handled = true;
                App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(HideApp));
                return;
            }
            //退出
            if (e.CommandId == m_ExitCommand)
            {
                e.Handled = true;
                App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(Window_ComfirmExit));
                return;
            }
            //提示快捷键功能 F1
            //if (e.CommandId == m_F1Command)
            //{
            //    e.Handled = true;
            //    App.Show(HotkeyMessageBoxText);
            //    return;
            //}
        }


        private bool TryGetUrlByBackOrForward(bool isForward, out int newIndex)
        {
            int index = -1, count = App.Urls.Count;
            for (int i = 0; i < count; i++)
            {
                if (App.Urls[i].Opened)
                {
                    index = i;
                    break;
                }
            }
            newIndex = isForward ? index + 1 : index - 1;
            return newIndex >= 0 && newIndex < count;
        }

        private bool TryGetUrlByBackAfterLaunchUrl(out int newIndex)
        {
            int count = App.Urls.Count, index = count - 1;
            if (count > 1 && Uri.TryCreate(App.Urls[index].Url, UriKind.Absolute, out Uri uri1))
            {
                string authority = uri1.Authority;
                for (int i = index; i >= 0; i--)
                {
                    if (Uri.TryCreate(App.Urls[i].Url, UriKind.Absolute, out Uri uri2) && authority.Equals(uri2.Authority, StringComparison.OrdinalIgnoreCase))
                    {
                        App.Urls.RemoveAt(i);
                        index--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            newIndex = index;
            return newIndex >= 0 && newIndex < App.Urls.Count;
        }

        private string SetUrlIndex(int index)
        {
            if (index < 0 || index >= App.Urls.Count)
            {
                return null;
            }
            for (int i = 0; i < App.Urls.Count; i++)
            {
                App.Urls[i].Opened = index == i;
            }
            return App.Urls[index].Url;
        }

        void WebView_ResetUrl()
        {
            int index = App.Urls.Count - 1;
            App.Urls.RemoveAt(index);
            SetUrlIndex(m_CurIndex = index);
            int count = webPanel.Children.Count;
            if (count > s_Index)
            {
                WebViewItem item = (WebViewItem)webPanel.Children[count - 1];
                item.Visibility = Visibility.Visible;
            }
        }

        void WebView_Back(object sender)
        {
            bool ok;
            int newIndex;
            if (m_LaunchUrl)
            {
                m_LaunchUrl = false;
                ok = TryGetUrlByBackAfterLaunchUrl(out newIndex);
            }
            else
            {
                ok = TryGetUrlByBackOrForward(false, out newIndex);
            }
            if (ok)
            {
                string url = SetUrlIndex(newIndex);
                if (!string.IsNullOrEmpty(url))
                {
                    m_Forward = false;
                    m_CurIndex = newIndex;
                    WebView webView = (WebView)sender;
                    webView.Url = url;
                }
            }
        }

        void WebView_Forward(object sender)
        {
            if (TryGetUrlByBackOrForward(true, out int newIndex))
            {
                string url = SetUrlIndex(newIndex);
                if (!string.IsNullOrEmpty(url))
                {
                    m_Forward = true;
                    m_CurIndex = newIndex;
                    WebView webView = (WebView)sender;
                    webView.Url = url;
                }
            }
        }

    }
}
