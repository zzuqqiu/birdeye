using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdEye.Dal
{
	public class Order
	{
		public int OrderID { get; set; }
		public string OrderTitle { get; set; }
		public string CustomerName { get; set; }
		public DateTime TransactionDate { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }
	}

	public class OrderDetail
	{
		public int OrderDetailID { get; set; }
		public int OrderID { get; set; }
		public decimal Cost { get; set; }
		public string ItemName { get; set; }

		public Order Order { get; set; }
	}
}
