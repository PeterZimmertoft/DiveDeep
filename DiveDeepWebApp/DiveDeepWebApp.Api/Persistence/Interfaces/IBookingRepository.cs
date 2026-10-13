using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface IBookingRepository
    {
        Task CreateAsync(Booking booking);
        Task DeleteAsync(int bookingId);
        Task UpdateAsync(Booking booking);

        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int bookingId);
        Task<List<Booking>> GetAllByUserIdAsync(string userId);

        Task<bool> IsBookingAvailableAsync(int productId, int quantity, DateTime startDate, DateTime endDate);
    }
}
