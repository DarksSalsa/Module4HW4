using Microsoft.EntityFrameworkCore;
using Shop.Data.Entities;

namespace Shop.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderDetailsEntity> OrderDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PaymentEntity> Payment { get; set; }
        public DbSet<ProductEntitiy> Products { get; set; }
        public DbSet<ShipperEntity> Shippers { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierEntityConfiguration());
        }
    }
}
