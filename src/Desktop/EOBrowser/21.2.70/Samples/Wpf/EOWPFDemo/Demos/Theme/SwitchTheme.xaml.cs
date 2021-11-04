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
using EO.Wpf;

namespace EO.Wpf.Demo.Demos.Theme
{
    /// <summary>
    /// Interaction logic for SwitchTheme.xaml
    /// </summary>
    public partial class SwitchTheme : UserControl
    {
        public SwitchTheme()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ThemeManager.AppTheme = cbThemes.SelectedItem.ToString();
        }
    }
}
