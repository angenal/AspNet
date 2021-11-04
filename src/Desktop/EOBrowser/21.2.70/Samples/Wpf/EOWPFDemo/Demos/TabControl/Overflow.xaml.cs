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
    /// Interaction logic for Overflow.xaml
    /// </summary>
    public partial class Overflow : UserControl
    {
        public Overflow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;

            EO.Wpf.ComboBox comboBox = (EO.Wpf.ComboBox)sender;
            EO.Wpf.ComboBoxItem item = (EO.Wpf.ComboBoxItem)comboBox.SelectedItem;
            switch (item.Text)
            {
                case "Wrap":
                    TabControl1.TabItemOverflowStrategy = TabItemOverflowStrategy.Wrap;
                    break;
                case "Clip":
                    TabControl1.TabItemOverflowStrategy = TabItemOverflowStrategy.Clip;
                    break;
                case "Scroll":
                    TabControl1.TabItemOverflowStrategy = TabItemOverflowStrategy.Scroll;
                    break;
                case "Shrink":
                    TabControl1.TabItemOverflowStrategy = TabItemOverflowStrategy.Shrink;
                    break;
            }
        }
    }
}
