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
        }
    }
}
