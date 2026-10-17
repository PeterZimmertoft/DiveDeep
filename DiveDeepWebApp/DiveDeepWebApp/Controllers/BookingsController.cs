using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BookingsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<BookingViewModel> bookings = await client.GetFromJsonAsync<List<BookingViewModel>>("api/bookings");
                return View(bookings);
            }
            catch
            {
                return View(new List<BookingViewModel>());
            }
        }

        public async Task<IActionResult> Delete(int bookingId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                await client.DeleteAsync($"api/bookings/{bookingId}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int bookingId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                BookingViewModel? booking = await client.GetFromJsonAsync<BookingViewModel?>($"api/bookings/{bookingId}");
                if (booking == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                EditBookingViewModel editBookingViewModel = new EditBookingViewModel()
                {
                    Id = booking.Id,
                    StartDate = booking.StartDate,
                    EndDate = booking.EndDate,
                    RowVersion = booking.RowVersion
                };

                return View(editBookingViewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int bookingId, EditBookingViewModel booking)
        {

            if (!ModelState.IsValid)
            {
                return View(booking);
            }

            if (DateTime.Today > booking.StartDate)
            {
                ModelState.AddModelError(nameof(EditBookingViewModel.ErrorMessage), "Startdatoen må ikke være i fortiden.");
                return View(booking);
            }

            if (booking.StartDate > booking.EndDate)
            {
                ModelState.AddModelError(nameof(EditBookingViewModel.ErrorMessage), "Startdatoen må ikke være efter slutdatoen.");
                return View(booking);
            }

            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                using HttpResponseMessage response = await client.PatchAsJsonAsync(
                    $"api/bookings/{bookingId}",
                    new
                    {
                        StartDate = booking.StartDate,
                        EndDate = booking.EndDate,
                        RowVersion = booking.RowVersion
                    }
                );

                if (!response.IsSuccessStatusCode)
                {
                    ErrorMessageViewModel? errorMessage = await response.Content.ReadFromJsonAsync<ErrorMessageViewModel>();

                    if (errorMessage != null && errorMessage.ErrorMessage != null)
                    {
                        ModelState.AddModelError(nameof(EditBookingViewModel.ErrorMessage), errorMessage.ErrorMessage);
                        return View(booking);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
