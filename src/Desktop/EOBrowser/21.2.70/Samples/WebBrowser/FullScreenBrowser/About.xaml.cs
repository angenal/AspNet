using System.Linq;
using System.Reflection;
using System.Windows;

namespace FullScreenBrowser
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The method is called outside the export
        /// </summary>
        public static bool? Show(Window owner, string info = null, string moreInfo = null)
        {
            About about = new About();
            about.Owner = owner;
            about.lblInfo.Text = info;
            about.lblMoreInfo.Text = moreInfo;
            return about.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var assembly = typeof(About).Assembly;
            lblVersion.Text = "V" + assembly.GetName().Version.ToString();
            var attrs = assembly.GetCustomAttributes(false);
            if (string.IsNullOrEmpty(lblInfo.Text))
            {
                var a1 = attrs.FirstOrDefault(t => t is AssemblyProductAttribute);
                if (a1 != null) lblInfo.Text = ((AssemblyProductAttribute)a1).Product;
            }
            if (string.IsNullOrEmpty(lblMoreInfo.Text))
            {
                var a2 = attrs.FirstOrDefault(t => t is AssemblyDescriptionAttribute);
                if (a2 != null) lblMoreInfo.Text = ((AssemblyDescriptionAttribute)a2).Description;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
