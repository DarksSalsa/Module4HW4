using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class ShipperEntityConfiguration : IEntityTypeConfiguration<ShipperEntity>
    {
        public void Configure(EntityTypeBuilder<ShipperEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CompanyName);
            builder.Property(p => p.Phone);
        }
    }
}
