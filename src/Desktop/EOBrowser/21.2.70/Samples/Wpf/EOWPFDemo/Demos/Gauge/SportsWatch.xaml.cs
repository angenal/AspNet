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
using EO.Wpf.Gauge;

namespace EO.Wpf.Demo.Demos.Gauge
{
    /// <summary>
    /// Interaction logic for SportsWatch.xaml
    /// </summary>
    public partial class SportsWatch : UserControl
    {
        private TimeSpan m_recordedTime;
        private DispatcherTimer m_dispatcherTimer;
        private bool m_isPaused;

        private DispatcherTimer m_chronographTimer;

        public SportsWatch()
        {
            InitializeComponent();

            // initialize the normal clock
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            this.UpdateClock();

            //initialize the timer
            m_dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            m_dispatcherTimer.IsEnabled = true;
            m_dispatcherTimer.Interval = TimeSpan.FromSeconds(1);

            // register for the tick handle
            m_dispatcherTimer.Tick += OnTimerTick;

            // start the timer
            m_dispatcherTimer.Start();
        }

        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            this.UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime currentTime = DateTime.Now;

            double seconds = currentTime.Second;
            double minutes = (currentTime.Minute*12)/60.0;
            double hours = currentTime.Hour > 12 ? currentTime.Hour - 12 : currentTime.Hour;

            // calculate the percentage of passed minutes
            double csh = currentTime.Minute/60.0;
            hours += csh;

            // initialize the handles
            this.SecSmallHandle.Value = seconds;
            this.MinuteHandle.Value = minutes;
            this.HourHandle.Value = hours;
        }

        private void ResetChronograph()
        {
            this.SecondHandle.ClearValue(ValueIndicator.ValueProperty);
            this.SmallHourHandle.ClearValue(ValueIndicator.ValueProperty);
            this.SmallMinuteHandle.ClearValue(ValueIndicator.ValueProperty);
            this.RecordedTime.ClearValue(TextBox.TextProperty);

            this.StartButton.IsEnabled = true;
            this.PauseButton.IsEnabled = false;
            this.ResetButton.IsEnabled = false;

            m_isPaused = false;
        }

        private void StartChronograph()
        {
            if (m_isPaused)
            {
                m_chronographTimer.IsEnabled = true;
                m_isPaused = false;

                // update the UI
                this.ResetButton.IsEnabled = false;
                this.PauseButton.IsEnabled = true;
                this.StartButton.IsEnabled = false;

                return;
            }

            m_recordedTime = new TimeSpan();
            this.RecordedTime.Text = m_recordedTime.ToString();
            m_chronographTimer = new DispatcherTimer();
            m_chronographTimer.Interval = TimeSpan.FromSeconds(1);
            m_chronographTimer.IsEnabled = true;
            m_chronographTimer.Tick += OnChronographTick;

            // update the UI elements
            this.ResetButton.IsEnabled = false;
            this.PauseButton.IsEnabled = true;
            this.StartButton.IsEnabled = false;
        }

        private void PauseChronograph()
        {
            m_isPaused = true;

            m_chronographTimer.IsEnabled = false;

            // update the UI elements
            this.StartButton.IsEnabled = true;
            this.ResetButton.IsEnabled = true;
            this.PauseButton.IsEnabled = false;
        }

        private void OnChronographTick(object sender, EventArgs eventArgs)
        {
            // increment the recorded time
            m_recordedTime = m_recordedTime.Add(TimeSpan.FromSeconds(1));

            // update the UI elements
            this.SecondHandle.Value = (m_recordedTime.Seconds*12)/60.0;
            this.SmallHourHandle.Value = m_recordedTime.Hours > 12 ? m_recordedTime.Hours - 12 : m_recordedTime.Hours;
            this.SmallMinuteHandle.Value = m_recordedTime.Minutes;
            this.RecordedTime.Text = m_recordedTime.ToString();
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.StartChronograph();
        }

        private void PauseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.PauseChronograph();
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.ResetChronograph();
        }
    }
}
