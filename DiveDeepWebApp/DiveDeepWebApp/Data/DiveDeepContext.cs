using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Data
{
    public class DiveDeepContext : DbContext
    {
        DbSet<BCD> BCDs { get; set; }

        DbSet<Booking> Bookings { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Fin> Fins { get; set; }

        DbSet<Mask> Masks { get; set; }

        DbSet<Package> Packages { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Regulator> Regulators { get; set; }

        DbSet<Suit> Suits { get; set; }

        DbSet<Tank> Tanks { get; set; }

        DbSet<PackageProduct> PackageProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Category>(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne<BCD>(product => product.BCD)
                .WithOne(bcd => bcd.Product)
                .HasForeignKey<Product>(product => product.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Fin>(product => product.Fin)
                .WithOne(fin => fin.Product)
                .HasForeignKey<Product>(product => product.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Mask>(product => product.Mask)
                .WithOne(mask => mask.Product)
                .HasForeignKey<Product>(product => product.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Regulator>(product => product.Regulator)
                .WithOne(regulator => regulator.Product)
                .HasForeignKey<Product>(product => product.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Suit>(product => product.Suit)
                .WithOne(suit => suit.Product)
                .HasForeignKey<Product>(product => product.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Tank>(product => product.Tank)
                .WithOne(tank => tank.Product)
                .HasForeignKey<Product>(product => product.Id);

            modelBuilder.Entity<PackageProduct>()
                .HasKey(packageProduct => new { packageProduct.PackageId, packageProduct.ProductId });

        }
    }
}