using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBookingRepository bookingRepo;

        public BookingsController(IBookingRepository bookingRepo, UserManager<ApplicationUser> userManager)
        {
            this.bookingRepo = bookingRepo;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return RedirectToAction("Home", "Index");

            List<Booking> bookings = bookingRepo.GetAllByUserId(userId);
            return View(bookings);
        }

        public IActionResult Delete(int bookingId)
        {
            bookingRepo.Delete(bookingId);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Edit(int bookingId)
        {
            Booking? booking = bookingRepo.GetById(bookingId);
            if (booking == null) return View();

            BookingEditViewModel bookingVM = new BookingEditViewModel(booking);
            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult Edit(BookingEditViewModel bookingVM)
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

            bookingRepo.Update(bookingVM);
            return RedirectToAction(nameof(Index));
        }
    }
}
