using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICartService cartService;
        private readonly IBookingRepository bookingRepository;

        public CartController(UserManager<ApplicationUser> userManager, ICartService cartService, IBookingRepository bookingRepository)
        {
            this.userManager = userManager;
            this.cartService = cartService;
            this.bookingRepository = bookingRepository;
        }

        public IActionResult Index()
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return RedirectToAction("Home", "Index");
            
            CartViewModel cart = cartService.GetCartViewModel(userId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Index(CartViewModel cartViewModel)
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return RedirectToAction("Home", "Index");

            CartViewModel cart = cartService.GetCartViewModel(userId);
            cartViewModel.Items = cart.Items;
            
            if (!ModelState.IsValid)
            {
                return View(cartViewModel);
            }

            DateTime startDate = (DateTime)cartViewModel.StartDate!;
            DateTime endDate = (DateTime)cartViewModel.EndDate!;

            if (DateTime.Today > startDate)
            {
                ModelState.AddModelError(nameof(CartViewModel.ErrorMessage), "Startdatoen må ikke være i fortiden.");
                return View(cartViewModel);    
            }

            if (startDate > endDate)
            {
                ModelState.AddModelError(nameof(CartViewModel.ErrorMessage), "Startdatoen må ikke være efter slutdatoen.");
                return View(cartViewModel);    
            }

            for (int i = 0; i < cartViewModel.Items.Count; i++)
            {
                CartItemViewModel cartItem = cartViewModel.Items[i];
                bool unavailable = cartItem.Products.Any(product => bookingRepository.IsBookingAvailable((int)product.ProductId!, product.Quantity, startDate, endDate) == false);
                if (!unavailable) continue;

                string errorMessage = cartItem.Package != null 
                    ? "Denne pakke er ikke tilgængelig i den valgte periode." 
                    : "Dette produkt er ikke tilgængeligt i den valgte periode.";

                ModelState.AddModelError($"Items[{i}].ErrorMessage", errorMessage);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(CartViewModel.ErrorMessage), "Et eller flere produkter i din kurv er ikke tilgængelige i den valgte periode.");
                return View(cartViewModel);
            }

            List<CartItem> cartItems = cartViewModel.Items.SelectMany(item => item.Products).ToList();
            List<BookingProduct> bookingProducts = cartItems
                .Where(item => item.ProductId != null)
                .Select(item => new BookingProduct
                {
                    ProductId = (int)item.ProductId!,
                    Quantity = item.Quantity
                })
                .ToList();

            int rentalDays = (endDate.Date - startDate.Date).Days + 1;
            double totalPricePerDay = cartViewModel.Items.Sum(item =>
            {
                if (item.Package != null)
                {
                    double packagePrice = item.Products.Sum(product => product.Product!.Price);
                    return packagePrice * 0.80;
                }
                else
                {
                    CartItem cartItem = item.Products.First();
                    return cartItem.Product!.Price * cartItem.Quantity;
                }
            });

            double totalPrice = totalPricePerDay * rentalDays;

            Booking booking = new Booking
            {
                StartDate = startDate,
                EndDate = endDate,
                UserId = userId,
                BookingProducts = bookingProducts,
                Price = totalPrice
            };
    
            bookingRepository.Create(booking);
            cartService.Delete(cartItems.Select(item => item.Id).ToList());

            return RedirectToAction(nameof(BookingsController.Index), "Bookings");  
        }

        [HttpPost]
        public IActionResult UpdateQuantity(CartItem cartItem)
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return RedirectToAction("Home", "Index");

            cartService.Update(cartItem);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveProduct(CartItem cartItem)
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return RedirectToAction("Home", "Index");

            Console.WriteLine(cartItem.Id);
            cartService.Delete(cartItem.Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemovePackage(CartItemViewModel cartItem)
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return RedirectToAction("Home", "Index");

            List<int> ids = cartItem.Products.Select(item => item.Id).ToList();
            cartService.Delete(ids);

            return RedirectToAction(nameof(Index));
        }
    }
}

