using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllAsync();
        Task<List<BookingDTO>> GetAllByUserIdAsync(string userId);
        Task<Booking?> GetByIdAsync(int id);

        Task CreateAsync(string userId, CreateBookingDTO bookingDTO);
        Task UpdateAsync(Booking booking, UpdateBookingDTO bookingDTO);
        Task DeleteAsync(Booking booking);
    }
}