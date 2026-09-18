using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DiveDeepWebApp.Data;

namespace DiveDeepWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public ProductsController(UserManager<ApplicationUser> userManager, ICategoryRepository categoryRepository, IProductService productService, ICartService cartService) 
        {
            this.userManager = userManager; 
            this.categoryRepository = categoryRepository;
            this.productService = productService;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll();
            return View(categories);
        }

        public IActionResult Products(int categoryId)
        {
            ProductsViewModel productsViewModel = productService.GetByCategoryId(categoryId);
            return View(productsViewModel);
        }

        public IActionResult Product(int productId)
        {
            ProductViewModel productViewModel = productService.GetProductViewModel(productId);
            return View(productViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Product(ProductViewModel productVM)
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return View(productVM);

            List<Product> variants = productService.GetAllByName(productVM.ProductName);
            productVM.Variants = variants;

            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            Product? variant = variants.Find(p => p.MatchesOptions(productVM.Size, productVM.Thickness, productVM.Gender));
            if (variants.Count == 1 && variant == null)
            {
                variant = variants.First();
            }

            if (variant == null)
            {
                return View(productVM);
            }

            cartService.Create(new CartItem
            {
                UserId = userId,
                ProductId = variant.Id,
                Quantity = 1
            });

            TempData["Message"] = "Du har tilføjet dette produkt til din kurv.";
            
            return RedirectToAction(
                nameof(Product),
                new 
                {
                    categoryId = variant.CategoryId,
                    productId = variant.Id 
                }
            );
        } 
    }
}
