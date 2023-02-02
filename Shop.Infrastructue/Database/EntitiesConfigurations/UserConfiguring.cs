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
    public class UserConfiguring : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.HasMany(c => c.Contracts).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        }
    }
}
