using System.Collections.Generic;
using BirdEye.Bll.Interface;
using BirdEye.Common.Entity;

namespace BirdEye.Bll
{
	public class CustomerService : ICustomerService
	{
		public string GetCustomerName(string customerCode)
		{
			if (string.IsNullOrEmpty(customerCode))
			{
				return "DefaultCustomer";
			}

			return customerCode + "-Loren";
		}

		public List<Customer> GetAllCustomers()
		{
			List<Customer> list = new List<Customer>();
			for (int i = 0; i < 10; i++)
			{
				Customer customer = new Customer
					{
						CustomerID = i.ToString(),
						FirstName = "Loren" + i.ToString(),
						LastName = "Luo" + i.ToString(),
						Detail = "Detail" + i.ToString()
					};

				list.Add(customer);
			}

			return list;
		}
	}
}
