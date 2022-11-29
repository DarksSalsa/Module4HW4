using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class OrderDetailsEntityConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.ProductID).IsRequired();
            builder.Property(p => p.OrderID).IsRequired();
            builder.Property(p => p.OrderNumber);
            builder.Property(p => p.Price);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Discount);
            builder.Property(p => p.Total);
            builder.Property(p => p.IDSKU);
            builder.Property(p => p.Size);
            builder.Property(p => p.Color);
            builder.Property(p => p.Fulfilled);
            builder.Property(p => p.ShipDate);
            builder.Property(p => p.BillDate);
            builder.HasOne(o => o.Order).WithMany(m => m.OrderDetails)
                .HasForeignKey(k => k.OrderID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Product).WithMany(m => m.OrderDetails)
                .HasForeignKey(k => k.ProductID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
