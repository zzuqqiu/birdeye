using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace BirdEye.Bll
{
	class Program
	{
		public static void Main(string[] args)
		{
			ConfigurationManager.AppSettings["aspnet:UseTaskFriendlySynchronizationContext"] = "true";

			var mapping = new ProtocolMappingElementCollection();
			mapping.Add(
			  element: new ProtocolMappingElement(
				schemeType: "http",
				binding: "netHttpBinding",
				bindingConfiguration: "default"));
			mapping.Add(
			  element: new ProtocolMappingElement(
				schemeType: "https",
				binding: "netHttpsBinding",
				bindingConfiguration: "default"));

			ServiceHost serviceHost = null;

			try
			{
				string addressStr = "http://localhost:8012/HelloService";

				var binding = new NetHttpBinding(
				  securityMode: BasicHttpSecurityMode.None,
				  reliableSessionEnabled: true);

				var addressUri = new Uri(uriString: addressStr);

				serviceHost = new ServiceHost(
				  serviceType: typeof(HelloService),
				  baseAddresses: addressUri);

				//var endpoint = serviceHost.AddServiceEndpoint(
				//  implementedContract: typeof(IHelloService),
				//  binding: binding,
				//  address: addressUri);

				serviceHost.Open();

				Console.WriteLine(
				  "WebSocketsServiceValues service is running, press any key to close...");
				Console.ReadKey();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				if (serviceHost != null) serviceHost.Close();
			}
		}
	}
}
