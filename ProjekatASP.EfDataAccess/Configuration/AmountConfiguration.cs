using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfDataAccess.Configuration
{
    public class AmountConfiguration : IEntityTypeConfiguration<Amount>
    {
        public void Configure(EntityTypeBuilder<Amount> builder)
        {
            builder.Property(x => x.PackAmount).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.AmountCoffees)
                    .WithOne(x => x.Amount)
                    .HasForeignKey(x => x.AmountId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
