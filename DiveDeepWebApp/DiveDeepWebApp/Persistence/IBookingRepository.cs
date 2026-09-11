using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IBookingRepository
    {
        void Create(Booking booking);
    }
}
