using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EO.Wpf.Demo
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();

            txtVersion.Text = "EO.Wpf Demo v" + typeof(EO.Wpf.Runtime).Assembly.GetName().Version;
        }

        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
