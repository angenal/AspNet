using CefSharp;
using CefSharp.Wpf;
using System;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.Browser
{
    public partial class MainWindow
    {
        int tabCount = 0;
        TabItem currentTabItem = null;
        ChromiumWebBrowser currentBrowserShowing = null;

        private void InitializeWebBrowser()
        {
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            defaultBrowser.Dispose();
            currentBrowserShowing?.Dispose();
            Close();
            Environment.Exit(0);
        }

        private void defaultBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            //var browser = sender as ChromiumWebBrowser;
            //TabItem tabItem = browser.Parent as TabItem;
            //browser.GetMainFrame().EvaluateScriptAsync("").ContinueWith(async (response) =>
            //{
            //    var result = await response;
            //});
        }
        private void defaultBrowser_TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var browser = sender as ChromiumWebBrowser;
            TabItem tabItem = browser.Parent as TabItem;
            tabItem.Header = e.NewValue.ToString();
        }

        private void newTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = new TabItem();
            ChromiumWebBrowser browser = new ChromiumWebBrowser();
            browser.Name = "browser_" + tabCount;

            tabControl.Items.Add(tabItem);
            tabItem.Name = "tab_" + tabCount;
            tabCount++;

            tabItem.Content = browser;

            browser.Address = "https://www.baidu.com";

            tabItem.Header = "New Tab";
            tabItem.MaxWidth = 100;

            tabControl.SelectedItem = tabItem;

            currentTabItem = tabItem;
            currentBrowserShowing = browser;
            browser.Loaded += FinishedLoadingWebPage;
            browser.TitleChanged += Browser_TitleChanged;
        }

        private void Browser_TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            currentTabItem.Header = e.NewValue.ToString();
        }

        private void FinishedLoadingWebPage(object sender, RoutedEventArgs e)
        {
            //var browser = sender as ChromiumWebBrowser;
        }

        private void bkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentBrowserShowing.CanGoBack)
            {
                currentBrowserShowing.Back();
            }
        }

        private void fwdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentBrowserShowing.CanGoForward)
            {
                currentBrowserShowing.Forward();
            }
        }

        private void rfshBtn_Click(object sender, RoutedEventArgs e)
        {
            currentBrowserShowing.Reload();
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            if (currentBrowserShowing != null && AddressBar.Text != string.Empty)
            {
                currentBrowserShowing.Address = Uri.TryCreate(AddressBar.Text, UriKind.Absolute, out Uri uri) ? uri.ToString()
                    : "https://www.baidu.com/s?ie=UTF-8&wd=" + HttpUtility.UrlEncode(AddressBar.Text);
            }
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedItem != null)
            {
                currentTabItem = tabControl.SelectedItem as TabItem;
            }

            if (currentTabItem != null)
            {
                currentBrowserShowing = currentTabItem.Content as ChromiumWebBrowser;
            }
        }

        private void closeTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (tabCount > 0 && currentTabItem != null)
            {
                tabControl.Items.Remove(currentTabItem);
            }
        }

    }
}
