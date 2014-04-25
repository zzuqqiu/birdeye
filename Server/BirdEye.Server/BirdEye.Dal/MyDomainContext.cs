using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdEye.Dal
{
	public class MyDomainContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		static MyDomainContext()
		{
			Database.SetInitializer<MyDomainContext>(new DropCreateDatabaseIfModelChanges<MyDomainContext>());
		}
	}
}
