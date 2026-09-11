using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IBookingRepository
    {
        void Create(Booking booking);
        bool HasOverlappingBooking(int productId, DateTime startDate, DateTime endDate);
    }
}
