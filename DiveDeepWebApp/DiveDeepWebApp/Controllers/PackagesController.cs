using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DiveDeepWebApp.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PackagesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Package(int packageId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                PackageViewModel package = await client.GetFromJsonAsync<PackageViewModel>($"api/packages/{packageId}");
                return View(package);
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Package(string packageId, PackageViewModel packageViewModel)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                PackageViewModel package = await client.GetFromJsonAsync<PackageViewModel>($"api/packages/{packageId}");
                for (int i = 0; i < package.Products.Count; i++)
                {
                    ProductViewModel productViewModel = packageViewModel.Products[i];
                    ProductViewModel product = package.Products[i];

                    product.Size = productViewModel.Size;
                    product.Thickness = productViewModel.Thickness;
                    product.Gender = productViewModel.Gender;
                }

                List<int> productIds = package.Products
                    .Select(product =>
                    {
                        ProductVariantViewModel? variant = product.Variants?
                            .Find(v => v.MatchesOptions(product.Size, product.Thickness, product.Gender));

                        if (product.Variants?.Count == 1 && variant == null)
                        {
                            return product.Id;
                        }

                        if (variant == null)
                        {
                            return -1;
                        }

                        return variant.Id;
                    })
                    .Where(id => id != -1)
                    .ToList();

                if (productIds.Count != package.Products.Count)
                {
                    return View(package);
                }

                using HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/cart",
                    new
                    {
                        PackageId = packageId,
                        ProductIds = productIds
                    }
                );

                if (!response.IsSuccessStatusCode)
                {
                    return View(package);
                }

                TempData["Message"] = "Du har tilføjet denne pakke til din kurv.";
                return RedirectToAction(
                    nameof(Package),
                    new
                    {
                        packageId = package.Id
                    }
                );
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
