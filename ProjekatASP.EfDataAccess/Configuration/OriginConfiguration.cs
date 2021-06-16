using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfDataAccess.Configuration
{
    public class OriginConfiguration : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Coffees)
                    .WithOne(x => x.Origin)
                    .HasForeignKey(x => x.OriginId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
