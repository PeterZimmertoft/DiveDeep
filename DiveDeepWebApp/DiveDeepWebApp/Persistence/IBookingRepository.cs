using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IBookingRepository
    {
        void Create(Booking booking);
        void Delete(int bookingId);
        void Update(Booking booking);

        Booking? GetById(int bookingId);
        List<Booking> GetAllByUserId(string userId);

        bool IsBookingAvailable(int productId, int quantity, DateTime startDate, DateTime endDate);
    }
}
