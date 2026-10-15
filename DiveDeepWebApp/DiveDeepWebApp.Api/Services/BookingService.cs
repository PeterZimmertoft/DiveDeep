using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Mappers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;

namespace DiveDeepWebApp.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<List<BookingDTO>> GetAllByUserIdAsync(string userId)
        {
            List<Booking> bookings = await bookingRepository.GetAllByUserIdAsync(userId);
            List<BookingDTO> bookingDTOs = bookings
                .Select(b => b.ToDTO())
                .ToList();

            return bookingDTOs;
        }

        public async Task UpdateAsync(int bookingId, UpdateBookingDTO bookingDTO)
        {
            Booking? booking = await bookingRepository.GetByIdAsync(bookingId);
            if (booking == null) throw new Exception("Booking not found");

            booking.StartDate = bookingDTO.StartDate;
            booking.EndDate = bookingDTO.EndDate;

            await bookingRepository.UpdateAsync(booking);
        }

        public async Task DeleteAsync(int bookingId)
        {
            Booking? booking = await bookingRepository.GetByIdAsync(bookingId);
            if (booking == null) throw new Exception("Booking not found");

            await bookingRepository.DeleteAsync(bookingId);
        }
    }
}
