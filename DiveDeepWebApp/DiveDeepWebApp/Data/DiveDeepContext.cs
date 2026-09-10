using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Data
{
    public class DiveDeepContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<BCD> BCDs { get; set; }
        public DbSet<Fin> Fins { get; set; }
        public DbSet<Mask> Masks { get; set; }
        public DbSet<Regulator> Regulators { get; set; }
        public DbSet<Suit> Suits { get; set; }
        public DbSet<Tank> Tanks { get; set; }

        public DiveDeepContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasOne<Category>(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);

            modelBuilder.Entity<BCD>().ToTable("BCDs");
            modelBuilder.Entity<Suit>().ToTable("Suits");
            modelBuilder.Entity<Tank>().ToTable("Tanks");
            modelBuilder.Entity<Regulator>().ToTable("Regulators");
            modelBuilder.Entity<Mask>().ToTable("Masks");
            modelBuilder.Entity<Fin>().ToTable("Fins");

            //modelBuilder.Entity<PackageProduct>()
            //    .HasKey(packageProduct => new { packageProduct.PackageId, packageProduct.ProductId });

            //modelBuilder.Entity<PackageProduct>()
            //    .HasOne<Package>(pp => pp.Package)
            //    .WithMany(p => p.PackageProducts)
            //    .HasForeignKey(pp => pp.PackageId);

            //modelBuilder.Entity<PackageProduct>()
            //    .HasOne<Product>(pp => pp.Product)
            //    .WithMany(p => p.PackageProducts)
            //    .HasForeignKey(pp => pp.ProductId);

            SeedData(modelBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            byte[] noImage = Array.Empty<byte>();
            byte[] bcdImage = File.ReadAllBytes("./wwwroot/BCD.png");
            byte[] suitImage = File.ReadAllBytes("./wwwroot/Suit.png");
            byte[] tankImage = File.ReadAllBytes("./wwwroot/Tank.png");
            byte[] regulatorImage = File.ReadAllBytes("./wwwroot/regulator.png");
            byte[] maskImage = File.ReadAllBytes("./wwwroot/mask.png");
            byte[] finImage = File.ReadAllBytes("./wwwroot/fin.png");

            byte[] divingSetImage = File.ReadAllBytes("./wwwroot/divingSet.png");
            byte[] snorkelSetImage = File.ReadAllBytes("./wwwroot/snorkelSet.png");

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "BCD", Description = string.Empty, Image = bcdImage },
                new Category { Id = 2, Name = "Dykkerdragter", Description = string.Empty, Image = suitImage },
                new Category { Id = 3, Name = "Tanke", Description = string.Empty, Image = tankImage },
                new Category { Id = 4, Name = "Regulatorsæt", Description = string.Empty, Image = regulatorImage },
                new Category { Id = 5, Name = "Maske/Snorkel", Description = string.Empty, Image = maskImage },
                new Category { Id = 6, Name = "Finner", Description = string.Empty, Image = finImage }
            );

            modelBuilder.Entity<BCD>().HasData(
                new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite BCD", Size = "S", Price = 125, CategoryId = 1, Image = noImage },
                new BCD { Id = 2, Brand = "Scubapro", Model = "Navigator Lite BCD", Size = "M", Price = 125, CategoryId = 1, Image = noImage },
                new BCD { Id = 3, Brand = "Scubapro", Model = "Navigator Lite BCD", Size = "L", Price = 125, CategoryId = 1, Image = noImage },

                new BCD { Id = 4, Brand = "Scubapro", Model = "BCD Glide", Size = "S", Price = 140, CategoryId = 1, Image = noImage }, 
                new BCD { Id = 5, Brand = "Scubapro", Model = "BCD Glide", Size = "M", Price = 140, CategoryId = 1, Image = noImage },
                new BCD { Id = 6, Brand = "Scubapro", Model = "BCD Glide", Size = "L", Price = 140, CategoryId = 1, Image = noImage },

                new BCD { Id = 7, Brand = "Scubapro", Model = "BCD Hydros Pro", Size = "S", Price = 200, CategoryId = 1, Image = noImage },
                new BCD { Id = 8, Brand = "Scubapro", Model = "BCD Hydros Pro", Size = "M", Price = 200, CategoryId = 1, Image = noImage },
                new BCD { Id = 9, Brand = "Scubapro", Model = "BCD Hydros Pro", Size = "L", Price = 200, CategoryId = 1, Image = noImage },

                new BCD { Id = 10, Brand = "Seac", Model = "BCD Modular", Size = "S", Price = 145, CategoryId = 1, Image = noImage },
                new BCD { Id = 11, Brand = "Seac", Model = "BCD Modular", Size = "M", Price = 145, CategoryId = 1, Image = noImage },
                new BCD { Id = 12, Brand = "Seac", Model = "BCD Modular", Size = "L", Price = 145, CategoryId = 1, Image = noImage }
            );

            modelBuilder.Entity<Suit>().HasData(
                new Suit { Id = 13, Brand = "Scubapro", Model = "Definition", Size = "XS", Type = "Våddragt", Gender = "Herre", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 14, Brand = "Scubapro", Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Herre", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 15, Brand = "Scubapro", Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Herre", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 16, Brand = "Scubapro", Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Herre", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 17, Brand = "Scubapro", Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Herre", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                
                new Suit { Id = 18, Brand = "Scubapro", Model = "Definition", Size = "XS", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 19, Brand = "Scubapro", Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 20, Brand = "Scubapro", Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 21, Brand = "Scubapro", Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 22, Brand = "Scubapro", Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                
                new Suit { Id = 23, Brand = "Scubapro", Model = "Definition", Size = "XS", Type = "Våddragt", Gender = "Herre", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 24, Brand = "Scubapro", Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Herre", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 25, Brand = "Scubapro", Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Herre", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 26, Brand = "Scubapro", Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Herre", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 27, Brand = "Scubapro", Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Herre", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                
                new Suit { Id = 28, Brand = "Scubapro", Model = "Definition", Size = "XS", Type = "Våddragt", Gender = "Dame", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 29, Brand = "Scubapro", Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Dame", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 30, Brand = "Scubapro", Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Dame", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 31, Brand = "Scubapro", Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Dame", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 32, Brand = "Scubapro", Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Dame", Thickness = "3 mm", Price = 100, CategoryId = 2, Image = noImage },
                
                new Suit { Id = 33, Brand = "Scubapro", Model = "Definition", Size = "XS", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 34, Brand = "Scubapro", Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 35, Brand = "Scubapro", Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 36, Brand = "Scubapro", Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 37, Brand = "Scubapro", Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 100, CategoryId = 2, Image = noImage },
                
                new Suit { Id = 38, Brand = "Scubapro", Model = "Definition", Size = "XS", Type = "Våddragt", Gender = "Dame", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 39, Brand = "Scubapro", Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Dame", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 40, Brand = "Scubapro", Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Dame", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 41, Brand = "Scubapro", Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Dame", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 42, Brand = "Scubapro", Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Dame", Thickness = "7 mm", Price = 100, CategoryId = 2, Image = noImage },

                new Suit { Id = 43, Brand = "Waterproof", Model = "W5", Size = "XS", Type = "Våddragt", Gender = "Herre", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 44, Brand = "Waterproof", Model = "W5", Size = "S", Type = "Våddragt", Gender = "Herre", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 45, Brand = "Waterproof", Model = "W5", Size = "M", Type = "Våddragt", Gender = "Herre", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 46, Brand = "Waterproof", Model = "W5", Size = "L", Type = "Våddragt", Gender = "Herre", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 47, Brand = "Waterproof", Model = "W5", Size = "XL", Type = "Våddragt", Gender = "Herre", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },

                new Suit { Id = 48, Brand = "Waterproof", Model = "W5", Size = "XS", Type = "Våddragt", Gender = "Dame", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 49, Brand = "Waterproof", Model = "W5", Size = "S", Type = "Våddragt", Gender = "Dame", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 50, Brand = "Waterproof", Model = "W5", Size = "M", Type = "Våddragt", Gender = "Dame", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 51, Brand = "Waterproof", Model = "W5", Size = "L", Type = "Våddragt", Gender = "Dame", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
                new Suit { Id = 52, Brand = "Waterproof", Model = "W5", Size = "XL", Type = "Våddragt", Gender = "Dame", Thickness = "3.5 mm", Price = 100, CategoryId = 2, Image = noImage },
            
                new Suit { Id = 53, Brand = "Fourth Element", Model = "Proteus", Size = "XS", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 54, Brand = "Fourth Element", Model = "Proteus", Size = "S", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 55, Brand = "Fourth Element", Model = "Proteus", Size = "M", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 56, Brand = "Fourth Element", Model = "Proteus", Size = "L", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 57, Brand = "Fourth Element", Model = "Proteus", Size = "XL", Type = "Våddragt", Gender = "Herre", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },

                new Suit { Id = 58, Brand = "Fourth Element", Model = "Proteus", Size = "XS", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 59, Brand = "Fourth Element", Model = "Proteus", Size = "S", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 60, Brand = "Fourth Element", Model = "Proteus", Size = "M", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 61, Brand = "Fourth Element", Model = "Proteus", Size = "L", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },
                new Suit { Id = 62, Brand = "Fourth Element", Model = "Proteus", Size = "XL", Type = "Våddragt", Gender = "Dame", Thickness = "5 mm", Price = 120, CategoryId = 2, Image = noImage },

                new Suit { Id = 63, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XS", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 64, Brand = "Scubapro", Model = "Exodry 4.0", Size = "S", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 65, Brand = "Scubapro", Model = "Exodry 4.0", Size = "M", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 66, Brand = "Scubapro", Model = "Exodry 4.0", Size = "L", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 67, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XL", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },

                new Suit { Id = 68, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XS", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 69, Brand = "Scubapro", Model = "Exodry 4.0", Size = "S", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 70, Brand = "Scubapro", Model = "Exodry 4.0", Size = "M", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 71, Brand = "Scubapro", Model = "Exodry 4.0", Size = "L", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },
                new Suit { Id = 72, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XL", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 300, CategoryId = 2, Image = noImage },

                new Suit { Id = 73, Brand = "Waterproof", Model = "D7 Evo", Size = "XS", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 74, Brand = "Waterproof", Model = "D7 Evo", Size = "S", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 75, Brand = "Waterproof", Model = "D7 Evo", Size = "M", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 76, Brand = "Waterproof", Model = "D7 Evo", Size = "L", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 77, Brand = "Waterproof", Model = "D7 Evo", Size = "XL", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },

                new Suit { Id = 78, Brand = "Waterproof", Model = "D7 Evo", Size = "XS", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 79, Brand = "Waterproof", Model = "D7 Evo", Size = "S", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 80, Brand = "Waterproof", Model = "D7 Evo", Size = "M", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 81, Brand = "Waterproof", Model = "D7 Evo", Size = "L", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },
                new Suit { Id = 82, Brand = "Waterproof", Model = "D7 Evo", Size = "XL", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 320, CategoryId = 2, Image = noImage },

                new Suit { Id = 83, Brand = "Santi", Model = "E.Lite Plus", Size = "XS", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 84, Brand = "Santi", Model = "E.Lite Plus", Size = "S", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 85, Brand = "Santi", Model = "E.Lite Plus", Size = "M", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 86, Brand = "Santi", Model = "E.Lite Plus", Size = "L", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 87, Brand = "Santi", Model = "E.Lite Plus", Size = "XL", Type = "Tørdragt", Gender = "Herre", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },

                new Suit { Id = 88, Brand = "Santi", Model = "E.Lite Plus", Size = "XS", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 89, Brand = "Santi", Model = "E.Lite Plus", Size = "S", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 90, Brand = "Santi", Model = "E.Lite Plus", Size = "M", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 91, Brand = "Santi", Model = "E.Lite Plus", Size = "L", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage },
                new Suit { Id = 92, Brand = "Santi", Model = "E.Lite Plus", Size = "XL", Type = "Tørdragt", Gender = "Dame", Thickness = "N/A", Price = 350, CategoryId = 2, Image = noImage }
            );

            modelBuilder.Entity<Tank>().HasData(
                new Tank { Id = 93, Brand = "Scubapro", Volume = 5, Price = 150, CategoryId = 3, Image = noImage },
                new Tank { Id = 94, Brand = "Scubapro", Volume = 10, Price = 160, CategoryId = 3, Image = noImage },
                new Tank { Id = 95, Brand = "Scubapro", Volume = 12, Price = 170, CategoryId = 3, Image = noImage },
                new Tank { Id = 96, Brand = "Scubapro", Volume = 15, Price = 180, CategoryId = 3, Image = noImage }
            );

            modelBuilder.Entity<Regulator>().HasData(
                new Regulator { Id = 97, Brand = "Scubapro", FirstStage = "MK25EVO", SecondStage = "S600", Octopus = "R105", Price = 125, CategoryId = 4, Image = noImage },
                new Regulator { Id = 98, Brand = "Scubapro", FirstStage = "MK17EVO", SecondStage = "C370", Octopus = "R095", Price = 100, CategoryId = 4, Image = noImage },
                new Regulator { Id = 99, Brand = "Scubapro", FirstStage = "MK25EVO BT", SecondStage = "A700 Carbon BT", Octopus = "S270", Price = 150, CategoryId = 4, Image = noImage }
            );

            modelBuilder.Entity<Mask>().HasData(
                new Mask { Id = 100, Brand = "Scubapro", Model = "Ghost", Price = 50, CategoryId = 5, Image = noImage },
                new Mask { Id = 101, Brand = "Scubapro", Model = "D-Mask", Price = 60, CategoryId = 5, Image = noImage },
                new Mask { Id = 102, Brand = "Scubapro", Model = "Spectra Mini", Price = 50, CategoryId = 5, Image = noImage },
                new Mask { Id = 103, Brand = "Scubapro", Model = "Crystal VU", Price = 75, CategoryId = 5, Image = noImage },
                new Mask { Id = 104, Brand = "Fourth Element", Model = "Scout Kontrast", Price = 75, CategoryId = 5, Image = noImage },
                new Mask { Id = 105, Brand = "Fourth Element", Model = "Scout Enhance", Price = 75, CategoryId = 5, Image = noImage },
                new Mask { Id = 106, Brand = "Tusa", Model = "Element", Price = 75, CategoryId = 5, Image = noImage }
            );

            modelBuilder.Entity<Fin>().HasData(
                new Fin { Id = 107, Brand = "Scubapro", Model = "Jet Fin", Size = "XS", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 108, Brand = "Scubapro", Model = "Jet Fin", Size = "S", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 109, Brand = "Scubapro", Model = "Jet Fin", Size = "M", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 110, Brand = "Scubapro", Model = "Jet Fin", Size = "L", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 111, Brand = "Scubapro", Model = "Jet Fin", Size = "XL", Price = 50, CategoryId = 6, Image = noImage },

                new Fin { Id = 112, Brand = "Scubapro", Model = "GO Travel", Size = "XS", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 113, Brand = "Scubapro", Model = "GO Travel", Size = "S", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 114, Brand = "Scubapro", Model = "GO Travel", Size = "M", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 115, Brand = "Scubapro", Model = "GO Travel", Size = "L", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 116, Brand = "Scubapro", Model = "GO Travel", Size = "XL", Price = 50, CategoryId = 6, Image = noImage },

                new Fin { Id = 117, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XS", Price = 60, CategoryId = 6, Image = noImage },
                new Fin { Id = 118, Brand = "Scubapro", Model = "Seawing Supernova", Size = "S", Price = 60, CategoryId = 6, Image = noImage },
                new Fin { Id = 119, Brand = "Scubapro", Model = "Seawing Supernova", Size = "M", Price = 60, CategoryId = 6, Image = noImage },
                new Fin { Id = 120, Brand = "Scubapro", Model = "Seawing Supernova", Size = "L", Price = 60, CategoryId = 6, Image = noImage },
                new Fin { Id = 121, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XL", Price = 60, CategoryId = 6, Image = noImage },

                new Fin { Id = 122, Brand = "Seac", Model = "Propulsion", Size = "XS", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 123, Brand = "Seac", Model = "Propulsion", Size = "S", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 124, Brand = "Seac", Model = "Propulsion", Size = "M", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 125, Brand = "Seac", Model = "Propulsion", Size = "L", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 126, Brand = "Seac", Model = "Propulsion", Size = "XL", Price = 50, CategoryId = 6, Image = noImage },

                new Fin { Id = 127, Brand = "Seac", Model = "ALA", Size = "XS", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 128, Brand = "Seac", Model = "ALA", Size = "S", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 129, Brand = "Seac", Model = "ALA", Size = "M", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 130, Brand = "Seac", Model = "ALA", Size = "L", Price = 50, CategoryId = 6, Image = noImage },
                new Fin { Id = 131, Brand = "Seac", Model = "ALA", Size = "XL", Price = 50, CategoryId = 6, Image = noImage },

                new Fin { Id = 132, Brand = "Fourth Element", Model = "Tech", Size = "XS", Price = 75, CategoryId = 6, Image = noImage },
                new Fin { Id = 133, Brand = "Fourth Element", Model = "Tech", Size = "S", Price = 75, CategoryId = 6, Image = noImage },
                new Fin { Id = 134, Brand = "Fourth Element", Model = "Tech", Size = "M", Price = 75, CategoryId = 6, Image = noImage },
                new Fin { Id = 135, Brand = "Fourth Element", Model = "Tech", Size = "L", Price = 75, CategoryId = 6, Image = noImage },
                new Fin { Id = 136, Brand = "Fourth Element", Model = "Tech", Size = "XL", Price = 75, CategoryId = 6, Image = noImage },

                new Fin { Id = 137, Brand = "Fourth Element", Model = "Rec Fin", Size = "XS", Price = 80, CategoryId = 6, Image = noImage },
                new Fin { Id = 138, Brand = "Fourth Element", Model = "Rec Fin", Size = "S", Price = 80, CategoryId = 6, Image = noImage },
                new Fin { Id = 139, Brand = "Fourth Element", Model = "Rec Fin", Size = "M", Price = 80, CategoryId = 6, Image = noImage },
                new Fin { Id = 140, Brand = "Fourth Element", Model = "Rec Fin", Size = "L", Price = 80, CategoryId = 6, Image = noImage },
                new Fin { Id = 141, Brand = "Fourth Element", Model = "Rec Fin", Size = "XL", Price = 80, CategoryId = 6, Image = noImage }
            );

            //modelBuilder.Entity<Package>().HasData(
            //    new { Id = 1, Name = "Komplet dykkersæt", Image = divingSetImage },
            //    new { Id = 2, Name = "Komplet snorkelsæt", Image = snorkelSetImage }
            //);

            //modelBuilder.Entity<PackageProduct>().HasData(
            //    new { PackageId = 1, ProductId = 1 },
            //    new { PackageId = 1, ProductId = 5 },
            //    new { PackageId = 1, ProductId = 17 },
            //    new { PackageId = 1, ProductId = 13 },
            //    new { PackageId = 1, ProductId = 27 },
            //    new { PackageId = 1, ProductId = 20 },
            //    new { PackageId = 2, ProductId = 21 },
            //    new { PackageId = 2, ProductId = 28 }
            //);
        }
    }
}
