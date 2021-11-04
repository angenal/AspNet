using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace FullScreenBrowser
{
    /// <summary>
    /// Interaction logic for ConsolePane.xaml
    /// </summary>
    public partial class ConsolePane : UserControl
    {
        private EO.WebBrowser.WebView webView;
        private ObservableCollection<string> m_Messages = new ObservableCollection<string>();

        public ConsolePane()
        {
            InitializeComponent();
        }

        internal void Attach(EO.WebBrowser.WebView webView, ObservableCollection<string> messages)
        {
            this.webView = webView;
            lstOutput.ItemsSource = messages;
            txtScript.Text = string.Empty;
        }

        private void txtScript_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                string script = txtScript.Text;
                try
                {
                    //Evaluate the JavaScript code and display the result
                    object result = webView.EvalScript(script, true);
                    if (result == null)
                        m_Messages.Add("Failed to evaluate script. Script engine is not ready. Please try again later.");
                    else
                        m_Messages.Add(result.ToString());
                }
                catch (Exception ex)
                {
                    m_Messages.Add("An exception occured, exception message:" + ex.Message);
                }

                txtScript.SelectAll();
            }
        }

        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource != txtScript) txtScript.Focus();
        }
    }
}
