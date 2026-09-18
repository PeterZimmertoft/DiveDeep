using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IBookingRepository
    {
        void Create(Booking booking);
        List<Booking> GetAllByUserId(string userId);

        bool IsBookingAvailable(int productId, int quantity, DateTime startDate, DateTime endDate);
    }
}
