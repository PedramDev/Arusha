using Arusha.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arusha.Domain
{
    public class ArushaContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Variant> Variant { get; set; }
        public DbSet<VariantPriceSellHistory> VariantPriceSellHistory { get; set; }
        public DbSet<VariantPriceBuyHistory> VariantPriceBuyHistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbContext DbContext => this;
        public ArushaContext(DbContextOptions<ArushaContext> options)
          : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Init();

            base.OnModelCreating(modelBuilder);
        }
    }
}
