using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;

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
