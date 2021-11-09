using EO.Wpf;
using System.Windows;
using System.Windows.Input;

namespace FullScreenBrowser
{
    public partial class MainWindow
    {
        //Navigation UI Related Functions/Handlers

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            m_WebView.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            m_WebView.GoForward();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(m_WebView.Url))
            {
                m_WebView.Reload(true);
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
            MenuItem menuItem;
            menuItem = UIElementHelper.GetVisualChild(panels, "mnuDownloads") as MenuItem;
            menuItem.IsChecked = dockContainer.GetItemById("Downloads") != null;
            menuItem = UIElementHelper.GetVisualChild(panels, "mnuConsole") as MenuItem;
            menuItem.IsChecked = dockContainer.GetItemById("Console") != null;
        }

        private void mnuDownloads_Click(object sender, RoutedEventArgs e)
        {
            dockContainer.ActivateItem("Downloads");
        }

        private void mnuConsole_Click(object sender, RoutedEventArgs e)
        {
            if (m_CurPage == null || string.IsNullOrEmpty(m_CurPage.WebView.Url)) return;
            dockContainer.ActivateItem("Console");
            m_ConsolePane.Attach(m_CurPage.WebView, m_CurPage.Messages);
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
            string url = WebPageResourceHandler.DefaultPage;
            dockContainer.ActivateItem(WebViewItemIdPrefix + url);
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Window_ComfirmExit();
        }
    }
}
