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
    public class CartController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICartService cartService;

        public CartController(UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            this.userManager = userManager;
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                List<CartItemDTO> cartItems = await cartService.GetAllByUserIdAsync(userId);
                return Ok(cartItems);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCartAsync([FromBody] CreateCartItemDTO cartItemDTO)
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                await cartService.CreateAsync(userId, cartItemDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{cartItemId}")]
        public async Task<IActionResult> UpdateCartQuantityAsync(int cartItemId, [FromBody] UpdateCartItemDTO cartItemDTO)
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                await cartService.UpdateAsync(cartItemId, cartItemDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveFromCartAsync(int cartItemId)
        {
            try
            {
                string? userId = userManager.GetUserId(User);
                if (userId == null) return BadRequest();

                await cartService.DeleteAsync(cartItemId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}