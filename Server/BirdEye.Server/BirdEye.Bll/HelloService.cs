using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BirdEye.Bll.Interface;
using BirdEye.Common.Entity;

namespace BirdEye.Bll
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class HelloService : IHelloService
	{
		public async Task Hello(string msg)
		{
			var callback = OperationContext.Current.GetCallbackChannel<IHelloCallback>();
			await callback.OnHello(msg);
		}
	}
}
