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
    public class ContractConfiguring : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.User).WithMany(c => c.Contracts).HasForeignKey(x => x.UserId);
            builder.HasOne(p => p.).WithOne(c => c.)
        }
    }
}
