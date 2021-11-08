using EO.WebBrowser;
using System;
using System.Windows;
using System.Windows.Threading;

namespace FullScreenBrowser
{
    public partial class MainWindow
    {
        void AttachPage(WebPage page)
        {
            if (page.AttachEventsNeeded)
            {
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

            //Update ConsolePane and ObjectsPane
            if (m_ConsolePane != null) m_ConsolePane.Attach(page.WebView, page.Messages);
        }

        void DetachPage(WebPage page)
        {
            if (page.AttachEventsNeeded)
            {
                page.WebView.BeforeNavigate -= WebView_BeforeNavigate;
                page.WebView.NewWindow -= new NewWindowHandler(WebView_NewWindow);
                page.WebView.Activate -= new EventHandler(WebView_Activate);
                page.WebView.LaunchUrl -= new LaunchUrlHandler(WebView_LaunchUrl);
                page.WebView.Closed -= new WebViewClosedEventHandler(WebView_Closed);
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
            //The old WebView
            WebView webView = (WebView)sender;

            //The new WebView has already been created (e.WebView). Here we
            //associates it with a new WebViewItem object and creates a
            //new tab button for it (by adding it to m_Pages)
            WebViewItem item = NewWebViewItem(e.WebView);
            m_WebViewsHost.Items.Add(item);

            //Signifies that we accept the new WebView. Without this line
            //the newly created WebView will be immediately destroyed
            e.Accepted = true;

            //Target=Self: If you do not want to open a new window but wish to open
            //the new Url in the same window, comment the code above
            //and uncomment the code below. The code below set the existing
            //WebView's Url to the new Url. Also because it did not set
            //e.Accepted to true, so the new WebView will be discarded.
            webView.Url = e.TargetUrl;

            //Target=Blank: Assume BrowserWnd is a Window class that contains a 
            //WebView. Here the code creates a new BrowserWnd object thus creating a new WebView
            //BrowserWnd wnd = new BrowserWnd();
            //Load the target Url into the new WebView
            //wnd.WebView.Url = e.TargetUrl;
            //Signifies that we accept the new window request
            //e.Accepted = true;
        }

        private WebViewItem NewWebViewItem(WebView webView)
        {
            bool attachEvents = (m_CurPage == null);
            WebViewItem item = new WebViewItem(webView, attachEvents);
            //Target=Self:
            if (attachEvents)
            {
                m_CurPage = item.Page;
                m_WebView = item.Page.WebView;
            }

            //Sets the shortcut for the new WebView object
            item.Page.WebView.Shortcuts = GetShortcuts();

            //Handles various events
            AttachPage(item.Page);
            //m_Pages.Add(item.Page);
            return item;
        }

        //Before Jump to web page
        void WebView_BeforeNavigate(object sender, BeforeNavigateEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($">> {WebViewItemIdPrefix}{e.NavigationType} {e.NewUrl}");
            Dispatcher.BeginInvoke((EO.Base.Action)(() => { StopFind(); }), DispatcherPriority.Normal);
            var count = m_WebViewsHost.Items.Count;
            if (0 < count)
            {
                WebViewItem item1 = (WebViewItem)m_WebViewsHost.Items[count - 1];
                if (item1.Page.AttachEventsNeeded) return;
                //DetachPage(item1.Page);
                //item1.Page.DetachPage();
                item1.Page.WebControl.WebView.Close(false);
                item1.Page.WebControl.WebView.Dispose();
                item1.Page.WebControl.Dispose();
            }
        }

        //WebView events
        void WebView_Activate(object sender, EventArgs e)
        {
            m_WebView.AllowDropLoad = false;
        }

        //WebView events
        void WebView_LaunchUrl(object sender, LaunchUrlEventArgs e)
        {
            e.UseOSHandler = true;
        }

        //WebView events
        void WebView_Closed(object sender, WebViewClosedEventArgs e)
        {
            for (int i = 0; i < m_WebViewsHost.Items.Count; i++)
            {
                WebViewItem item = (WebViewItem)m_WebViewsHost.Items[i];
                if (Equals(item.Page.WebView, sender))
                {
                    m_WebViewsHost.Items.RemoveAt(i);
                    //m_Pages[i].WebControl.Dispose();
                    //m_Pages.RemoveAt(i);
                    break;
                }
            }
            if (m_WebViewsHost.Items.Count == 0)
            {
                Close();
            }
        }

        //This event handler is called when a context menu item or a hot key triggers a "command".
        private static int m_HomeCommand = CommandIds.RegisterUserCommand("home");
        private static int m_F1Command = CommandIds.RegisterUserCommand("help");
        private static int m_AltACommand = CommandIds.RegisterUserCommand("AltA");
        private static int m_AltQCommand = CommandIds.RegisterUserCommand("AltQ");
        private static Shortcut[] GetShortcuts()
        {
            return new Shortcut[]
            {
                new Shortcut(m_HomeCommand, KeyCode.Home),
                new Shortcut(m_F1Command, KeyCode.F1),
                new Shortcut(m_AltACommand, KeyCode.A, false, true, false),
                new Shortcut(m_AltQCommand, KeyCode.Q, false, true, false),
                new Shortcut(CommandIds.Reload, KeyCode.F5),
                //new Shortcut(CommandIds.Back, KeyCode.B, true, false, false),
                //new Shortcut(CommandIds.Forward, KeyCode.F, true, false, false),
            };
        }
        //Here we only handle our own custom commands
        void WebView_Command(object sender, CommandEventArgs e)
        {
            WebView webView = (WebView)sender;
            //返回首页 Home
            if (e.CommandId == m_HomeCommand)
            {
                webView.Url = m_HomeURL;
                e.Handled = true;
                return;
            }
            //提示快捷键功能 F1
            if (e.CommandId == m_F1Command)
            {
                MessageBox.Show(HotkeyMessageBoxText, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // 快捷键 Alt+A 截图
            if (e.CommandId == m_AltACommand)
            {
                if (screenCut != null && screenCut.IsActive) return;
                screenCut = new WindowsWPF.Controls.ScreenCut { Topmost = true, ShowInTaskbar = false };
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => screenCut.ShowDialog()));
                return;
            }
            // 快捷键 Alt+Q 询问关闭该应用程序
            if (e.CommandId == m_AltQCommand)
            {
                Window_ComfirmExit();
                return;
            }
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
            WebView webView = (WebView)sender;
            txtUrl.Text = webView.Url;
            if (m_WebView != null)
            {
                btnGoBack.IsEnabled = m_WebView.CanGoBack;
                btnGoForward.IsEnabled = m_WebView.CanGoForward;
            }
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
            WebView webView = (WebView)sender;
            if (string.IsNullOrEmpty(webView.Url))
            {
                return;
            }
            string msg = webView.StatusMessage;
            if (string.IsNullOrEmpty(msg))
            {
                if (webView.IsLoading)
                {
                    msg = "Loading";
                    if (dropDownMenus.IsEnabled == true) dropDownMenus.IsEnabled = false;
                }
                else
                {
                    msg = "Ready";
                    if (dropDownMenus.IsEnabled == false) dropDownMenus.IsEnabled = true;
                }
            }
            System.Diagnostics.Debug.WriteLine($">> {WebViewItemIdPrefix} {msg} {webView.Url}");
        }

        //This event handler is called when the CanGoBack property of the WebView
        //changes. CanGoBack becomes true when user has navigated from one page to another
        void WebView_CanGoBackChanged(object sender, EventArgs e)
        {
            if (m_WebView != null) btnGoBack.IsEnabled = m_WebView.CanGoBack;
        }

        //This event handler is called when CanGoForward property of the WebView
        //changes. CanGoForward becomes true after WebView.GoBack has been called
        void WebView_CanGoForwardChanged(object sender, EventArgs e)
        {
            if (m_WebView != null) btnGoForward.IsEnabled = m_WebView.CanGoForward;
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
            e.Menu.Items.Add(new MenuItem("首页", m_HomeCommand));
            e.Menu.Items.Add(MenuItem.CreateSeparator());
            e.Menu.Items.Add(new MenuItem("后退", CommandIds.Back));
            e.Menu.Items.Add(new MenuItem("前进", CommandIds.Forward));
            e.Menu.Items.Add(MenuItem.CreateSeparator());
            e.Menu.Items.Add(new MenuItem("源码", CommandIds.ViewSource));
            //e.Menu.Items.Add(MenuItem.CreateSeparator());
            //e.Menu.Items.Add(new MenuItem("打印", CommandIds.Print));

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
                    MessageBox.Show(this, e.MessageText, "提示", MessageBoxButton.OK);
                    e.OK();
                    break;

                case JSDialogType.BeforeUnload:
                case JSDialogType.Confirm:
                    //Display a Yes/No message box and call e.OK/e.Cancel according
                    //to user's selection
                    if (MessageBox.Show(this, e.MessageText, "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        //This event handler is called when a download starts
        void WebView_BeforeDownload(object sender, BeforeDownloadEventArgs e)
        {
            WebView webView = (WebView)sender;

            //Add it to our download list
            m_Downloads.Add(e.Item);

            //Set ShowDialog to true to display "Save As" dialog
            e.ShowDialog = true;

            //Display the "Downloads" pane
            mnuDownloads_Click(webView, null);
        }

        //This event handler is called when a download has been canceled
        void WebView_DownloadCanceled(object sender, DownloadEventArgs e)
        {
            m_Downloads.Remove(e.Item);
        }

        void WebView_DownloadCompleted(object sender, DownloadEventArgs e)
        {
            WebView webView = (WebView)sender;
            if (webView.IsNewWindow && string.IsNullOrEmpty(webView.Url))
                webView.Close(false);
        }

        void WebView_FileDialog(object sender, FileDialogEventArgs e)
        {
            if (e.Mode == FileDialogMode.Save)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = e.DefaultFileName;

                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value)
                    e.Continue(dlg.FileName);
                else
                    e.Cancel();

                //Mark the event as handled
                e.Handled = true;
            }
            if (e.Mode == FileDialogMode.Open)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "*.*";
                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value)
                    e.Continue(dlg.FileName);
                else
                    e.Cancel();

                //Mark the event as handled
                e.Handled = true;
            }
        }

        //JavaScript code
        void WebView_JSExtInvoke(object sender, JSExtInvokeArgs e)
        {
            switch (e.FunctionName)
            {
                case "about":
                    About.Show(this);
                    break;
            }
        }
    }
}
