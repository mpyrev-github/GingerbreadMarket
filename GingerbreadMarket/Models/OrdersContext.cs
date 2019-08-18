using Microsoft.EntityFrameworkCore;

namespace GingerbreadMarket.Models
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Deal> Deals { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=OrdersDb;Username=webuser;Password=webuser");
    }
}
