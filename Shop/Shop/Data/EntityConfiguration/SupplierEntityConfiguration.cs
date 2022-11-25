using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CompanyName);
            builder.Property(p => p.ContactFName);
            builder.Property(p => p.ContactLName);
            builder.Property(p => p.ContactTitle);
            builder.Property(p => p.Address1);
            builder.Property(p => p.Address2);
            builder.Property(p => p.City);
            builder.Property(p => p.State);
            builder.Property(p => p.PostalCode);
            builder.Property(p => p.Country);
            builder.Property(p => p.Phone);
            builder.Property(p => p.Fax);
            builder.Property(p => p.Email);
            builder.Property(p => p.URL);
            builder.Property(p => p.PaymentMethods);
            builder.Property(p => p.DiscountType);
            builder.Property(p => p.Notes);
            builder.Property(p => p.DiscountAvailable);
            builder.Property(p => p.CurrentOrder);
            builder.Property(p => p.Logo);
            builder.Property(p => p.CustomerID);
            builder.Property(p => p.SizeURL);
        }
    }
}
