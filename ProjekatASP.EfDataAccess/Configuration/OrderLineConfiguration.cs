using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfDataAccess.Configuration
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CoffeeName).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.CoffeeAmount)
                    .WithMany(x => x.OrderLines)
                    .HasForeignKey(x => x.CoffeeAmountId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
