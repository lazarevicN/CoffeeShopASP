using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfDataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Password).IsUnique();

            builder.HasMany(x => x.Orders)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
