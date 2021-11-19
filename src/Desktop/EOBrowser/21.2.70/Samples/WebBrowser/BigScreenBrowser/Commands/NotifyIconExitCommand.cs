namespace BigScreenBrowser.Commands
{
    public class NotifyIconExitCommand : CommandBase<NotifyIconExitCommand>
    {
        public override void Execute(object parameter)
        {
            App.MainWnd.notifyIcon.Visibility = System.Windows.Visibility.Hidden;
            App.MainWnd.Window_Exit();
        }
    }
}
