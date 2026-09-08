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

            modelBuilder.Entity<BCD>()
                .HasOne<Product>(bcd => bcd.Product)
                .WithOne(product => product.BCD)
                .HasForeignKey<BCD>(bcd => bcd.ProductId);

            modelBuilder.Entity<Fin>()
                .HasOne<Product>(fin => fin.Product)
                .WithOne(product => product.Fin)
                .HasForeignKey<Fin>(fin => fin.ProductId);

            modelBuilder.Entity<Mask>()
                .HasOne<Product>(mask => mask.Product)
                .WithOne(product => product.Mask)
                .HasForeignKey<Mask>(mask => mask.ProductId);

            modelBuilder.Entity<Regulator>()
                .HasOne<Product>(regulator => regulator.Product)
                .WithOne(product => product.Regulator)
                .HasForeignKey<Regulator>(regulator => regulator.ProductId);

            modelBuilder.Entity<Suit>()
                .HasOne<Product>(suit => suit.Product)
                .WithOne(product => product.Suit)
                .HasForeignKey<Suit>(suit => suit.ProductId);

            modelBuilder.Entity<Tank>()
                .HasOne<Product>(tank => tank.Product)
                .WithOne(product => product.Tank)
                .HasForeignKey<Tank>(tank => tank.ProductId);

            modelBuilder.Entity<PackageProduct>()
                .HasKey(packageProduct => new { packageProduct.PackageId, packageProduct.ProductId });

            modelBuilder.Entity<PackageProduct>()
                .HasOne<Package>(pp => pp.Package)
                .WithMany(p => p.PackageProducts)
                .HasForeignKey(pp => pp.PackageId);

            modelBuilder.Entity<PackageProduct>()
                .HasOne<Product>(pp => pp.Product)
                .WithMany(p => p.PackageProducts)
                .HasForeignKey(pp => pp.ProductId);

        }
    }
}