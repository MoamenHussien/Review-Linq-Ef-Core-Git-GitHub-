using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<ClsOrder>
    {
        public void Configure(EntityTypeBuilder<ClsOrder> builder)
        {
            builder.ToTable("Order");
            builder.HasMany(n => n.orderitem).WithOne(n => n.order).HasForeignKey(n => n.Orderid);
        }
    }
}
