using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<ClsOrderItem>
    {
        public void Configure(EntityTypeBuilder<ClsOrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(n => new { n.Orderid, n.Productid });    
        }
    }
}
