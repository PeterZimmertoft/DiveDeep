using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.ViewModels
{
    public class BookingEditViewModel : Booking
    {
        public string? ErrorMessage { get; set; }

        public BookingEditViewModel()
        {
        }

        public BookingEditViewModel(Booking booking)
        {
            Id = booking.Id;
            StartDate = booking.StartDate;
            EndDate = booking.EndDate;
            Price = booking.Price;
            BookingProducts = booking.BookingProducts;
            UserId = booking.UserId;
            User = booking.User;
        }
    }
}
