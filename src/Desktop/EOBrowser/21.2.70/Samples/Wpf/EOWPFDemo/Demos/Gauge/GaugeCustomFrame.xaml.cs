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
    /// Interaction logic for GaugeCustomFrame.xaml
    /// </summary>
    public partial class GaugeCustomFrame : UserControl
    {
        private DispatcherTimer m_dispatcherTimer;
        private Random m_random;

        public GaugeCustomFrame()
        {
            InitializeComponent();

            Loaded += GaugeCustomFrame_Loaded;
        }

        private void GaugeCustomFrame_Loaded(object sender, RoutedEventArgs args)
        {
            m_random = new Random();
            m_dispatcherTimer = new DispatcherTimer();
            m_dispatcherTimer.Interval = TimeSpan.FromSeconds(2);
            m_dispatcherTimer.Tick += Timer_Tick;
            m_dispatcherTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Needle.Value = m_random.Next(0, 100);
        }
    }
}
