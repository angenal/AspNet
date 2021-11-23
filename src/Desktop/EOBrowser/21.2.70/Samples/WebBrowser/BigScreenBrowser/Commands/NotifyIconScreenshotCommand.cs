using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace BigScreenBrowser.Commands
{
    public class NotifyIconScreenshotCommand : CommandBase<NotifyIconScreenshotCommand>
    {
        public override void Execute(object parameter)
        {
            App.MainWnd.notifyIcon.ContextMenu.IsOpen = false;
            if (App.MainWnd.isScreenCut) return;
            App.MainWnd.isScreenCut = true;
            App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(App.MainWnd.ScreenCut));
            CommandManager.InvalidateRequerySuggested();
        }

        public override bool CanExecute(object parameter)
        {
            return App.MainWnd != null && !App.MainWnd.isScreenCut;
        }
    }
}
