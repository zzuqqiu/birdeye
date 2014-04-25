using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirdEye.Web.CustomerService;
using Customer = BirdEye.Common.Entity.Customer;

namespace BirdEye.Web.Manager
{
	public class CustomerManager
	{
		public List<Customer> GetCustomers()
		{
			CustomerServiceClient client = new CustomerServiceClient();
			var list = client.GetAllCustomers();
			List<Customer> result
				= list.Select(item => new Customer
					{
						CustomerID = item.CustomerID,
						Detail = item.Detail,
						FirstName = item.FirstName,
						LastName = item.LastName
					}).ToList();

			return result;
		}
	}
}