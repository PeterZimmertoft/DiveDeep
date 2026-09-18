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
                .ToList();
            foreach (Booking booking in bookings)
            {
                foreach (BookingProduct bookingProduct in booking.BookingProducts)
                {
                    context.Entry(bookingProduct)
                    .Reference(pp => pp.Product)
                    .Load();
                }
            }
            return bookings;
        }

        public bool HasOverlappingBooking(int productId, DateTime startDate, DateTime endDate)
        {
            return context.BookingProducts.Any(bp =>
                bp.ProductId == productId &&
                startDate < bp.Booking.EndDate &&
                endDate > bp.Booking.StartDate
            );
        }
    }
}
