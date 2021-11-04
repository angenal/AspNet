using EO.WebBrowser;
using EO.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string WebViewItemIdPrefix = "WebView:";
        private static int m_nHomeCommand = CommandIds.RegisterUserCommand("home");

        private BareButton m_BtnGoBack;
        private BareButton m_btnGoForward;
        private TextBox m_txtUrl;
        private UIElement m_panFind;
        private TextBox m_txtFind;
        private BareButton m_btnFindPrevious;
        private BareButton m_btnFindNext;
        private Label m_lblFindCount;
        private TextBlock m_lblStatus;
        private DockContainer m_DockContainer;
        private WebPage m_CurPage;
        private DockView m_WebViewsHost;
        private DockView m_ToolViews;
        private ConsolePane m_ConsolePane;
        private ObjectsPane m_ObjectsPane;
        private ObservableCollection<WebPage> m_Pages = new ObservableCollection<WebPage>();
        private ObservableCollection<DownloadItem> m_Downloads = new ObservableCollection<DownloadItem>();
        private string m_szLayoutFileName;
        private bool m_bCloseRequested;

        public MainWindow()
        {
            InitializeComponent();

            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = System.IO.Path.Combine(dir, "EO.Total");
            System.IO.Directory.CreateDirectory(dir);
            m_szLayoutFileName = System.IO.Path.Combine(dir, "UILayout.xml");
        }

        #region Window Related Functions/Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the DockView layout. This will load all pages that were 
            //previously loaded (each page represented by a WebViewItem
            //object in m_WebViewsHost's Items collection). This will call
            //dockContainer_DockViewNeeded/dockContainer_DockItemNeeded
            //if needed
            m_DockContainer = UIElementHelper.GetVisualChild(mainTabs, "dockContainer") as DockContainer;
            m_DockContainer.LoadLayout(m_szLayoutFileName);

            //If we do not have any page loaded, load an empty page
            if ((m_WebViewsHost == null) || !m_WebViewsHost.HasItems)
                m_DockContainer.ActivateItem(WebViewItemIdPrefix);

            //Create the tab items and get the child controls inside the TabControl.
            //Unlike a regular TabControl has a separate Header and Content for each
            //tab, this TabControl only has a single content page (but does have
            //multiple headers). We use this technique to avoid creating duplicate
            //UI elements such as the "Back", "Forward" button and Url textbox.
            mainTabs.ItemsSource = m_Pages;
            mainTabs.ApplyTemplate();
            m_BtnGoBack = UIElementHelper.GetVisualChild(mainTabs, "btnGoBack") as BareButton;
            m_btnGoForward = UIElementHelper.GetVisualChild(mainTabs, "btnGoForward") as BareButton;
            m_txtUrl = UIElementHelper.GetVisualChild(mainTabs, "txtUrl") as TextBox;
            m_panFind = UIElementHelper.GetVisualChild(mainTabs, "panFind") as UIElement;
            m_txtFind = UIElementHelper.GetVisualChild(mainTabs, "txtFind") as TextBox;
            m_btnFindPrevious = UIElementHelper.GetVisualChild(mainTabs, "btnFindPrevious") as BareButton;
            m_btnFindNext = UIElementHelper.GetVisualChild(mainTabs, "btnFindNext") as BareButton;
            m_lblFindCount = UIElementHelper.GetVisualChild(mainTabs, "lbFindCount") as Label;
            m_lblStatus = UIElementHelper.GetVisualChild(mainTabs, "lblStatus") as TextBlock;

            //Select the first page
            mainTabs.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Save the docking view UI layout
            if (!m_bCloseRequested)
            {
                try
                {
                    m_DockContainer.SaveLayout(m_szLayoutFileName);
                }
                catch (Exception ex)
                {
                    //This may fail due to permission issues
                    MessageBox.Show("Failed to save docking view layout:" + ex.ToString());
                }
            }

            //If we still have tab open, we should only request
            //the current tab to close in case the current tab
            //needs to fire beforeUnload event. If user confirms,
            //then WebView_Closed event will be triggered and
            //at that time we will request the next WebView to
            //close. When all WebViews are closed, we will hit
            //here again
            if (m_Pages.Count > 0)
            {
                m_bCloseRequested = true;

                RequestCurrentTabToClose();

                e.Cancel = true;
            }
        }

        private void RequestCurrentTabToClose()
        {
            int selectedIndex = mainTabs.SelectedIndex;
            if (selectedIndex < 0)
                selectedIndex = 0;

            WebPage curPage = m_Pages[selectedIndex];
            curPage.WebView.Close(false);
        }

        #endregion

        #region DockView Related Functions/Handlers
        //This event handler is called when DockContainer.LoadLayout creates a
        //new DockView based on the previously saved layout xml file
        private void dockContainer_DockViewAdded(object sender, DockViewEventArgs e)
        {
            if (e.DockView.IsDocumentView)
            {
                m_WebViewsHost = e.DockView;
                m_WebViewsHost.HeaderVisible = false;
                m_WebViewsHost.AutoItemIdPrefix = WebViewItemIdPrefix;
            }
            else if (m_ToolViews == null)
            {
                m_ToolViews = e.DockView;
            }
        }

        //This event handler is called when DockContainer.ActivateItem is called
        //and the DockContainer can not find an existing DockView that has been
        //previously associated to that item
        private void dockContainer_DockViewNeeded(object sender, DockViewNeededEventArgs e)
        {
            if (e.ItemId.StartsWith(WebViewItemIdPrefix))
            {
                if (m_WebViewsHost == null)
                {
                    m_WebViewsHost = new DockView();
                    m_WebViewsHost.IsDocumentView = true;
                }
                e.DockView = m_WebViewsHost;
            }
            else
            {
                if (m_ToolViews == null)
                {
                    m_ToolViews = new DockView();
                    m_ToolViews.Dock = Dock.Bottom;
                    m_ToolViews.Height = 150;
                }
                e.DockView = m_ToolViews;
            }
        }

        //This event handler is called when DockContainer.ActivateItem is called but
        //the item has not been loaded yet
        private void dockContainer_DockItemNeeded(object sender, DockItemNeededEventArgs e)
        {
            switch (e.ItemId)
            {
                case "Downloads":
                    e.Item = DockItem.LoadFrom(new Uri("/TabbedBrowser;component/downloadspane.xaml", System.UriKind.Relative), "Downloads");
                    DownloadsPane downloadsPane = (DownloadsPane)e.Item.Content;
                    downloadsPane.Bind(m_Downloads);
                    break;
                case "Console":
                    e.Item = DockItem.LoadFrom(new Uri("/TabbedBrowser;component/consolepane.xaml", System.UriKind.Relative), "Console");
                    m_ConsolePane = (ConsolePane)e.Item.Content;
                    break;
                case "Objects":
                    e.Item = DockItem.LoadFrom(new Uri("/TabbedBrowser;component/objectspane.xaml", System.UriKind.Relative), "Objects Explorer");
                    m_ObjectsPane = (ObjectsPane)e.Item.Content;
                    break;
                default:
                    if (e.ItemId.StartsWith(WebViewItemIdPrefix))
                    {
                        WebViewItem item = NewWebViewItem(null);
                        e.Item = item;
                        m_Pages.Add(item.Page);
                    }
                    break;
            }
        }
        #endregion

        #region TabControl Related Functions/Handlers
        //This event handler is called when the "New Item" button of the tab control is clicked
        private void mainTabs_NewItemRequested(object sender, EO.Wpf.NewItemRequestedEventArgs e)
        {
            //Creates a new WebViewItem and added it into m_WebViewHost
            WebViewItem item = NewWebViewItem(null);
            m_WebViewsHost.Items.Add(item);

            //e.DataItem must be properly set in order for the TabControl
            //to correctly select the newly created tab
            e.DataItem = item.Page;

            //Updates the data source of the TabControl, this also creates
            //the tab item for the new page
            m_Pages.Add(item.Page);
        }

        private WebViewItem NewWebViewItem(EO.WebBrowser.WebView webView)
        {
            WebViewItem item = new WebViewItem(webView, mainTabs);

            //Sets the shortcut for the new WebView object
            item.Page.WebView.Shortcuts = new Shortcut[]
                        {
                            new Shortcut(m_nHomeCommand, KeyCode.F11),
                            new Shortcut(CommandIds.Back, KeyCode.B, true, false, false),
                            new Shortcut(CommandIds.Forward, KeyCode.F, true, false, false),
                        };

            //Handles various WebView events
            item.Page.WebView.Closed += new WebViewClosedEventHandler(WebView_Closed);
            item.Page.WebView.JSExtInvoke += new JSExtInvokeHandler(WebView_JSExtInvoke);
            item.Page.WebView.NewWindow += new NewWindowHandler(WebView_NewWindow);
            item.Page.WebView.Activate += new EventHandler(WebView_Activate);
            item.Page.WebView.LaunchUrl += new LaunchUrlHandler(WebView_LaunchUrl);
            item.Page.WebView.RequestPermissions += WebView_RequestPermissions;
            item.Page.WebView.CertificateError += WebView_CertificateError;

            return item;
        }

        private void WebView_CertificateError(object sender, CertificateErrorEventArgs e)
        {
            e.Continue();
        }

        private void mainTabs_PreviewItemClose(object sender, TabItemCloseEventArgs e)
        {
            //Get the selected tab index and close the corresponding WebView 
            //object. This may trigger the onunload JavaScript event handler 
            //in the page and user may choose to cancel. If there is no onunload
            //handler or user chose "OK", then WebView_Closed event handler
            //will be called
            int index = e.ItemIndex;
            WebViewItem item = (WebViewItem)m_WebViewsHost.Items[index];
            item.Page.WebView.Close(false);

            //Always cancel this event because the actual closing is handled
            //by Webview_Closed event
            e.Canceled = true;
        }

        private void mainTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = mainTabs.SelectedIndex;
            if (selectedIndex < 0)
                return;

            WebPage curPage = m_Pages[selectedIndex];
            if (!object.Equals(curPage, m_CurPage))
            {
                //The current WebView changes. So we need to disconnect the previous
                //WebView from various event handler and reconnect them to the current
                //WebView
                if (m_CurPage != null)
                    DetachPage(m_CurPage);
                m_CurPage = curPage;
                AttachPage(m_CurPage);
            }

            m_WebViewsHost.SelectedItemIndex = selectedIndex;
        }
        #endregion

        #region Navigation UI Related Functions/Handlers
        private void txtUrl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WebViewItem item = (WebViewItem)m_WebViewsHost.SelectedItem;
                item.Page.WebView.Url = m_txtUrl.Text.Trim();
            }
        }

        private void txtUrl_GotFocus(object sender, RoutedEventArgs e)
        {
            m_txtUrl.SelectAll();
        }

        private void txtUrl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!m_txtUrl.IsKeyboardFocusWithin)
            {
                m_txtUrl.Focus();
                m_txtUrl.SelectAll();
                e.Handled = true;
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            m_CurPage.WebView.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            m_CurPage.WebView.GoForward();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            if ((m_CurPage != null) &&
                !string.IsNullOrEmpty(m_CurPage.WebView.Url))
            {
                m_CurPage.WebView.Reload(true);
            }
        }
        #endregion

        #region Find Related Functions/Handlers
        private FindSession m_FindSession;

        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (m_CurPage != null)
            {
                if (m_panFind.Visibility == Visibility.Visible)
                    StopFind();
                else
                {
                    m_panFind.Visibility = Visibility.Visible;
                    m_txtFind.Focus();
                }
            }
        }
        private void txtFind_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Find(true);
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            StopFind(false);
        }

        private void btnFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            Find(false);
        }

        private void btnFindClose_Click(object sender, RoutedEventArgs e)
        {
            if (m_CurPage != null)
                StopFind();
        }

        private void btnFindNext_Click(object sender, RoutedEventArgs e)
        {
            Find(true);
        }

        private void Find(bool forward)
        {
            if (m_CurPage == null)
                return;

            string txtToFind = m_txtFind.Text.Trim();
            if (txtToFind == string.Empty)
                return;

            if (m_FindSession == null)
            {
                m_FindSession = m_CurPage.WebView.StartFindSession(txtToFind, false);
                m_FindSession.Updated += FindSession_Updated;
            }
            else if (forward)
                m_FindSession.Next();
            else
                m_FindSession.Previous();
        }

        private void FindSession_Updated(object sender, EventArgs e)
        {
            UpdateFindUI();
        }

        private void StopFind(bool hideFindPanel = true)
        {
            if (hideFindPanel)
                m_panFind.Visibility = Visibility.Collapsed;
            if (m_FindSession != null)
            {
                m_FindSession.Stop();
                m_FindSession.Updated -= FindSession_Updated;
                m_FindSession = null;
            }
            UpdateFindUI();
        }

        private void UpdateFindUI()
        {
            string txtToFind = m_txtFind.Text.Trim();
            if (txtToFind == string.Empty)
            {
                m_btnFindPrevious.IsEnabled = false;
                m_btnFindNext.IsEnabled = false;
                m_lblFindCount.Content = string.Empty;
            }
            else if (m_FindSession == null)
            {
                m_btnFindPrevious.IsEnabled = false;
                m_btnFindNext.IsEnabled = true;
                m_lblFindCount.Content = string.Empty;
            }
            else
            {
                m_btnFindPrevious.IsEnabled = m_FindSession.MatchCount > 0;
                m_btnFindNext.IsEnabled = m_FindSession.MatchCount > 0;
                m_lblFindCount.Content = string.Format("{0}/{1}", m_FindSession.CurrentMatchIndex + 1, m_FindSession.MatchCount);
            }
        }
        #endregion

        #region Menu Related Functions/Handlers

        private void Menu_Opened(object sender, RoutedEventArgs e)
        {
            EO.Wpf.MenuItem menuItem;
            menuItem = UIElementHelper.GetVisualChild(mainTabs, "mnuDownloads") as EO.Wpf.MenuItem;
            menuItem.IsChecked = m_DockContainer.GetItemById("Downloads") != null;
            menuItem = UIElementHelper.GetVisualChild(mainTabs, "mnuConsole") as EO.Wpf.MenuItem;
            menuItem.IsChecked = m_DockContainer.GetItemById("Console") != null;
        }

        private void mnuDownloads_Click(object sender, RoutedEventArgs e)
        {
            m_DockContainer.ActivateItem("Downloads");
        }

        private void mnuConsole_Click(object sender, RoutedEventArgs e)
        {
            m_DockContainer.ActivateItem("Console");
            if (m_CurPage != null)
                m_ConsolePane.Attach(m_CurPage);
        }

        private void mnuObjects_Click(object sender, RoutedEventArgs e)
        {
            m_DockContainer.ActivateItem("Objects");
            if (m_CurPage != null)
                m_ObjectsPane.Attach(m_CurPage);
        }

        private void mnuDebugUI_Click(object sender, RoutedEventArgs e)
        {
            EO.WebBrowser.WebView.ShowDebugUI();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            DemoAbout(null);
        }

        private void mnuEmbeddedPage_Click(object sender, RoutedEventArgs e)
        {
            string url = SampleHandler.EmbeddedPageUrl;
            m_DockContainer.ActivateItem(WebViewItemIdPrefix + url);
            mainTabs.SelectedIndex = m_WebViewsHost.SelectedItemIndex;
            m_Pages[m_WebViewsHost.SelectedItemIndex].WebView.Url = url;
        }

        private void mnuJSFunction_Click(object sender, RoutedEventArgs e)
        {
            WebPage page = m_Pages[m_WebViewsHost.SelectedItemIndex];
            if (page.WebView.Url != SampleHandler.EmbeddedPageUrl)
            {
                MessageBox.Show(this, "Please open and select the \"Embedded Page Sample\" sample page first.");
                return;
            }

            JSObject window = page.WebView.GetDOMWindow();
            if (window == null)
            {
                MessageBox.Show(this, "Can not get the JavaScript window object (the page may not have been fully loaded yet, please try again later).");
                return;
            }
            JSFunction function = window["displayDotNetVersion"] as JSFunction;
            if (function == null)
            {
                MessageBox.Show(this, "Function \"displayDotNetVersion\" does not exist in the page.");
                return;
            }

            string dotNetVersion = System.Environment.Version.ToString();
            try
            {
                object retValue = function.Invoke(window, new object[] { dotNetVersion });

                MessageBox.Show(this, "JavaScript function \"displayDotNetVersion\" called and returned " + retValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "An error has occurred: " + ex.Message);
            }
        }

        private void mnuPDFViewer_Click(object sender, RoutedEventArgs e)
        {
            TabbedBrowser.PdfViewer viewer = new TabbedBrowser.PdfViewer();
            viewer.Show();
        }

        private void DemoAbout(string browserAppName)
        {
            if (!string.IsNullOrEmpty(browserAppName))
                browserAppName = "Browser Engine: " + browserAppName;
            About.Show(this, browserAppName);
        }

        #endregion

        #region WebView Related Functions/Handlers

        private void DetachPage(WebPage page)
        {
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
            page.WebView.BeforeNavigate -= WebView_BeforeNavigate;

            StopFind();
        }

        private void AttachPage(WebPage page)
        {
            page.WebView.UrlChanged += new EventHandler(WebView_UrlChanged);
            page.WebView.IsLoadingChanged += new EventHandler(WebView_IsLoadingChanged);
            page.WebView.CanGoBackChanged += new EventHandler(WebView_CanGoBackChanged);
            page.WebView.CanGoForwardChanged += new EventHandler(WebView_CanGoForwardChanged);
            page.WebView.BeforeContextMenu += new BeforeContextMenuHandler(WebView_BeforeContextMenu);
            page.WebView.Command += new CommandHandler(WebView_Command);
            page.WebView.BeforeDownload += new BeforeDownloadHandler(WebView_BeforeDownload);
            page.WebView.DownloadCanceled += new DownloadEventHandler(WebView_DownloadCanceled);
            page.WebView.DownloadCompleted += new DownloadEventHandler(WebView_DownloadCompleted);
            page.WebView.JSDialog += new JSDialogEventHandler(WebView_JSDialog);
            page.WebView.StatusMessageChanged += new EventHandler(WebView_StatusMessageChanged);
            page.WebView.RenderUnresponsive += new RenderUnresponsiveEventHandler(WebView_RenderUnresponsive);
            page.WebView.BeforeNavigate += WebView_BeforeNavigate;

            //Update UI status
            WebView_UrlChanged(this, EventArgs.Empty);
            WebView_IsLoadingChanged(this, EventArgs.Empty);
            WebView_CanGoForwardChanged(this, EventArgs.Empty);
            WebView_CanGoBackChanged(this, EventArgs.Empty);

            //Update ConsolePane and ObjectsPane
            if (m_ConsolePane != null)
                m_ConsolePane.Attach(page);
            if (m_ObjectsPane != null)
                m_ObjectsPane.Attach(page);
        }

        private void WebView_BeforeNavigate(object sender, BeforeNavigateEventArgs e)
        {
            Dispatcher.BeginInvoke((EO.Base.Action)(() =>
            {
                StopFind();
            }), System.Windows.Threading.DispatcherPriority.Normal);
        }

        void WebView_RenderUnresponsive(object sender, RenderUnresponsiveEventArgs e)
        {
            EO.WebBrowser.WebView webView = (EO.WebBrowser.WebView)sender;
            if (MessageBox.Show(this,
                string.Format("Page '{0}' has become unresponsive. Do you want to continue to wait for it to become responsive? Click 'Yes' to continue to wait, click 'No' to kill the page.", webView.Title),
                "Page Unresponsive", MessageBoxButton.YesNo) == MessageBoxResult.No)
                webView.Destroy();
        }

        //This event handler is called when the Url property of the WebView changes.
        //This can happens if user clicks a link inside the WebView thus causing the
        //WebView to navigate to another page
        void WebView_UrlChanged(object sender, EventArgs e)
        {
            m_txtUrl.Text = m_CurPage.WebView.Url;
        }

        //This event handler is called when the IsLoading property of the WebView
        //changes. It is set to true when the WebView starts loading a page and set
        //back to false when it finishes loading
        void WebView_IsLoadingChanged(object sender, EventArgs e)
        {
            //Attach the WebView to m_ObjectsPane only when the WebView has
            //finished loading
            if (m_CurPage.WebView.IsLoading)
            {
                if (m_ObjectsPane != null)
                    m_ObjectsPane.Attach(null);
            }
            else
            {
                if (m_ObjectsPane != null)
                    m_ObjectsPane.Attach(m_CurPage);
            }

            //Update status bar to display "Loading..." or "Ready"
            WebView_StatusMessageChanged(this, EventArgs.Empty);
        }

        //This event handler is called when the CanGoBack property of the WebView
        //changes. CanGoBack becomes true when user has navigated from one page to
        //another
        void WebView_CanGoBackChanged(object sender, EventArgs e)
        {
            m_BtnGoBack.IsEnabled = m_CurPage.WebView.CanGoBack;
        }

        //This event handler is called when CanGoForward property of the WebView
        //changes. CanGoForward becomes true after WebView.GoBack has been called
        void WebView_CanGoForwardChanged(object sender, EventArgs e)
        {
            m_btnGoForward.IsEnabled = m_CurPage.WebView.CanGoForward;
        }

        //This event handler is called when an existing WebView needs to open a new
        //window. For example, when user clicks a link whose "target" is set to a
        //window name that does not point to any existing window yet, in that case
        //a new WebView will be created and we will be notified in order to properly
        //display that newly created WebView. Here we simply create a new tab for it
        void WebView_NewWindow(object sender, NewWindowEventArgs e)
        {            
            //The new WebView has already been created (e.WebView). Here we
            //associates it with a new WebViewItem object and creates a
            //new tab button for it (by adding it to m_Pages)
            WebViewItem item = NewWebViewItem(e.WebView);
            m_WebViewsHost.Items.Add(item);
            m_Pages.Add(item.Page);

            //Select the newly created tab
            mainTabs.SelectedIndex = m_Pages.Count - 1;

            //Signifies that we accept the new WebView. Without this line
            //the newly created WebView will be immediately destroyed
            e.Accepted = true;

            //If you do not want to open a new window but wish to open
            //the new Url in the same window, comment the code above
            //and uncomment the code below. The code below set the existing
            //WebView's Url to the new Url. Also because it did not set
            //e.Accepted to true, so the new WebView will be discarded.
            //EO.WebBrowser.WebView webView = (EO.WebBrowser.WebView)sender;
            //webView.Url = e.TargetUrl;
        }

        //This event handler is called when a WebView is being activated by another
        //WebView. For example, when user clicks a link whose "target" is set to a
        //window name that points to an existing window. In that case the target
        //window will be "activated". At here we simply select the corresponding tab
        void WebView_Activate(object sender, EventArgs e)
        {
            for (int i = 0; i < m_Pages.Count; i++)
            {
                if (object.Equals(m_Pages[i].WebView, sender))
                {
                    mainTabs.SelectedIndex = i;
                    break;
                }
            }
        }

        //This event handler is called when user clicks a Url with a scheme
        //that is not natively handled by the browser, such as "mailto:" urls.
        //Here we set e.UseOSHandler to true to allow the OS to handle such 
        //urls.
        void WebView_LaunchUrl(object sender, LaunchUrlEventArgs e)
        {
            e.UseOSHandler = true;
        }

        //This event handler is called when WebView.Close is called (which happens
        //inside mainTabs_PreviewItemClose). At here we remove the corresponding
        //WebViewItem and tab item
        void WebView_Closed(object sender, WebViewClosedEventArgs e)
        {
            for (int i = 0; i < m_WebViewsHost.Items.Count; i++)
            {
                WebViewItem item = (WebViewItem)m_WebViewsHost.Items[i];
                if (object.Equals(item.Page.WebView, sender))
                {
                    m_WebViewsHost.Items.RemoveAt(i);
                    m_Pages[i].WebControl.Dispose();
                    m_Pages.RemoveAt(i);
                    if (m_Pages.Count == 0)
                        Close();
                    else if (m_bCloseRequested)
                        RequestCurrentTabToClose();
                    break;
                }
            }
        }

        //This event handler occurs when the WebView's StatusMessage property changes.
        //The status message can change when user moves mouse over to a link, in which
        //case the status message will change to display the link url.
        void WebView_StatusMessageChanged(object sender, EventArgs e)
        {
            string msg = m_CurPage.WebView.StatusMessage;
            if (string.IsNullOrEmpty(msg))
            {
                if (m_CurPage.WebView.IsLoading)
                    msg = "Loading...";
                else
                    msg = "Ready";
            }
            m_lblStatus.Text = msg;
        }

        //This event is called when the user right clicks in a WebView and it needs
        //to display a context menu. Here we creates the context menu to be displayed
        void WebView_BeforeContextMenu(object sender, BeforeContextMenuEventArgs e)
        {
            //Clear the default context menu
            e.Menu.Items.Clear();

            if (e.Menu.Items.HasPluginMenuItems())
                e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator());

            //Create new context menu items. Each menu item is associated to
            //a "Command". When the menu item is selected, WebView_Command is 
            //called (as event handler for the Command event) to handle the 
            //corresponding command
            e.Menu.Items.Add(new EO.WebBrowser.MenuItem("Essential Objects Homepage", m_nHomeCommand));
            e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator());
            e.Menu.Items.Add(new EO.WebBrowser.MenuItem("Back", CommandIds.Back));
            e.Menu.Items.Add(new EO.WebBrowser.MenuItem("Forward", CommandIds.Forward));
            e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator());
            e.Menu.Items.Add(new EO.WebBrowser.MenuItem("View Source", CommandIds.ViewSource));
            e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator());
            e.Menu.Items.Add(new EO.WebBrowser.MenuItem("Print", CommandIds.Print));

            if (e.MenuInfo.Suggestions.Length > 0)
            {
                e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator());
                e.Menu.Items.AddSpellCheckSuggstions(e.MenuInfo.Suggestions);
                e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator());
                e.Menu.Items.Add(new EO.WebBrowser.MenuItem("Add To Dictionary", CommandIds.SpellCheckAddToDictionary));
            }
        }

        //This event handler is called when a context menu item or a hot key triggers a
        //"command". Here we only handle our own custom commands
        void WebView_Command(object sender, CommandEventArgs e)
        {
            EO.WebBrowser.WebView webView = (EO.WebBrowser.WebView)sender;
            if (e.CommandId == m_nHomeCommand)
            {
                webView.Url = "http://www.essentialobjects.com";
                e.Handled = true;
            }
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
                    Nullable<bool> result = dlg.ShowDialog();

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
                    MessageBox.Show(this, e.MessageText, "JavaScript Message", MessageBoxButton.OK);
                    e.OK();
                    break;

                case JSDialogType.BeforeUnload:
                case JSDialogType.Confirm:
                    //Display a Yes/No message box and call e.OK/e.Cancel according
                    //to user's selection
                    if (MessageBox.Show(this, e.MessageText, "JavaScript Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        e.OK();
                    else
                    {
                        e.Cancel();
                        if (e.DialogType == JSDialogType.BeforeUnload)
                            m_bCloseRequested = false;
                    }
                    break;
            }
        }

        //This event handler is called when a download starts
        void WebView_BeforeDownload(object sender, BeforeDownloadEventArgs e)
        {
            //Add it to our download list
            m_Downloads.Add(e.Item);

            //Set ShowDialog to true to display "Save As" dialog
            e.ShowDialog = true;

            //Display the "Downloads" pane
            mnuDownloads_Click(this, null);
        }

        //This event handler is called when a download has been canceled
        void WebView_DownloadCanceled(object sender, DownloadEventArgs e)
        {
            m_Downloads.Remove(e.Item);
        }

        private void WebView_DownloadCompleted(object sender, DownloadEventArgs e)
        {
            EO.WebBrowser.WebView webView = (EO.WebBrowser.WebView)sender;
            if (webView.IsNewWindow && string.IsNullOrEmpty(webView.Url))
                webView.Close(false);
        }

        //This event is called when JavaScript code calls an "extension"
        //function, which calls into here and allow us to carry out the
        //function in .NET code and even return a value back to the
        //JavaScript code
        void WebView_JSExtInvoke(object sender, JSExtInvokeArgs e)
        {
            switch (e.FunctionName)
            {
                case "demoAbout":
                    //The value of "window.navigator.appVersion" is passed to us from 
                    //JavaScript as the first argument when the JavaScript code calls
                    //eoapi.extInvoke
                    string browserEngine = e.Arguments[0] as string;
                    DemoAbout(browserEngine);
                    break;
            }
        }

        void WebView_RequestPermissions(object sender, RequestPermissionEventArgs e)
        {
            e.Allow();
        }
        #endregion

        #region Other Functions/Handlers
        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (m_CurPage != null)
                m_CurPage.WebView.Print();
        }
        #endregion
    }
}
