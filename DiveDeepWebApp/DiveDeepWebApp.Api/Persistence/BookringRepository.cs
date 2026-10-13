using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Api.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DiveDeepContext context;

        public BookingRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Booking booking)
        {
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllByUserIdAsync(string userId)
        {
            List<Booking> bookings = await context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.BookingProducts)
                .ThenInclude(bp => bp.Product)
                .ThenInclude(p => p.Category)
                .OrderByDescending(b => b.StartDate)
                .ToListAsync();

            return bookings;
        }

        public async Task<bool> IsBookingAvailableAsync(int productId, int quantity, DateTime startDate, DateTime endDate)
        {
            Product? product = await context.Products.FindAsync(productId);
            if (product == null) return false;

            List<BookingProduct> bookingsWithProduct = await context.BookingProducts
                .Include(bp => bp.Booking)
                .Where(bp => bp.ProductId == productId)
                .Where(bp => startDate <= bp.Booking.EndDate)
                .Where(bp => endDate >= bp.Booking.StartDate)
                .ToListAsync();

            for (DateTime day = startDate.Date; day <= endDate.Date; day = day.AddDays(1))
            {
                int bookedQuantity = bookingsWithProduct
                    .Where(bp => bp.Booking.StartDate.Date <= day)
                    .Where(bp => bp.Booking.EndDate.Date >= day)
                    .Sum(bp => bp.Quantity);

                if (bookedQuantity + quantity > product.Quantity)
                    return false;
            }

            return true;
        }

        public async Task DeleteAsync(int bookingId)
        {
            Booking? bookingToDelete = await context.Bookings.FindAsync(bookingId);
            if (bookingToDelete == null) return;

            context.Bookings.Remove(bookingToDelete);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            Booking? bookingToUpdate = await context.Bookings.FindAsync(booking.Id);
            if (bookingToUpdate == null) return;

            context.Entry(bookingToUpdate)
                .Property(b => b.RowVersion)
                .OriginalValue = booking.RowVersion;

            bookingToUpdate.StartDate = booking.StartDate;
            bookingToUpdate.EndDate = booking.EndDate;

            await context.SaveChangesAsync();
        }
        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await context.Bookings
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            List<Booking> bookings = await context.Bookings
                .Include(b => b.User)
                .Include(b => b.BookingProducts)
                .ThenInclude(bp => bp.Product)
                .ThenInclude(p => p.Category)
                .OrderByDescending(b => b.StartDate)
                .ToListAsync();

            return bookings;
        }
    }
}
