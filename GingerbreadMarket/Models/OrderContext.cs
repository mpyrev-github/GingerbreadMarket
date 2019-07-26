using System.Data.Entity;

namespace GingerbreadMarket.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base(nameOrConnectionString: "Default") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}