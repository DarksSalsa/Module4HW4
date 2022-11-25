using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.FirstName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.Class);
            builder.Property(p => p.Room);
            builder.Property(p => p.Building);
            builder.Property(p => p.Address1);
            builder.Property(p => p.Address2);
            builder.Property(p => p.City);
            builder.Property(p => p.State);
            builder.Property(p => p.PostalCode);
            builder.Property(p => p.Country);
            builder.Property(p => p.Phone);
            builder.Property(p => p.Email);
            builder.Property(p => p.VoiceMail);
            builder.Property(p => p.Password);
            builder.Property(p => p.CreditCard);
            builder.Property(p => p.CreditCardTypeID);
            builder.Property(p => p.CardExpMo);
            builder.Property(p => p.CardExpYr);
            builder.Property(p => p.BillingAddress);
            builder.Property(p => p.BillingCity);
            builder.Property(p => p.BillingRegion);
            builder.Property(p => p.BillingPostalCode);
            builder.Property(p => p.BillingCountry);
            builder.Property(p => p.ShipAddress);
            builder.Property(p => p.ShipCity);
            builder.Property(p => p.ShipRegion);
            builder.Property(p => p.ShipPostalCode);
            builder.Property(p => p.ShipCountry);
            builder.Property(p => p.DateEntered);
        }
    }
}
