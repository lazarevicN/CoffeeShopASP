using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfDataAccess.Configuration
{
    public class CoffeeAmountConfiguration : IEntityTypeConfiguration<CoffeeAmount>
    {
        public void Configure(EntityTypeBuilder<CoffeeAmount> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        }
    }
}
