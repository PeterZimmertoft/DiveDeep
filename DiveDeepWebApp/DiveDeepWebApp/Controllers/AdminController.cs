using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;
        private readonly IBookingRepository bookingRepository;

        public AdminController(ICategoryRepository categoryRepository, IProductService productService, IBookingRepository bookingRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productService = productService;
            this.bookingRepository = bookingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<ProductsViewModel> productsVM = new List<ProductsViewModel>();
            List<Category> categories = categoryRepository.GetAll();
            categories.ForEach(category =>
            {
                ProductsViewModel productsViewModel = productService.GetByCategoryId(category.Id);
                productsVM.Add(productsViewModel); 
            });

            return View(productsVM);
        }

        public IActionResult Bookings()
        {
            List<Booking> bookings = bookingRepository.GetAll(); 
            return View(bookings);
        }

        public IActionResult DeleteBooking(int bookingId)
        {
            bookingRepository.Delete(bookingId);
            return RedirectToAction(nameof(Bookings)); 
        }

        public IActionResult EditBooking(int bookingId)
        {
            Booking? booking = bookingRepository.GetById(bookingId);
            if (booking == null) return View();

            BookingEditViewModel bookingVM = new BookingEditViewModel(booking);
            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult EditBooking(BookingEditViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookingVM);
            }

            DateTime startDate = (DateTime)bookingVM.StartDate!;
            DateTime endDate = (DateTime)bookingVM.EndDate!;

            if (DateTime.Today > startDate)
            {
                ModelState.AddModelError(nameof(BookingEditViewModel.ErrorMessage), "Startdatoen må ikke være i fortiden.");
                return View(bookingVM);
            }

            if (startDate > endDate)
            {
                ModelState.AddModelError(nameof(BookingEditViewModel.ErrorMessage), "Startdatoen må ikke være efter slutdatoen.");
                return View(bookingVM);
            }

            bookingRepository.Update(bookingVM);
            return RedirectToAction(nameof(Bookings));
        }
    }
}
