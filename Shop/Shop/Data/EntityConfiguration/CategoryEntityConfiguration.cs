using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Data.Entities
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CategoryName);
            builder.Property(p => p.Description);
            builder.Property(p => p.Picture);
            builder.Property(p => p.Active);
        }
    }
}
