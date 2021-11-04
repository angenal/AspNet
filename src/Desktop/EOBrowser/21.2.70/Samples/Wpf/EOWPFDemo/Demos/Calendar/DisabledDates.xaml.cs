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

namespace EO.Wpf.Demo.Demos.Calendar
{
    /// <summary>
    /// Interaction logic for DisabledDates.xaml
    /// </summary>
    public partial class DisabledDates : UserControl
    {
        public DisabledDates()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            DateTime firstDayOfTheMonth = new DateTime(now.Year, now.Month, 1);
            DateTime firstDayNextMonth = firstDayOfTheMonth.AddMonths(1);
            Calendar1.DisabledDates.Add(
                new EO.Wpf.DateRange(firstDayOfTheMonth, firstDayOfTheMonth.AddDays(2)));
            Calendar1.DisabledDates.Add(
                new EO.Wpf.DateRange(firstDayNextMonth.AddDays(-3), firstDayNextMonth.AddDays(-1)));
        }
    }
}
