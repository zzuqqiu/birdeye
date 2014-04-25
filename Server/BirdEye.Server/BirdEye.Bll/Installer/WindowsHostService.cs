using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BirdEye.Bll.Interface;

namespace BirdEye.Bll.Installer
{
	public class WindowsHostService : ServiceBase
	{
		public ServiceHost HostUser = null;
		public ServiceHost HostCustomer = null;
		public ServiceHost HostHello = null;
		private const string UserServiceAddressString = "http://localhost:8011/UserService";
		private const string CustomerServiceAddressString = "http://localhost:8011/CustomerService";
		private readonly Uri _userServiceAddress = new Uri(UserServiceAddressString);
		private readonly Uri _customerServiceAddress = new Uri(CustomerServiceAddressString);

		public static void Main()
		{
			ServiceBase.Run(new WindowsHostService());
		}

		protected override void OnStart(string[] args)
		{
			System.Diagnostics.Debugger.Launch();

			if (HostUser != null)
				HostUser.Close();
			if (HostCustomer != null)
				HostCustomer.Close();

			try
			{
				HostUser = new ServiceHost(typeof(UserService), _userServiceAddress);
				HostCustomer = new ServiceHost(typeof(CustomerService), _customerServiceAddress);

				//HostUser.AddServiceEndpoint(typeof (IUserService), new BasicHttpBinding(), "http://localhost:8011/UserService");

				ServiceMetadataBehavior smb = new ServiceMetadataBehavior { HttpGetEnabled = true, MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 } };
				HostUser.Description.Behaviors.Add(smb);
				HostCustomer.Description.Behaviors.Add(smb);

				HostUser.Open();
				HostCustomer.Open();

				StartHello();
			}
			catch (Exception ex)
			{
				System.Diagnostics.EventLog.WriteEntry("Application", ex.Message);
			}
		}

		protected override void OnStop()
		{
			if (HostUser != null)
			{
				HostUser.Close();
				HostUser = null;
			}
			if (HostCustomer != null)
			{
				HostCustomer.Close();
				HostCustomer = null;
			}

			if (HostHello != null)
			{
				HostHello.Close();
				HostHello = null;
			}
		}

		private void StartHello()
		{
			ConfigurationManager.AppSettings["aspnet:UseTaskFriendlySynchronizationContext"] = "true";

			const string addressStr = "http://localhost:8012/HelloService";

			var addressUri = new Uri(addressStr);

			HostHello = new ServiceHost(typeof(HelloService), addressUri);

			HostHello.Open();

		}
	}
}
