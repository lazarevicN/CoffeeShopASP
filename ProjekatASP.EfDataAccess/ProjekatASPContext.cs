using Microsoft.EntityFrameworkCore;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess.Configuration;
using System;

namespace ProjekatASP.EfDataAccess
{
    public class ProjekatASPContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmountConfiguration());
            modelBuilder.ApplyConfiguration(new BeanConfiguration());
            modelBuilder.ApplyConfiguration(new CoffeeConfiguration());
            modelBuilder.ApplyConfiguration(new OriginConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NGLRDBL\SQLEXPRESS;Initial Catalog=CoffeeShopASP;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Bean> Beans { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<CoffeeAmount> CoffeeAmounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
