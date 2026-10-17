using DiveDeepWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DiveDeepWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<CategoryViewModel> categories = await client.GetFromJsonAsync<List<CategoryViewModel>>("api/categories");
                return View(categories);
            }
            catch
            {
                return View(new List<CategoryViewModel>());
            }
        }

        public async Task<IActionResult> Products(int categoryId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                CategoryViewModel category = await client.GetFromJsonAsync<CategoryViewModel>($"api/categories/{categoryId}");
                return View(category);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
        //
        public async Task<IActionResult> Product(int productId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                ProductViewModel product = await client.GetFromJsonAsync<ProductViewModel>($"api/products/{productId}");
                return View(product);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Product(int categoryId, int productId, ProductViewModel productViewModel)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                ProductViewModel product = await client.GetFromJsonAsync<ProductViewModel>($"api/products/{productId}");
                product.Size = productViewModel.Size;
                product.Thickness = productViewModel.Thickness;
                product.Gender = productViewModel.Gender;

                int selectedProductId = product.Id;
                if (product.Variants?.Count > 1)
                {
                    ProductVariantViewModel? variant = product.Variants?
                        .Find(v => v.MatchesOptions(productViewModel.Size, productViewModel.Thickness, productViewModel.Gender));

                    if (variant == null)
                    {
                        return View(product);
                    }

                    selectedProductId = variant.Id;
                }

                using HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/cart",
                    new
                    {
                        ProductIds = new List<int>
                        {
                            selectedProductId
                        }
                    }
                );

                Console.WriteLine(response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    return View(product);
                }

                TempData["Message"] = "Du har tilføjet dette produkt til din kurv.";
                return RedirectToAction(
                    nameof(Product),
                    new
                    {
                        categoryId = categoryId,
                        productId = productId
                    }
                );
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            // string? userId = userManager.GetUserId(User);
            // if (userId == null) return View(productVM);
            //
            // List<Product> variants = productService.GetAllByName(productVM.ProductName);
            // productVM.Variants = variants;
            //
            // if (!ModelState.IsValid)
            // {
            //     return View(productVM);
            // }
            //
            // Product? variant = variants.Find(p => p.MatchesOptions(productVM.Size, productVM.Thickness, productVM.Gender));
            // if (variants.Count == 1 && variant == null)
            // {
            //     variant = variants.First();
            // }
            //
            // if (variant == null)
            // {
            //     return View(productVM);
            // }
            //
            // cartService.Create(new CartItem
            // {
            //     UserId = userId,
            //     ProductId = variant.Id,
            //     Quantity = 1
            // });
            //
            // TempData["Message"] = "Du har tilføjet dette produkt til din kurv.";
            //
            // return RedirectToAction(nameof(Index));
        }
    }
}
