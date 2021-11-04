using EO.WebBrowser;
using EO.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FullScreenBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string WebViewItemIdPrefix = "WebView:";
        private static int m_nHomeCommand = CommandIds.RegisterUserCommand("home");

        //private WebPage m_CurPage;
        //private ObservableCollection<WebPage> m_Pages = new ObservableCollection<WebPage>();
        //All messages output by the WebView
        private EO.WebBrowser.WebView webView;
        private DockView m_WebViewsHost;
        private DockView m_ToolViews;
        private ConsolePane m_ConsolePane;
        private ObservableCollection<string> m_Messages = new ObservableCollection<string>();
        private ObservableCollection<DownloadItem> m_Downloads = new ObservableCollection<DownloadItem>();
        private string m_szLayoutFileName;
        private bool m_bCloseRequested;
        private int panelSelectedIndex;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the DockView layout.
            dockContainer.LoadLayout(m_szLayoutFileName);
            //If we do not have any page loaded, load an empty page
            if ((m_WebViewsHost == null) || !m_WebViewsHost.HasItems)
                dockContainer.ActivateItem(WebViewItemIdPrefix + Properties.Resources.URL);
            m_WebViewsHost = dockContainer.ActiveView;
            //Default WebView
            webView = (EO.WebBrowser.WebView)dockContainer.ActiveItem.Content;
            webView.ConsoleMessage += new ConsoleMessageHandler(WebView_ConsoleMessage);
            //AttachEvents(webView);
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            string dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EO.Total");
            if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            m_szLayoutFileName = System.IO.Path.Combine(dir, "UILayout.xml");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Save the docking view UI layout
            if (!m_bCloseRequested && panelSelectedIndex <= 0)
            {
                try
                {
                    dockContainer.SaveLayout(m_szLayoutFileName);
                }
                catch (Exception ex)
                {
                    //This may fail due to permission issues
                    MessageBox.Show("Failed to save docking view layout:" + ex.ToString());
                }
            }
            e.Cancel = true;
        }

        private FindSession m_FindSession;
        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (panFind.Visibility == Visibility.Visible)
            {
                StopFind();
            }
            else
            {
                panFind.Visibility = Visibility.Visible;
                txtFind.Focus();
            }
        }

        private void txtFind_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Find(true);
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            StopFind(false);
        }

        private void btnFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            Find(false);
        }

        private void btnFindNext_Click(object sender, RoutedEventArgs e)
        {
            Find(true);
        }

        private void btnFindClose_Click(object sender, RoutedEventArgs e)
        {
            StopFind();
        }

        private void Find(bool forward)
        {
            string txtToFind = txtFind.Text.Trim();
            if (txtToFind == string.Empty)
                return;

            if (m_FindSession == null)
            {
                m_FindSession = webView.StartFindSession(txtToFind, false);
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
                panFind.Visibility = Visibility.Collapsed;
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
            string txtToFind = txtFind.Text.Trim();
            if (txtToFind == string.Empty)
            {
                btnFindPrevious.IsEnabled = false;
                btnFindNext.IsEnabled = false;
                lbFindCount.Content = string.Empty;
            }
            else if (m_FindSession == null)
            {
                btnFindPrevious.IsEnabled = false;
                btnFindNext.IsEnabled = true;
                lbFindCount.Content = string.Empty;
            }
            else
            {
                btnFindPrevious.IsEnabled = m_FindSession.MatchCount > 0;
                btnFindNext.IsEnabled = m_FindSession.MatchCount > 0;
                lbFindCount.Content = string.Format("{0}/{1}", m_FindSession.CurrentMatchIndex + 1, m_FindSession.MatchCount);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            webView.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            webView.GoForward();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(webView.Url))
            {
                webView.Reload(true);
            }
        }

        private void txtUrl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WebViewItem item = (WebViewItem)m_WebViewsHost.SelectedItem;
                item.Page.WebView.Url = txtUrl.Text.Trim();
            }
        }

        private void txtUrl_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUrl.SelectAll();
        }

        private void txtUrl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!txtUrl.IsKeyboardFocusWithin)
            {
                txtUrl.Focus();
                txtUrl.SelectAll();
                e.Handled = true;
            }
        }

        private void Menu_Opened(object sender, RoutedEventArgs e)
        {
            EO.Wpf.MenuItem menuItem;
            menuItem = UIElementHelper.GetVisualChild(panels, "mnuDownloads") as EO.Wpf.MenuItem;
            menuItem.IsChecked = dockContainer.GetItemById("Downloads") != null;
            menuItem = UIElementHelper.GetVisualChild(panels, "mnuConsole") as EO.Wpf.MenuItem;
            menuItem.IsChecked = dockContainer.GetItemById("Console") != null;
        }

        private void mnuDownloads_Click(object sender, RoutedEventArgs e)
        {
            dockContainer.ActivateItem("Downloads");
        }

        private void mnuConsole_Click(object sender, RoutedEventArgs e)
        {
            dockContainer.ActivateItem("Console");
            m_ConsolePane.Attach(webView, m_Messages);
        }

        private void WebView_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            string message = string.Format("({0}) - {1} line# {2}:{3}", e.Severity, e.Source, e.LineNumber, e.Message);
            m_Messages.Add(message);
        }

        private void mnuDebugUI_Click(object sender, RoutedEventArgs e)
        {
            EO.WebBrowser.WebView.ShowDebugUI();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            About.Show(this);
        }

        private void mnuEmbeddedPage_Click(object sender, RoutedEventArgs e)
        {
            string url = AppResourceHandler.EmbeddedPageUrl;
            dockContainer.ActivateItem(WebViewItemIdPrefix + url);
        }

        private WebViewItem NewWebViewItem(EO.WebBrowser.WebView webView)
        {
            WebViewItem item = new WebViewItem(webView);

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

        //WebView events
        void WebView_NewWindow(object sender, NewWindowEventArgs e)
        {
            //The new WebView has already been created (e.WebView). Here we
            //associates it with a new WebViewItem object and creates a
            //new tab button for it (by adding it to m_Pages)
            WebViewItem item = NewWebViewItem(e.WebView);
            m_WebViewsHost.Items.Add(item);

            //Select the newly created tab
            panelSelectedIndex = m_WebViewsHost.Items.Count - 1;

            //Signifies that we accept the new WebView. Without this line
            //the newly created WebView will be immediately destroyed
            e.Accepted = true;

            //If you do not want to open a new window but wish to open
            //the new Url in the same window, comment the code above
            //and uncomment the code below. The code below set the existing
            //WebView's Url to the new Url. Also because it did not set
            //e.Accepted to true, so the new WebView will be discarded.
            EO.WebBrowser.WebView webView = (EO.WebBrowser.WebView)sender;
            webView.Url = e.TargetUrl;
        }

        //WebView events
        void WebView_Activate(object sender, EventArgs e)
        {
        }

        //WebView events
        void WebView_LaunchUrl(object sender, LaunchUrlEventArgs e)
        {
            e.UseOSHandler = true;
        }

        //WebView events
        void WebView_Closed(object sender, WebViewClosedEventArgs e)
        {
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

        //WebView events
        private void WebView_CertificateError(object sender, CertificateErrorEventArgs e)
        {
            e.Continue();
        }

        //WebView events
        void WebView_RequestPermissions(object sender, RequestPermissionEventArgs e)
        {
            e.Allow();
        }

        private void dockContainer_DockItemNeeded(object sender, DockItemNeededEventArgs e)
        {
            switch (e.ItemId)
            {
                case "Downloads":
                    e.Item = DockItem.LoadFrom(new Uri("/FullScreenBrowser;component/DownloadsPane.xaml", UriKind.Relative), "Downloads");
                    DownloadsPane downloadsPane = (DownloadsPane)e.Item.Content;
                    downloadsPane.Bind(m_Downloads);
                    break;
                case "Console":
                    e.Item = DockItem.LoadFrom(new Uri("/FullScreenBrowser;component/ConsolePane.xaml", UriKind.Relative), "Console");
                    m_ConsolePane = (ConsolePane)e.Item.Content;
                    break;
                case "Objects":
                    break;
                default:
                    if (e.ItemId.StartsWith(WebViewItemIdPrefix))
                    {
                        WebViewItem item = NewWebViewItem(null);
                        e.Item = item;
                    }
                    break;
            }
        }

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

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

    }
}
