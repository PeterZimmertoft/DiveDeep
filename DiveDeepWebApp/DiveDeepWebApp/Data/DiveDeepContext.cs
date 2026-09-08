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

            SeedData(modelBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            byte[] noImage = Array.Empty<byte>();
            byte[] bcdImage = File.ReadAllBytes("../wwwroot/BCD.png");
            byte[] suitImage = File.ReadAllBytes("../wwwroot/Suit.png");
            byte[] tankImage = File.ReadAllBytes("../wwwroot/Tank.png");
            byte[] regulatorImage = File.ReadAllBytes("../wwwroot/regulator.png");
            byte[] maskImage = File.ReadAllBytes("../wwwroot/mask.png");
            byte[] finImage = File.ReadAllBytes("../wwwroot/fin.png");

            byte[] divingSetImage = File.ReadAllBytes("../wwwroot/divingSet.png");
            byte[] snorkelSetImage = File.ReadAllBytes("../wwwroot/snorkelSet.png");

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "BCD", Description = string.Empty, Route = "bcd", Image = bcdImage },
                new Category { Id = 2, Name = "Dykkerdragter", Description = string.Empty, Route = "suit", Image = suitImage },
                new Category { Id = 3, Name = "Tanke", Description = string.Empty, Route = "tank", Image = tankImage },
                new Category { Id = 4, Name = "Regulatorsæt", Description = string.Empty, Route = "regulator", Image = regulatorImage },
                new Category { Id = 5, Name = "Maske/Snorkel", Description = string.Empty, Route = "mask", Image = maskImage },
                new Category { Id = 6, Name = "Finner", Description = string.Empty, Route = "fin", Image = finImage }
            );

            modelBuilder.Entity<BCD>().HasData(
                new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite BCD", Size = "S, M, L", Price = 125, CategoryId = 1, Image = noImage },
                new BCD { Id = 2, Brand = "Scubapro", Model = "BCD Glide", Size = "S, M, L", Price = 140, CategoryId = 1, Image = noImage },
                new BCD { Id = 3, Brand = "Scubapro", Model = "BCD Hydros Pro", Size = "S, M, L", Price = 200, CategoryId = 1, Image = noImage },
                new BCD { Id = 4, Brand = "Seac", Model = "BCD Modular", Size = "S, M, L", Price = 145, CategoryId = 1, Image = noImage });

            modelBuilder.Entity<Suit>().HasData(
                new Suit { Id = 5, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 6, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 7, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 8, Brand = "Waterproof", Model = "W5", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 9, Brand = "Fourth Element", Model = "Proteus", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 10, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 11, Brand = "Waterproof", Model = "D7 Evo", Size = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 12, Brand = "Santi", Model = "E.Lite Plus", Size = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage });

            modelBuilder.Entity<Tank>().HasData(
                new Tank { Id = 13, Brand = "Scubapro", Volume = 5, Price = 150, CategoryId = 3, Image = noImage },
                new Tank { Id = 14, Brand = "Scubapro", Volume = 10, Price = 160, CategoryId = 3, Image = noImage },
                new Tank { Id = 15, Brand = "Scubapro", Volume = 12, Price = 170, CategoryId = 3, Image = noImage },
                new Tank { Id = 16, Brand = "Scubapro", Volume = 15, Price = 180, CategoryId = 3, Image = noImage });

            modelBuilder.Entity<Regulator>().HasData(
                new Regulator { Id = 17, Brand = "Scubapro", FirstStage = "MK25EVO", SecondStage = "S600", Octopus = "R105", Price = 125, CategoryId = 4, Image = noImage },
                new Regulator { Id = 18, Brand = "Scubapro", FirstStage = "MK17EVO", SecondStage = "C370", Octopus = "R095", Price = 100, CategoryId = 4, Image = noImage },
                new Regulator { Id = 19, Brand = "Scubapro", FirstStage = "MK25EVO BT", SecondStage = "A700 Carbon BT", Octopus = "S270", Price = 150, CategoryId = 4, Image = noImage });

            modelBuilder.Entity<Mask>().HasData(
                new Mask { Id = 20, Brand = "Scubapro", Model = "Ghost", Price = 50, CategoryId = 5, Image = noImage },
                new Mask { Id = 21, Brand = "Scubapro", Model = "D-Mask", Price = 60, CategoryId = 5, Image = noImage },
                new Mask { Id = 22, Brand = "Scubapro", Model = "Spectra Mini", Price = 50, CategoryId = 5, Image = noImage },
                new Mask { Id = 23, Brand = "Scubapro", Model = "Crystal VU", Price = 75, CategoryId = 5, Image = noImage },
                new Mask { Id = 24, Brand = "Fourth Element", Model = "Scout Kontrast", Price = 75, CategoryId = 5, Image = noImage },
                new Mask { Id = 25, Brand = "Fourth Element", Model = "Scout Enhance", Price = 75, CategoryId = 5, Image = noImage },
                new Mask { Id = 26, Brand = "Tusa", Model = "Element", Price = 75, CategoryId = 5, Image = noImage });

            modelBuilder.Entity<Fin>().HasData(
                new Fin { Id = 27, Brand = "Scubapro", Model = "Jet Fin", Size = "XS, S, M, L, XL", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 28, Brand = "Scubapro", Model = "GO Travel", Size = "XS, S, M, L, XL", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 29, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XS, S, M, L, XL", Price = 60, CategoryId = 6, Image = noImage },
                new Fin { Id = 30, Brand = "Seac", Model = "Propulsion", Size = "XS, S, M, L, XL", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 31, Brand = "Seac", Model = "ALA", Size = "XS, S, M, L, XL", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 32, Brand = "Fourth Element", Model = "Tech", Size = "XS, S, M, L, XL", Price = 75, CategoryId = 6, Image = noImage },
                new Fin { Id = 33, Brand = "Fourth Element", Model = "Rec Fin", Size = "XS, S, M, L, XL", Price = 80, CategoryId = 6, Image = noImage });

            modelBuilder.Entity<Package>().HasData(
                new { Id = 1, Name = "Komplet dykkersæt", Route = "divingSet", Image = divingSetImage },
                new { Id = 2, Name = "Komplet snorkelsæt", Route = "snorkelSet", Image = snorkelSetImage });

            modelBuilder.Entity<PackageProduct>().HasData(
                new { PackageId = 1, ProductId = 1 },
                new { PackageId = 1, ProductId = 5 },
                new { PackageId = 1, ProductId = 17 },
                new { PackageId = 1, ProductId = 13 },
                new { PackageId = 1, ProductId = 27 },
                new { PackageId = 1, ProductId = 20 },
                new { PackageId = 2, ProductId = 21 },
                new { PackageId = 2, ProductId = 28 });
        }
    }
}
