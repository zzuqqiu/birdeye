using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BirdEye.Common.Entity;

namespace BirdEye.Bll.Interface
{
	[ServiceContract(CallbackContract = typeof(IHelloCallback))]
	public interface IHelloService
	{
		[OperationContract(IsOneWay = true)]
		Task Hello(string msg);
	}

	[ServiceContract]
	public interface IHelloCallback
	{
		[OperationContract(IsOneWay = true)]
		Task OnHello(string msg);
	}
}
