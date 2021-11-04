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
    /// Interaction logic for circularScaleNeedles.xaml
    /// </summary>
    public partial class CircularScaleNeedles : UserControl
    {
        private DispatcherTimer m_dispatcherTimer;
        private Random m_random;

        public CircularScaleNeedles()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            m_random = new Random();
            m_dispatcherTimer = new DispatcherTimer();
            m_dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            m_dispatcherTimer.IsEnabled = true;
            m_dispatcherTimer.Tick += DispatcherTimerOnTick;
            m_dispatcherTimer.Start();
        }

        private void DispatcherTimerOnTick(object sender, EventArgs eventArgs)
        {
            this.Needle.Value = m_random.Next(0, 100);
            this.ProgressIndicator.Value = m_random.Next(0, 100);
        }
    }
}
