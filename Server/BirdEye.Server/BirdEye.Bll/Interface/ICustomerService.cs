using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BirdEye.Common.Entity;

namespace BirdEye.Bll.Interface
{
	[ServiceContract]
	public interface ICustomerService
	{
		[OperationContract]
		string GetCustomerName(string customerCode);

		[OperationContract]
		List<Customer> GetAllCustomers();

	}
}
