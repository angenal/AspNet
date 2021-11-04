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
using System.Windows.Threading;

namespace EO.Wpf.Demo.Demos.Gauge
{
    /// <summary>
    /// Interaction logic for ClockGauge.xaml
    /// </summary>
    public partial class ClockGauge : UserControl
    {
        private DispatcherTimer m_dispatcherTimer;

        /// <exclude />
        public ClockGauge()
        {
            InitializeComponent();

            Loaded += ClockGauge_Loaded;
        }

        private void ClockGauge_Loaded(object sender, EventArgs e)
        {
            UpdateClock();

            //initialize the timer
            m_dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            m_dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            m_dispatcherTimer.IsEnabled = true;

            // register for the tick handle
            m_dispatcherTimer.Tick += Timer_Tick;

            // start the timer
            m_dispatcherTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime currentTime = DateTime.Now;

            double seconds = (currentTime.Second * 12) / 60.0;
            double minutes = (currentTime.Minute * 12) / 60.0;
            double hours = currentTime.Hour > 12 ? currentTime.Hour - 12 : currentTime.Hour;

            // calculate the percentage of passed minutes
            double sh = currentTime.Minute/60.0;
            hours += sh;

            SecondsHandle.Value = seconds;
            MinutesHandle.Value = minutes;
            HoursHandle.Value = hours;
        }
    }
}
