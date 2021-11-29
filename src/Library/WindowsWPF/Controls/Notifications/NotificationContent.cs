using System.Windows;

namespace WindowsWPF.Controls
{
    public class NotificationContent
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public NotificationType Type { get; set; }

        public Visibility TitleVisibility => string.IsNullOrWhiteSpace(Title) ? Visibility.Collapsed : Visibility.Visible;
        public double MinHeight => string.IsNullOrWhiteSpace(Title) ? 40 : 80;
    }

    public enum NotificationType   
    {
        Information,
        Success,
        Warning,
        Error
    }
}
