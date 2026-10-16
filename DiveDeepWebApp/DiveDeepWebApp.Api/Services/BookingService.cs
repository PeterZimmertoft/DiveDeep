using DiveDeepWebApp.Api.Data;
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
        private readonly ICartService cartService;

        public BookingService(IBookingRepository bookingRepository, ICartService cartService)
        {
            this.bookingRepository = bookingRepository;
            this.cartService = cartService;
        }

        public async Task<List<BookingDTO>> GetAllAsync()
        {
            List<Booking> bookings = await bookingRepository.GetAllAsync();
            List<BookingDTO> bookingDTOs = bookings
                .Select(booking =>
                {
                    BookingDTO bookingDTO = booking.ToDTO();
                    bookingDTO.BookedBy = booking.User?.UserName ?? "Ukendt bruger";

                    return bookingDTO;
                })
                .ToList();

            return bookingDTOs;
        }

        public async Task<List<BookingDTO>> GetAllByUserIdAsync(string userId)
        {
            List<Booking> bookings = await bookingRepository.GetAllByUserIdAsync(userId);
            List<BookingDTO> bookingDTOs = bookings
                .Select(b => b.ToDTO())
                .ToList();

            return bookingDTOs;
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await bookingRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(string userId, CreateBookingDTO bookingDTO)
        {
            if (bookingDTO.StartDate < DateTime.Today)
                throw new ErrorMessageException("Startdatoen kan ikke være i fortiden.");

            if (bookingDTO.EndDate <= bookingDTO.StartDate)
                throw new ErrorMessageException("Slutdatoen skal være efter startdatoen.");

            List<CartItem> cartItems = await cartService.GetAllByUserIdAsync(userId);

            bool bookingUnavailable = false;
            foreach (var cartItem in cartItems)
            {
                bool available = await bookingRepository.IsBookingAvailableAsync((int)cartItem.ProductId!, cartItem.Quantity, bookingDTO.StartDate, bookingDTO.EndDate);
                if (!available)
                {
                    bookingUnavailable = true;
                    break;
                }
            }

            if (bookingUnavailable)
                throw new ErrorMessageException("En eller flere af de valgte produkter er ikke tilgængelige i den valgte periode.");

            // handtering af hvis 2 identiske produkter er i samme kurv, men det ikke fremgør af deres Quantity
            // f.eks. det ene produkt er en del af en pakke, og det andet produkt er et enkelt ståede produkt
            for (int i = 0; i < cartItems.Count - 1; i++)
            {
                for (int j = i + 1; j < cartItems.Count; j++)
                {
                    if (cartItems[i].ProductId == cartItems[j].ProductId)
                    {
                        cartItems[i].Quantity += 1;
                        cartItems.RemoveAt(j);
                    }
                }
            }

            List<BookingProduct> bookingProducts = cartItems
                .Where(item => item.ProductId != null)
                .Select(item => new BookingProduct
                {
                    ProductId = (int)item.ProductId!,
                    Quantity = item.Quantity
                })
                .ToList();

            int rentalDays = (bookingDTO.EndDate.Date - bookingDTO.StartDate.Date).Days + 1;
            double totalPricePerDay = cartItems.Sum(item =>
            {
                if (item.Package != null)
                {
                    double packagePrice = item.Package.PackageProducts.Sum(product => product.Product!.Price);
                    return packagePrice * 0.80;
                }
                else
                {
                    return item.Product!.Price * item.Quantity;
                }
            });

            double totalPrice = totalPricePerDay * rentalDays;

            Booking booking = new Booking
            {
                StartDate = bookingDTO.StartDate,
                EndDate = bookingDTO.EndDate,
                UserId = userId,
                BookingProducts = bookingProducts,
                Price = totalPrice
            };

            List<int> cartItemIds = cartItems
                .Select(x => x.Id)
                .ToList();

            await bookingRepository.CreateAsync(booking);
            await cartService.DeleteAsync(cartItemIds);
        }

        public async Task UpdateAsync(Booking booking, UpdateBookingDTO bookingDTO)
        {
            if (DateTime.Today >= booking.StartDate)
                throw new ErrorMessageException("Du kan ikke opdatere en booking som allerede er i gang eller afsluttet.");

            if (bookingDTO.StartDate < DateTime.Today)
                throw new ErrorMessageException("Startdatoen kan ikke være i fortiden.");

            if (bookingDTO.StartDate >= bookingDTO.EndDate)
                throw new ErrorMessageException("Slutdatoen skal være efter startdatoen.");

            booking.StartDate = bookingDTO.StartDate;
            booking.EndDate = bookingDTO.EndDate;

            await bookingRepository.UpdateAsync(booking);
        }

        public async Task DeleteAsync(Booking booking)
        {
            if (DateTime.Today >= booking.StartDate)
                throw new ErrorMessageException("Du kan ikke slette en booking som allerede er i gang eller afsluttet.");

            await bookingRepository.DeleteAsync(booking.Id);
        }
    }
}
