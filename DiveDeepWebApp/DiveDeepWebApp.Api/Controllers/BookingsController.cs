using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBookingService bookingService;

        public BookingsController(UserManager<ApplicationUser> userManager, IBookingService bookingService)
        {
            this.userManager = userManager;
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserIdAsync()
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                List<BookingDTO> bookings = await bookingService.GetAllByUserIdAsync(userId);
                return Ok(bookings);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{bookingId}")]
        public async Task<IActionResult> UpdateBookingAsync(int bookingId, [FromBody] UpdateBookingDTO bookingDTO)
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                await bookingService.UpdateAsync(bookingId, bookingDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteAsync(int bookingId)
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                await bookingService.DeleteAsync(bookingId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}