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

namespace EO.Wpf.Demo.Demos.Gauge
{
    /// <summary>
    /// Interaction logic for CarDashboard.xaml
    /// </summary>
    public partial class CarDashboard : UserControl
    {
        public CarDashboard()
        {
            InitializeComponent();
        }
    }

    public class MajorTickTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MajorTemplate { get; set; }
        public DataTemplate MiddleTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            double value = (double) item;

            // for major Ticks/Labels, if the value can be divided by 20 then it is major
            // else it is middle
            if (value == 0.0 || value % 20 == 0.0)
            {
                return MajorTemplate;
            }
            else
            {
                return MiddleTemplate;
            }
        }
    }
}
