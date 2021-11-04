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

namespace EO.Wpf.Demo.Demos.TabControl
{
    /// <summary>
    /// Interaction logic for CloseTabButton.xaml
    /// </summary>
    public partial class CloseTabButton : UserControl
    {
        public CloseTabButton()
        {
            InitializeComponent();
        }

        private void TabControl_PreviewItemClose(object sender, TabItemCloseEventArgs e)
        {
            if (MessageBox.Show(
                string.Format("Are you sure you want to close tab '{0}'?", e.Item.Header),
                "Close Tab", MessageBoxButton.YesNo) == MessageBoxResult.No)
                e.Canceled = true;
        }
    }
}
