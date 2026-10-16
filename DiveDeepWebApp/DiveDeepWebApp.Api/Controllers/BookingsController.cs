using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Mappers;
using DiveDeepWebApp.Api.Models;
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

        [Authorize(Roles = "Admin")]
        [Route("/api/admin/[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                List<BookingDTO> bookings = await bookingService.GetAllAsync();
                return Ok(bookings);
            }
            catch
            {
                return BadRequest();
            }
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

        [HttpPost]
        public async Task<IActionResult> CreateBookingAsync(int bookingId, [FromBody] CreateBookingDTO bookingDTO)
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                await bookingService.CreateAsync(userId, bookingDTO);
                return Ok();
            }
            catch (ErrorMessageException exception)
            {
                return BadRequest(exception.ToDTO());
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

                Booking? booking = await bookingService.GetByIdAsync(bookingId);
                if (booking == null) return NotFound();

                if (booking.UserId != userId)
                {
                    if (!User.IsInRole("Admin"))
                    {
                        return Forbid();
                    }
                }

                await bookingService.UpdateAsync(booking, bookingDTO);
                return Ok();
            }
            catch (ErrorMessageException exception)
            {
                return BadRequest(exception.ToDTO());
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

                Booking? booking = await bookingService.GetByIdAsync(bookingId);
                if (booking == null) return NotFound();

                if (booking.UserId != userId)
                {
                    if (!User.IsInRole("Admin"))
                    {
                        return Forbid();
                    }
                }

                await bookingService.DeleteAsync(booking);
                return Ok();
            }
            catch (ErrorMessageException exception)
            {
                return BadRequest(exception.ToDTO());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}