using EO.WebBrowser;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WindowsWPF.Controls;

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
            m_LaunchUrl = false;
            int count = container.Children.Count;
            bool attachEvents = !string.IsNullOrEmpty(e.TargetUrl);
            if (s_Index < count && attachEvents)
            {
                //忽略URL协议头
                string ignoreProtocol = Properties.Resources.IgnoreProtocol;
                if (!string.IsNullOrWhiteSpace(ignoreProtocol))
                {
                    //URL协议头
                    string protocol = e.TargetUrl.Split(':')[0];
                    bool ignore = ignoreProtocol.Split(',', ';', ' ').Any(i => i.Equals(protocol, StringComparison.OrdinalIgnoreCase));
                    if (ignore)
                    {
                        return;
                    }
                }

                NewTargetUrl = e.TargetUrl;
                WebViewItem item1 = (WebViewItem)container.Children[count - 1];
                item1.Visibility = Visibility.Collapsed;
                //Only 2 reserved
                if (s_Index + 1 < count)
                {
                    WebViewItem item0 = (WebViewItem)container.Children[s_Index];
                    DetachPage(item0.Page);
                    item0.Page.DetachPage();
                    item0.Page.WebControl.WebView.Close(true);
                    item0.Visibility = Visibility.Collapsed;
                }
            }

            //The new WebView has already been created (e.WebView). Here we
            //associates it with a new WebViewItem object and creates a
            //new tab button for it (by adding it to m_Pages)
            //WebViewItem item = NewWebViewItem(e.WebView, attachEvents);
            WebView webView = attachEvents ? new WebView() { Url = e.TargetUrl } : e.WebView;
            WebViewItem item = NewWebViewItem(webView, attachEvents);
            container.Children.Add(item);

#if DEBUG
            Debug.WriteLine("");
            count = container.Children.Count;
            for (int i = s_Index; i < count; i++)
            {
                WebViewItem item1 = (WebViewItem)container.Children[i];
                Debug.WriteLine($">> Browsers[{i}] {(i == count - 1 ? "New" : "Old")} >> {(i == count - 1 ? e.TargetUrl : item1.Page.WebView.Url)}");
            }
#endif

            //Signifies that we accept the new WebView. Without this line
            //the newly created WebView will be immediately destroyed
            if (!attachEvents) e.Accepted = true;
        }
        internal string NewTargetUrl;
        internal void WebView_CrashDataAvailable(object sender, EO.Base.CrashDataEventArgs e)
        {
            App.ShowError(new Exception(e.Message));
            Window_Exit();
        }

        private WebViewItem NewWebViewItem(WebView webView, bool attachEvents = true)
        {
            WebViewItem item = new WebViewItem(webView, attachEvents);
            m_CurPage = item.Page;
            m_WebView = item.Page.WebView;
            m_Forward = true;

            //Sets the shortcut for the new WebView object
            item.Page.WebView.Shortcuts = GetShortcuts();

            //Handles various events
            AttachPage(item.Page);
            return item;
        }

        //Web page loaded event
        private void WebView_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
#if DEBUG
            Debug.WriteLine($">> Browsers[{container.Children.Count - 1}] Ok  >> {e.Url}");
            Debug.WriteLine("");
#endif
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
                SetUrlIndex(m_CurIndex = count);
#if DEBUG
                for (int i = 0; i < App.Urls.Count; i++) Debug.WriteLine($">> App.Urls[{i}] = {App.Urls[i].Url}");
                Debug.WriteLine("");
#endif
            }
            else if (container.Children.Count > s_Index + 1)
            {
                int count = container.Children.Count;
                WebViewItem item0 = (WebViewItem)container.Children[count - 2];
                WebViewItem item1 = (WebViewItem)container.Children[count - 1];
                item1.Visibility = Visibility.Collapsed;
                item0.Visibility = Visibility.Visible;
            }
            //Init Background
            if (App.GridBackgroundUpdated) return;
            App.GridBackgroundUpdated = true;
            Times.Delay(3000);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                grid.Background = new SolidColorBrush(Colors.White);
                //BrushConverter bc = new BrushConverter();
                //Brush brush = (Brush)bc.ConvertFrom("#FFFFFF"); //bc.ConvertFromString("White");
                //brush.Freeze();
                //grid.Background = brush;
                Notifier.CreateMessage()
                    .Accent("#F15B19").Background("#1EA2E6")
                    .HasBadge("首页").HasMessage("加载完成")
                    .Dismiss().WithDelay(TimeSpan.FromSeconds(2))
                    .Queue();
            }));
        }

        //Web page loaded event
        private void WebView_LoadFailed(object sender, LoadFailedEventArgs e)
        {
#if DEBUG
            Debug.WriteLine($">> Browsers[{container.Children.Count - 1}] Fail >> {e.ErrorMessage} {e.Url}");
            Debug.WriteLine("");
#endif
            //if (e.ErrorCode == ErrorCode.Canceled || e.ErrorCode == ErrorCode.TimedOut || e.ErrorCode == ErrorCode.ConnectionTimeout) return;
            e.UseDefaultMessage();
            //if (e.ShouldShowError) App.ShowError(new Exception(e.ErrorMessage));
        }

        //Render Unresponsive
        void WebView_RenderUnresponsive(object sender, RenderUnresponsiveEventArgs e)
        {
#if DEBUG
            WebView webView = (WebView)sender;
            Debug.WriteLine($">> Browsers[{container.Children.Count - 1}] Render Unresponsive >> {webView.Url}");
            Debug.WriteLine("");
#endif
            //if (MessageBox.Show(this, "网页未响应或运行缓慢！", "警告", MessageBoxButton.YesNo) == MessageBoxResult.No) webView.Destroy();
            //if (!string.IsNullOrEmpty(webView.Url)) webView.Reload(true);
        }

        //Before Jump to web page
        void WebView_BeforeNavigate(object sender, BeforeNavigateEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($">> Browser-{WebViewItemIdPrefix}{e.NavigationType} {e.NewUrl}");
        }

        //WebView events
        void WebView_Activate(object sender, EventArgs e)
        {
            m_WebView.AllowDropLoad = false;
        }

        //WebView events
        void WebView_LaunchUrl(object sender, LaunchUrlEventArgs e)
        {
#if DEBUG
            Debug.WriteLine($">> Browser Launch >> {e.Url}{Environment.NewLine}   This Page >> {App.Urls[App.Urls.Count - 1].Url}{Environment.NewLine}");
#endif
            //跳过该应用程序的URL协议头
            string protocol = Properties.Resources.URLProtocol;
            if (e.Url.StartsWith(protocol + ":", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            //运行其它应用程序的URL协议头
            m_LaunchUrl = true;
            bool exists = false;
            protocol = e.Url.Split(':')[0];
            string path = "", s = RegistryTool.GetShortcut(protocol);
            if (!string.IsNullOrEmpty(s))
            {
                path = s.Split(' ')[0].Trim('"');
                exists = File.Exists(path);
            }
            if (!exists)
            {
                Dispatcher.BeginInvoke(new Action(() => { Alert("未安装目标应用程序！", MessageBoxImage.Warning, "警告"); WebView_Back(sender); }));
                return;
            }
            // Call ShellExecute in that event to pass that Url to the OS.
            e.UseOSHandler = true;
            //打开其他应用程序后隐藏自身(1:隐藏 2:隐藏且返回网址)
            string flag = Properties.Resources.HideAfterLaunchOtherApp;
            if (flag == "1")
            {
                Dispatcher.BeginInvoke(new Action(() => HideApp()));
            }
            else if (flag == "2")
            {
                Dispatcher.BeginInvoke(new Action(() => { HideApp(); WebView_Back(sender); }));
            }
        }

        //WebView events
        void WebView_Closed(object sender, WebViewClosedEventArgs e)
        {
            if (notifyIcon.IsDisposed)
            {
                return;
            }
            for (int i = s_Index; i < container.Children.Count; i++)
            {
                WebViewItem item = (WebViewItem)container.Children[i];
                if (Equals(item.Page.WebView, sender))
                {
                    item.Page.WebControl.WebView.Dispose();
                    item.Page.WebControl.Dispose();
                    container.Children.RemoveAt(i);
                    break;
                }
            }
            if (container.Children.Count == s_Index)
            {
                Close();
                return;
            }
            if (m_Download)
            {
                m_Download = false;
                WebView_ResetUrl();
            }
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
            //System.Diagnostics.Debug.WriteLine($">> Browser-{WebViewItemIdPrefix} {msg} {webView.Url}");
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
        void Alert(string message, MessageBoxImage image, string title = "消息")
        {
            MessageBox.Show(this, message, title, MessageBoxButton.OK, image);
        }
    }
}
