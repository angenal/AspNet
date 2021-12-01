namespace BigScreenBrowser.Commands
{
    public class NotifyIconExitCommand : CommandBase<NotifyIconExitCommand>
    {
        public override void Execute(object parameter)
        {
            //App.MainWnd.notifyIcon.ContextMenu.Items.Clear();
            //App.MainWnd.webPanel.Children.RemoveAt(0);
            App.MainWnd.Window_ComfirmExit();
        }
    }
}
