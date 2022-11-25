using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CustomerID).IsRequired();
            builder.Property(p => p.OrderNumber);
            builder.Property(p => p.PaymentID).IsRequired();
            builder.Property(p => p.OrderDate);
            builder.Property(p => p.ShipDate);
            builder.Property(p => p.RequiredDate);
            builder.Property(p => p.ShipperID).IsRequired();
            builder.Property(p => p.Freight);
            builder.Property(p => p.SalesTax);
            builder.Property(p => p.TimeStamp);
            builder.Property(p => p.TransactStatus);
            builder.Property(p => p.ErrLoc);
            builder.Property(p => p.ErrMsg);
            builder.Property(p => p.Fulfilled);
            builder.Property(p => p.Deleted);
            builder.Property(p => p.Paid);
            builder.Property(p => p.PaymentDate);
            builder.HasOne(o => o.Shipper).WithMany(m => m.Orders)
                .HasForeignKey(k => k.ShipperID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.OrderDetails).WithOne(o => o.Order)
                .HasForeignKey<OrderDetailsEntity>(k => k.OrderID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Customer).WithMany(m => m.Orders)
                .HasForeignKey(k => k.CustomerID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Payment).WithMany(m => m.Orders)
                .HasForeignKey(k => k.PaymentID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
