using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<CLsProduct>
    {
        public void Configure(EntityTypeBuilder<CLsProduct> builder)
        {
            builder.ToTable("Product");
            builder.HasMany(n=>n.orderItems).WithOne(n=>n.product).HasForeignKey(n=>n.Productid);
            builder.Property(n => n.RowVersion).IsRowVersion();
            builder.HasQueryFilter(n => n.IsDeleted == false);
            builder.Property(n => n.price).HasPrecision(18, 2);
            builder.Property(n => n.name).IsRequired().HasMaxLength(120);
            builder.ToTable(n => n.HasCheckConstraint("ck_product_price_>0", "[price] > 0"));
            builder.ToTable(n => n.HasCheckConstraint("ck_product_quantity> 0", "[stockQty] > 0"));


        }
    }
}
