using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.PaymentType);
            builder.Property(p => p.Allowed);
        }
    }
}
