using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfDataAccess.Configuration
{
    public class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.CoffeeAmounts)
                    .WithOne(x => x.Coffee)
                    .HasForeignKey(x => x.CoffeeId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
