using EO.WebBrowser;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace BigScreenBrowser
{
    public partial class MainWindow
    {
        void AttachPage(WebPage page)
        {
            if (page.AttachEventsNeeded)
            {
                page.WebView.LoadCompleted += WebView_LoadCompleted;
                page.WebView.LoadFailed += WebView_LoadFailed;
                page.WebView.BeforeNavigate += WebView_BeforeNavigate;
                page.WebView.NewWindow += new NewWindowHandler(WebView_NewWindow);
                page.WebView.Activate += new EventHandler(WebView_Activate);
                page.WebView.LaunchUrl += new LaunchUrlHandler(WebView_LaunchUrl);
                page.WebView.Closed += new WebViewClosedEventHandler(WebView_Closed);
                page.WebView.JSExtInvoke += new JSExtInvokeHandler(WebView_JSExtInvoke);
                page.WebView.UrlChanged += new EventHandler(WebView_UrlChanged);
                page.WebView.IsLoadingChanged += new EventHandler(WebView_IsLoadingChanged);
                page.WebView.CanGoBackChanged += new EventHandler(WebView_CanGoBackChanged);
                page.WebView.CanGoForwardChanged += new EventHandler(WebView_CanGoForwardChanged);
                page.WebView.BeforeContextMenu += new BeforeContextMenuHandler(WebView_BeforeContextMenu);
                page.WebView.Command += new CommandHandler(WebView_Command);
                page.WebView.BeforeDownload += new BeforeDownloadHandler(WebView_BeforeDownload);
                page.WebView.DownloadCanceled += new DownloadEventHandler(WebView_DownloadCanceled);
                page.WebView.DownloadCompleted += new DownloadEventHandler(WebView_DownloadCompleted);
                page.WebView.FileDialog += new FileDialogHandler(WebView_FileDialog);
                page.WebView.JSDialog += new JSDialogEventHandler(WebView_JSDialog);
                page.WebView.StatusMessageChanged += new EventHandler(WebView_StatusMessageChanged);
                page.WebView.RenderUnresponsive += new RenderUnresponsiveEventHandler(WebView_RenderUnresponsive);

                //Update UI status
                WebView_UrlChanged(page.WebView, EventArgs.Empty);
                WebView_IsLoadingChanged(page.WebView, EventArgs.Empty);
                WebView_CanGoForwardChanged(page.WebView, EventArgs.Empty);
                WebView_CanGoBackChanged(page.WebView, EventArgs.Empty);
            }
        }

        void DetachPage(WebPage page)
        {
            if (page.AttachEventsNeeded)
            {
                page.WebView.LoadCompleted -= WebView_LoadCompleted;
                page.WebView.LoadFailed -= WebView_LoadFailed;
                page.WebView.BeforeNavigate -= WebView_BeforeNavigate;
                page.WebView.NewWindow -= new NewWindowHandler(WebView_NewWindow);
                page.WebView.Activate -= new EventHandler(WebView_Activate);
                page.WebView.LaunchUrl -= new LaunchUrlHandler(WebView_LaunchUrl);
                //page.WebView.Closed -= new WebViewClosedEventHandler(WebView_Closed);
                page.WebView.JSExtInvoke -= new JSExtInvokeHandler(WebView_JSExtInvoke);
                page.WebView.UrlChanged -= new EventHandler(WebView_UrlChanged);
                page.WebView.IsLoadingChanged -= new EventHandler(WebView_IsLoadingChanged);
                page.WebView.CanGoBackChanged -= new EventHandler(WebView_CanGoBackChanged);
                page.WebView.CanGoForwardChanged -= new EventHandler(WebView_CanGoForwardChanged);
                page.WebView.BeforeContextMenu -= new BeforeContextMenuHandler(WebView_BeforeContextMenu);
                page.WebView.Command -= new CommandHandler(WebView_Command);
                page.WebView.BeforeDownload -= new BeforeDownloadHandler(WebView_BeforeDownload);
                page.WebView.DownloadCanceled -= new DownloadEventHandler(WebView_DownloadCanceled);
                page.WebView.DownloadCompleted -= new DownloadEventHandler(WebView_DownloadCompleted);
                page.WebView.JSDialog -= new JSDialogEventHandler(WebView_JSDialog);
                page.WebView.StatusMessageChanged -= new EventHandler(WebView_StatusMessageChanged);
                page.WebView.RenderUnresponsive -= new RenderUnresponsiveEventHandler(WebView_RenderUnresponsive);
            }
        }

        //WebView events: https://www.essentialobjects.com/doc/webbrowser/advanced/new_window.aspx
        void WebView_NewWindow(object sender, NewWindowEventArgs e)
        {
            int count = grid.Children.Count;
            if (0 < count)
            {
                WebViewItem item1 = (WebViewItem)grid.Children[count - 1];
                DetachPage(item1.Page);
                item1.Page.DetachPage();
                item1.Page.WebControl.WebView.Close(false);
                item1.Visibility = Visibility.Collapsed;
            }

            //The new WebView has already been created (e.WebView). Here we
            //associates it with a new WebViewItem object and creates a
            //new tab button for it (by adding it to m_Pages)
            WebViewItem item = NewWebViewItem(e.WebView);

            //Signifies that we accept the new WebView. Without this line
            //the newly created WebView will be immediately destroyed
            e.Accepted = true;

            grid.Children.Add(item);
        }

        private WebViewItem NewWebViewItem(WebView webView)
        {
            WebViewItem item = new WebViewItem(webView, true);
            m_CurPage = item.Page;
            m_WebView = item.Page.WebView;
            m_Forward = true;

            //Sets the shortcut for the new WebView object
            item.Page.WebView.Shortcuts = GetShortcuts();

            //Handles various events
            AttachPage(item.Page);
            return item;
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

        //Web page loaded event
        private void WebView_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            //Add Url History
            if (!string.IsNullOrEmpty(e.Url))
            {
                if (!m_Forward)
                {
                    SetUrlIndex(m_CurIndex);
                    return;
                }
                int count = App.Urls.Count;
                if (count > 0 && App.Urls[count - 1].Url.Equals(e.Url)) return;
                App.Urls.Add(new WebViewItemUrl(e.Url, true));
                SetUrlIndex(count);
            }
            //Init Background
            if (App.GridBackgroundUpdated) return;
            App.GridBackgroundUpdated = true;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                BrushConverter bc = new BrushConverter();
                Brush brush = (Brush)bc.ConvertFrom("#FFFFFF"); //bc.ConvertFromString("White");
                brush.Freeze();
                App.MainWnd.grid.Background = brush;
                //App.MainWnd.grid.Background = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            }));
        }

        //Web page loaded event
        private void WebView_LoadFailed(object sender, LoadFailedEventArgs e)
        {
            e.UseDefaultMessage();
            if (e.ShouldShowError)
            {
                //MessageBox.Show(this, e.ErrorMessage, "提示", MessageBoxButton.OK);
            }
        }

        //Before Jump to web page
        void WebView_BeforeNavigate(object sender, BeforeNavigateEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($">> {WebViewItemIdPrefix}{e.NavigationType} {e.NewUrl}");
        }

        //WebView events
        void WebView_Activate(object sender, EventArgs e)
        {
            //m_WebView.AllowDropLoad = false;
        }

        //WebView events
        void WebView_LaunchUrl(object sender, LaunchUrlEventArgs e)
        {
            // Call ShellExecute in that event to pass that Url to the OS.
            e.UseOSHandler = true;
        }

        //WebView events
        void WebView_Closed(object sender, WebViewClosedEventArgs e)
        {
            for (int i = 0; i < grid.Children.Count; i++)
            {
                WebViewItem item = (WebViewItem)grid.Children[i];
                if (Equals(item.Page.WebView, sender))
                {
                    item.Page.WebControl.WebView.Dispose();
                    item.Page.WebControl.Dispose();
                    grid.Children.RemoveAt(i);
                    break;
                }
            }
            if (grid.Children.Count == 0)
            {
                Close();
            }
        }

        //This event handler is called when a context menu item or a hot key triggers a "command".
        //private static int m_F1Command = CommandIds.RegisterUserCommand("help");
        private static int m_DemoCommand = CommandIds.RegisterUserCommand("demo");
        private static int m_HomeCommand = CommandIds.RegisterUserCommand("home");
        private static int m_BackCommand = CommandIds.RegisterUserCommand("back");
        private static int m_ForwardCommand = CommandIds.RegisterUserCommand("forward");
        private static Shortcut[] GetShortcuts()
        {
            return new Shortcut[]
            {
                //new Shortcut(m_F1Command, KeyCode.F1),
                new Shortcut(CommandIds.Reload, KeyCode.F5), //刷新网页
                new Shortcut(CommandIds.ReloadNoCache, KeyCode.F5, true, false, false),
                new Shortcut(CommandIds.Reload, KeyCode.R, true, false, false), //重新加载
                new Shortcut(m_DemoCommand, KeyCode.D, false, true, false), //演示页面 Alt + D
                new Shortcut(m_HomeCommand, KeyCode.Home), //返回首页 Home
                new Shortcut(m_BackCommand, KeyCode.Left, false, true, false), //返回 Alt + ←
                new Shortcut(m_ForwardCommand, KeyCode.Right, false, true, false), //向前 Alt + →
            };
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
                if (TryGetUrlByBackOrForward(false, out int newIndex))
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
                return;
            }
            //向前 Alt + →
            if (e.CommandId == m_ForwardCommand || e.CommandId == CommandIds.Forward)
            {
                e.Handled = true;
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
                return;
            }
            //提示快捷键功能 F1
            //if (e.CommandId == m_F1Command)
            //{
            //    e.Handled = true;
            //    MessageBox.Show(HotkeyMessageBoxText, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}
        }

        //Render Unresponsive
        void WebView_RenderUnresponsive(object sender, RenderUnresponsiveEventArgs e)
        {
            //WebView webView = (WebView)sender;
            //if (MessageBox.Show(this, "网页未响应或运行缓慢！", "警告", MessageBoxButton.YesNo) == MessageBoxResult.No)
            //    webView.Destroy();
        }


        //This event handler is called when the Url property of the WebView changes.
        //This can happens if user clicks a link inside the WebView thus causing the
        //WebView to navigate to another page
        void WebView_UrlChanged(object sender, EventArgs e)
        {
        }

        //This event handler is called when the IsLoading property of the WebView
        //changes. It is set to true when the WebView starts loading a page and set
        //back to false when it finishes loading
        void WebView_IsLoadingChanged(object sender, EventArgs e)
        {
            //Update status bar to display "Loading..." or "Ready"
            WebView_StatusMessageChanged(sender, EventArgs.Empty);
        }

        //This event handler occurs when the WebView's StatusMessage property changes.
        //The status message can change when user moves mouse over to a link, in which
        //case the status message will change to display the link url
        void WebView_StatusMessageChanged(object sender, EventArgs e)
        {
            //WebView webView = (WebView)sender;
            //if (string.IsNullOrEmpty(webView.Url))
            //{
            //    return;
            //}
            //string msg = webView.StatusMessage;
            //if (string.IsNullOrEmpty(msg))
            //{
            //    if (webView.IsLoading)
            //    {
            //        msg = "Loading";
            //    }
            //    else
            //    {
            //        msg = "Ready";
            //    }
            //}
            //System.Diagnostics.Debug.WriteLine($">> {WebViewItemIdPrefix} {msg} {webView.Url}");
        }

        //This event handler is called when the CanGoBack property of the WebView
        //changes. CanGoBack becomes true when user has navigated from one page to another
        void WebView_CanGoBackChanged(object sender, EventArgs e)
        {
        }

        //This event handler is called when CanGoForward property of the WebView
        //changes. CanGoForward becomes true after WebView.GoBack has been called
        void WebView_CanGoForwardChanged(object sender, EventArgs e)
        {
        }

        //This event is called when the user right clicks in a WebView and it needs
        //to display a context menu. Here we creates the context menu to be displayed
        void WebView_BeforeContextMenu(object sender, BeforeContextMenuEventArgs e)
        {
            //Clear the default context menu
            e.Menu.Items.Clear();

            if (e.Menu.Items.HasPluginMenuItems())
                e.Menu.Items.Add(MenuItem.CreateSeparator());

            //Create new context menu items. Each menu item is associated to
            //a "Command". When the menu item is selected, WebView_Command is 
            //called (as event handler for the Command event) to handle the 
            //corresponding command
            e.Menu.Items.Add(new MenuItem("刷新", CommandIds.Reload));
            e.Menu.Items.Add(MenuItem.CreateSeparator());
            e.Menu.Items.Add(new MenuItem("回到", m_HomeCommand));
            e.Menu.Items.Add(MenuItem.CreateSeparator());
            e.Menu.Items.Add(new MenuItem("后退", m_BackCommand));
            e.Menu.Items.Add(new MenuItem("前进", m_ForwardCommand));
            //e.Menu.Items.Add(MenuItem.CreateSeparator());
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

        //This event handler is called to display a JavaScript dialog, for example,
        //when JavaScript code calls "window.alert" method.
        void WebView_JSDialog(object sender, JSDialogEventArgs e)
        {
            switch (e.DialogType)
            {
                case JSDialogType.Prompt:
                    //Create a dialog
                    JSPrompt dlg = new JSPrompt(e);
                    dlg.Owner = this;
                    dlg.Message = e.MessageText;
                    dlg.Value = e.DefaultPromptText;

                    //Display the dialog for user input
                    bool? result = dlg.ShowDialog();

                    //Call e.OK/e.Cancel based on whether user clicked "OK" in the dialog
                    if (result.HasValue && result.Value)
                        e.OK(dlg.Value);
                    else
                        e.Cancel();
                    break;

                case JSDialogType.Alert:
                    //Display a message box and then call e.OK to notify the browser
                    //engine that user has confirmed the dialog. This is important
                    //because either OK or Cancel must be called to prevent the default
                    //dialog
                    Alert(e.MessageText);
                    e.OK();
                    break;

                case JSDialogType.BeforeUnload:
                case JSDialogType.Confirm:
                    //Display a Yes/No message box and call e.OK/e.Cancel according
                    //to user's selection
                    if (MessageBox.Show(this, e.MessageText, "消息", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        e.OK();
                    }
                    else
                    {
                        e.Cancel();
                        //if (e.DialogType == JSDialogType.BeforeUnload)
                        //    m_bCloseRequested = false;
                    }
                    break;
            }
        }

        void Alert(string message)
        {
            MessageBox.Show(this, message, "消息", MessageBoxButton.OK);
        }

        //This event handler is called when a download starts
        void WebView_BeforeDownload(object sender, BeforeDownloadEventArgs e)
        {
            //e.Item.Url = "https://*.com/client/latest/installer.exe"
            string downloads = Properties.Resources.Downloads;
            if (!string.IsNullOrWhiteSpace(downloads))
            {
                var urls = downloads.Split(',', '，', ' ').Select(i => i.Trim()).Where(i => i.Length > 1);
                var url = new Uri(e.Item.Url).Authority.Split(':')[0];
                if (!urls.Any(i => url.EndsWith(i)))
                {
                    e.Item.Cancel();
                    return;
                }
            }
            //e.Item.ContentDisposition "attachment;filename=installer.exe"
            if (!e.Item.ContentDisposition.StartsWith("attachment", StringComparison.OrdinalIgnoreCase))
            {
                e.Item.Cancel();
                return;
            }
            if (double.TryParse(Properties.Resources.DownloadSize, out double downloadSize) && downloadSize > 0)
            {
                double size = e.Item.TotalBytes / 1024.0 / 1024;
                //string filesize = size.ToString("f0") + "MB";
                if (size > downloadSize)
                {
                    e.Item.Cancel();
                    return;
                }
            }
            //Modify save file path %TEMP%
            tmpSaveFilename = !string.IsNullOrWhiteSpace(e.FilePath) ? Path.GetFileName(e.FilePath) : e.Item.ContentDisposition.Split('=').LastOrDefault();
            if (string.IsNullOrWhiteSpace(tmpSaveFilename))
            {
                e.Item.Cancel();
                return;
            }
            e.FilePath = tmpSaveFilePath; //WebView_FileDialog: e.DefaultFileName
            //e.FilePath = Path.Combine(tmpSaveFilePath, tmpSaveFilename);
            //e.ShowDialog = false; //Download directly without displaying save dialog
        }

        //This event handler is called when a download has been canceled
        void WebView_DownloadCanceled(object sender, DownloadEventArgs e)
        {
        }

        void WebView_DownloadCompleted(object sender, DownloadEventArgs e)
        {
            WebView webView = (WebView)sender;
            if (webView.IsNewWindow || string.IsNullOrEmpty(webView.Url))
                webView.Close(false);
        }

        void WebView_FileDialog(object sender, FileDialogEventArgs e)
        {
            if (e.Mode == FileDialogMode.Save)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = tmpSaveFilename; //Or e.DefaultFileName
                //图像文件(*.bmp, *.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*
                string ext = "*." + (dlg.FileName.Contains(".") ? dlg.FileName.Split('.').Last() : "*");
                dlg.Filter = "所有文件(" + ext + ")|" + ext;
                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value) e.Continue(dlg.FileName);
                else e.Cancel();
            }
            if (e.Mode == FileDialogMode.Open)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "所有文件(*.*)|*.*";
                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value) e.Continue(dlg.FileName);
                else e.Cancel();
            }
            //Mark the event as handled
            e.Handled = true;
        }
    }
}
