using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CartController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<CartItemViewModel> cartItems = await client.GetFromJsonAsync<List<CartItemViewModel>>("api/cart");
                CartViewModel cart = new CartViewModel
                {
                    Items = cartItems,
                    StartDate = null,
                    EndDate = null
                };

                return View(cart);
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(CartViewModel cart)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<CartItemViewModel> cartItems = await client.GetFromJsonAsync<List<CartItemViewModel>>("api/cart");
                cart.Items = cartItems;

                if (!ModelState.IsValid)
                {
                    return View(cart);
                }

                if (DateTime.Today > cart.StartDate)
                {
                    ModelState.AddModelError(nameof(CartViewModel.ErrorMessage), "Startdatoen må ikke være i fortiden.");
                    return View(cart);
                }

                if (cart.StartDate > cart.EndDate)
                {
                    ModelState.AddModelError(nameof(CartViewModel.ErrorMessage), "Startdatoen må ikke være efter slutdatoen.");
                    return View(cart);
                }

                using HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/bookings",
                    new
                    {
                        StartDate = cart.StartDate,
                        EndDate = cart.EndDate
                    }
                );

                if (!response.IsSuccessStatusCode)
                {
                    ErrorMessageViewModel? errorMessage = await response.Content.ReadFromJsonAsync<ErrorMessageViewModel>();

                    if (errorMessage != null && errorMessage.ErrorMessage != null)
                    {
                        ModelState.AddModelError(nameof(CartViewModel.ErrorMessage), errorMessage.ErrorMessage);
                        return View(cart);
                    }
                }

                return RedirectToAction(nameof(BookingsController.Index), "Bookings");
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int cartItemId, CartItemViewModel cartItem)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                await client.PatchAsJsonAsync(
                    $"api/cart/{cartItemId}",
                    new
                    {
                        Quantity = cartItem.Quantity,
                    }
                );

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int cartItemId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                await client.DeleteAsync($"api/cart/{cartItemId}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

