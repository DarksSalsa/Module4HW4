using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntitiy>
    {
        public void Configure(EntityTypeBuilder<ProductEntitiy> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.SKU);
            builder.Property(p => p.IDSKU);
            builder.Property(p => p.VendorProductID);
            builder.Property(p => p.ProductName);
            builder.Property(p => p.ProductDescription);
            builder.Property(p => p.QuantityPerUnit);
            builder.Property(p => p.UnitPrice);
            builder.Property(p => p.MSRP);
            builder.Property(p => p.AvailableSize);
            builder.Property(p => p.AvailableColors);
            builder.Property(p => p.Size);
            builder.Property(p => p.Color);
            builder.Property(p => p.Discount);
            builder.Property(p => p.UnitWeight);
            builder.Property(p => p.UnitsInStock);
            builder.Property(p => p.UnitsOnOrder);
            builder.Property(p => p.ReorderLevel);
            builder.Property(p => p.ProductAvailable);
            builder.Property(p => p.DiscountAvailable);
            builder.Property(p => p.Picture);
            builder.Property(p => p.Ranking);
            builder.Property(p => p.Note);
            builder.Property(p => p.CategoryID).IsRequired();
            builder.Property(p => p.SupplierID).IsRequired();
            builder.Property(p => p.CurrentOrder).IsRequired();
            builder.HasOne(o => o.Category).WithMany(m => m.Products)
                .HasForeignKey(k => k.CategoryID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Supplier).WithMany(m => m.TypeGoods)
                .HasForeignKey(k => k.SupplierID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.OrderDetails).WithOne(m => m.Product)
                .HasForeignKey<OrderDetailsEntity>(k => k.ProductID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
