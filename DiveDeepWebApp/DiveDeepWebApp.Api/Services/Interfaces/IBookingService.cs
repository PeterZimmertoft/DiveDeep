using DiveDeepWebApp.Api.DTOs;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllByUserIdAsync(string userId);

        Task UpdateAsync(int bookingId, UpdateBookingDTO bookingDTO);
        Task DeleteAsync(int bookingId);
    }
}