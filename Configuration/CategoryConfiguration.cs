using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<ClsCategory>
    {
        public void Configure(EntityTypeBuilder<ClsCategory> builder)
        {
            builder.ToTable("Category");
            builder.HasMany(n => n.product).WithOne(n => n.category).HasForeignKey(n => n.categoryid);
            builder.HasQueryFilter(n => n.IsDeleted == false);
            builder.Property(n => n.name).HasMaxLength(100);
        }
    }
}
