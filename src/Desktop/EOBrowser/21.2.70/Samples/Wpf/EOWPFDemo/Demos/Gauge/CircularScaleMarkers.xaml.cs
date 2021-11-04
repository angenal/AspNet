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
    /// Interaction logic for circularScaleMarkers.xaml
    /// </summary>
    public partial class CircularScaleMarkers : UserControl
    {
        private DispatcherTimer m_timer;
        private Random m_random;

        public CircularScaleMarkers()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            m_timer = new DispatcherTimer();
            m_random = new Random();
            m_timer.Interval = TimeSpan.FromSeconds(1);
            m_timer.IsEnabled = true;
            m_timer.Tick += OnTimerTick;
            m_timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            this.Marker.Value = m_random.Next(1, 100);
            this.Marker1.Value = m_random.Next(1, 100);
        }
    }
}
