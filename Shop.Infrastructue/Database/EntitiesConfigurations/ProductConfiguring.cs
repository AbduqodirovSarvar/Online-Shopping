using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructue.Database.EntitiesConfigurations
{
    public class ProductConfiguring : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasOne(p => p.Shop).WithMany(c => c.Products).HasForeignKey(f => f.ShopId);

           
        }
    }
}
