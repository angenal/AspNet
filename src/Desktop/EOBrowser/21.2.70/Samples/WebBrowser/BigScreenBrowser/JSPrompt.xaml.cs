using EO.WebBrowser;
using System.Windows;

namespace BigScreenBrowser
{
    /// <summary>
    /// Interaction logic for JSPrompt.xaml
    /// </summary>
    public partial class JSPrompt : Window
    {
        public JSPrompt(JSDialogEventArgs e)
        {
            InitializeComponent();
        }

        public string Message
        {
            get => lblMsg.Text;
            set => lblMsg.Text = value;
        }

        public string Value
        {
            get => txtPrompt.Text;
            set => txtPrompt.Text = value;
        }

        private void OnOK(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancleClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
