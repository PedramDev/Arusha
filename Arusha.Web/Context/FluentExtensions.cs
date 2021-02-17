using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arusha.Domain.Context
{
    public static class FluentExtensions
    {

        public static void Init(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasMany(y => y.Orders)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Category>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasOne(x => x.Parent)
                .WithMany(x => x.Childs)
                .HasForeignKey(x => x.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Variant>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasOne(x => x.Product)
                .WithMany(x => x.Variants)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasMany(x=>x.BuyPriceHistory)
                .WithOne(x=>x.Variant)
                .HasForeignKey(x=>x.VariantId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasMany(x => x.SellPriceHistory)
                .WithOne(x => x.Variant)
                .HasForeignKey(x => x.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasMany(x => x.Items)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<OrderItems>(x =>
            {
                x.HasKey(x => x.Id);
            });

        }

    }
}
