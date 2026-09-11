using DiveDeepWebApp.Persistence;

namespace DiveDeepWebApp.Controllers
{
    public class BookingController
    {
        private readonly IBookingRepository bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        
    }
}
