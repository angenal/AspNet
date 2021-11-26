using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WindowsWPF.Controls
{
    public class NotificationArea : Control
    {
        public NotificationPosition Position
        {
            get => (NotificationPosition)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(NotificationPosition), typeof(NotificationArea), new PropertyMetadata(NotificationPosition.BottomRight));


        public int MaxItems
        {
            get => (int)GetValue(MaxItemsProperty);
            set => SetValue(MaxItemsProperty, value);
        }

        public static readonly DependencyProperty MaxItemsProperty =
            DependencyProperty.Register("MaxItems", typeof(int), typeof(NotificationArea), new PropertyMetadata(int.MaxValue));

        private IList _items;

        public NotificationArea()
        {
            NotificationManager.AddArea(this);
        }

        static NotificationArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationArea), new FrameworkPropertyMetadata(typeof(NotificationArea)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var itemsControl = GetTemplateChild("PART_Items") as Panel;
            _items = itemsControl?.Children;
        }

        public void Show(object content, TimeSpan expirationTime, Action onClick, Action onClose)
        {
            var notification = new Notification
            {
                Content = content
            };

            notification.MouseLeftButtonDown += (sender, args) =>
            {
                if (onClick != null)
                {
                    onClick.Invoke();
                    (sender as Notification)?.Close();
                }
            };

            notification.NotificationClosed += (sender, args) => onClose?.Invoke();
            notification.NotificationClosed += OnNotificationClosed;

            if (!IsLoaded)
            {
                return;
            }

            var w = Window.GetWindow(this);
            var x = PresentationSource.FromVisual(w);
            if (x == null)
            {
                return;
            }

            lock (_items)
            {
                _items.Add(notification);

                if (_items.OfType<Notification>().Count(i => !i.IsClosing) > MaxItems)
                {
                    _items.OfType<Notification>().First(i => !i.IsClosing).Close();
                }
            }

            if (expirationTime == TimeSpan.MaxValue)
            {
                return;
            }

            //await Task.Delay(expirationTime);
            DateTime current = DateTime.Now;
            while (current.Add(expirationTime) > DateTime.Now)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            notification.Close();
        }

        private void OnNotificationClosed(object sender, RoutedEventArgs routedEventArgs)
        {
            var notification = sender as Notification;
            _items.Remove(notification);
        }

        static void DelayExecute(TimeSpan delay, Action actionToExecute)
        {
            if (actionToExecute != null)
            {
                var timer = new DispatcherTimer
                {
                    Interval = delay
                };
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    actionToExecute();
                };
                timer.Start();
            }
        }
    }

    public enum NotificationPosition
    {
        TopLeft,
        TopRight,
        TopCenter,
        BottomLeft,
        BottomRight
    }
}
