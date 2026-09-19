using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DiveDeepContext context;
        
        public BookingRepository(DiveDeepContext context) 
        {
            this.context = context;
        }

        public void Create(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        public List<Booking> GetAllByUserId(string userId)
        {
            List<Booking> bookings = context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.BookingProducts)
                .ThenInclude(bp => bp.Product)
                .ThenInclude(p => p.Category)
                .OrderByDescending(b => b.Id)
                .ToList();
                
            return bookings;
        }

        public bool IsBookingAvailable(int productId, int quantity, DateTime startDate, DateTime endDate)
        {
            Product? product = context.Products.Find(productId);
            if (product == null) return false;

            List<BookingProduct> bookingsWithProduct = context.BookingProducts
                .Include(bp => bp.Booking)
                .Where(bp => bp.ProductId == productId)
                .Where(bp => startDate <= bp.Booking.EndDate)
                .Where(bp => endDate >= bp.Booking.StartDate)
                .ToList();

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
    }
}
