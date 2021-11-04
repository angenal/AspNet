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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EO.Wpf.Demo.Demos.Misc
{
    /// <summary>
    /// Interaction logic for WindowChrome.xaml
    /// </summary>
    public partial class WindowChrome : UserControl
    {
        public WindowChrome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowChromeWnd wnd = new WindowChromeWnd();
            wnd.Show();
        }
    }
}
