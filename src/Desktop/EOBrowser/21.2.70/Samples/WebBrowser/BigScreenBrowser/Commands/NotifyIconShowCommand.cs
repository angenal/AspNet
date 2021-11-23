using System.Windows.Input;

namespace BigScreenBrowser.Commands
{
    public class NotifyIconShowCommand : CommandBase<NotifyIconShowCommand>
    {
        public override void Execute(object parameter)
        {
            App.MainWnd.notifyIcon.ContextMenu.IsOpen = false;
            if (App.MainWnd.IsVisible) return;
            App.MainWnd.ShowApp();
            CommandManager.InvalidateRequerySuggested();
        }

        public override bool CanExecute(object parameter)
        {
            return App.MainWnd != null && !App.MainWnd.IsVisible;
        }
    }
}
