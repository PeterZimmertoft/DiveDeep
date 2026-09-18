using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
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
            string userId = userManager.GetUserId(User);
            List<Booking> bookings = bookingRepo.GetAllByUserId(userId);

            return View(bookings);
        }
    }
}
