using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IBookingRepository
    {
        void Create(Booking booking);
        List<Booking> GetAllByUserId(string userId);

        bool HasOverlappingBooking(int productId, DateTime startDate, DateTime endDate);
    }
}
