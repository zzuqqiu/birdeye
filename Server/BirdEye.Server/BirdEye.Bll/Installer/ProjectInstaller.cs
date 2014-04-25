using System.ComponentModel;
using System.ServiceProcess;

namespace BirdEye.Bll.Installer
{
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private readonly ServiceProcessInstaller _process;
		private readonly ServiceInstaller _service;

		public ProjectInstaller()
		{
			_process = new ServiceProcessInstaller
			{
				//账户类型
				Account = ServiceAccount.LocalSystem
			};
			_service = new ServiceInstaller
			{
				//服务名称
				ServiceName = "BirdEye.WCFService",
				//服务描述
				Description = "WCF service host in WindowService"
			};
			base.Installers.Add(_process);
			base.Installers.Add(_service);
		}
	}
}
