using Microsoft.EntityFrameworkCore;

namespace OdataOrders.Data
{
    public class OdataOrdersContext : DbContext
    {
        public OdataOrdersContext(DbContextOptions<OdataOrdersContext> context) : base(context)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
