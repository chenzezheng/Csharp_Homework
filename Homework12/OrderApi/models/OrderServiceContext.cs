using Microsoft.EntityFrameworkCore;

namespace OrderApi.Models
{
    public class OrderServiceContext : DbContext
    {
        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
    }
}
