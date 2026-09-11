using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class BookingController
    {
        private readonly IBookingRepository bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        [HttpPost]
        public void Book(ProductViewModel productVM)
        {
            Product? product = productVM.Variants
                .Find(p => p.MatchesOptions(productVM.Size, productVM.Thickness, productVM.Gender));

            bookingRepository.Create(new Booking
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                BookingProducts = new List<BookingProduct>
                {
                    new BookingProduct
                    {
                        ProductId = product.Id
                    }
                }

            });
            //return View();
        }

        
    }
}
