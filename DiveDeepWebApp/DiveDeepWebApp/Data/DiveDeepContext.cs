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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}