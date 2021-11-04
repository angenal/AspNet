using System.ComponentModel;
using System.Configuration.Install;

namespace WindowsService.SignalR.Server
{
    [RunInstaller(true)]
    public partial class WinServiceInstaller : Installer
    {
        public WinServiceInstaller()
        {
            InitializeComponent();

            // 自定义Windows服务
            var serviceName = System.Configuration.ConfigurationManager.AppSettings["ServiceName"];
            serviceInstaller.Description = serviceName;
            serviceInstaller.DisplayName = serviceName;
            serviceInstaller.ServiceName = serviceName;
            serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
        }
    }
}
