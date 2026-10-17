using System.Text.Json;
using DiveDeepWebApp.ViewModels;
using DiveDeepWebApp.ViewModels.Variants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<ProductViewModel> products = await client.GetFromJsonAsync<List<ProductViewModel>>("api/products");
                List<CategoryViewModel> categories = products
                    .Select(p => p.Category)
                    .DistinctBy(c => c.Id)
                    .ToList();

                foreach (CategoryViewModel category in categories)
                {
                    List<ProductViewModel> productsInCategory = products
                        .Where(p => p.Category.Id == category.Id)
                        .ToList();

                    category.Products = productsInCategory;
                }

                return View(categories);
            }
            catch
            {
                return View(new List<CategoryViewModel>());
            }
        }

        public IActionResult CreateProduct()
        {
            ViewBag.Action = "CreateProduct";
            CreateUpdateProductViewModel productViewModel = new CreateUpdateProductViewModel();

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateUpdateProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = "CreateProduct";
                return View(productViewModel);
            }

            if (productViewModel.CategoryId == 0)
            {
                ViewBag.Action = "CreateProduct";
                ModelState.AddModelError(nameof(AdminProductViewModel.CategoryId), "Vælg venligst en kategori.");
                return View(productViewModel);
            }

            if (productViewModel.Price < 0 || productViewModel.Quantity < 0)
            {
                string propertyName = productViewModel.Price < 0 ? nameof(AdminProductViewModel.Price) : nameof(AdminProductViewModel.Quantity);
                ModelState.AddModelError(propertyName, "Det kan ikke være negativ.");
            }

            ProductViewModel? product = ValidateProduct(productViewModel);
            if (product == null)
            {
                ViewBag.Action = "CreateProduct";
                return View(productViewModel);
            }

            product.Description = productViewModel.Description ?? string.Empty;
            if (productViewModel.Image != null && productViewModel.Image.Length > 0)
            {
                await using MemoryStream memoryStream = new MemoryStream();
                await productViewModel.Image.CopyToAsync(memoryStream);
                product.Image = memoryStream.ToArray();
            }
            else
            {
                product.Image = new byte[] {};
            }

            ProductVariantViewModel variant = product.Variants!.First();
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                await client.PostAsJsonAsync($"api/products", new
                {
                    Brand = product.Brand,
                    Price = product.Price,
                    Description = product.Description,
                    Image = product.Image,
                    Quantity = product.Quantity,
                    CategoryId = productViewModel.CategoryId,
                    Variant = variant
                });

                return RedirectToAction(nameof(Products));
            }
            catch 
            {
                return View(productViewModel);
            }
        }

        public async Task<IActionResult> EditProduct(int productId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                ViewBag.Action = "EditProduct";
                CreateUpdateProductViewModel productViewModel = new CreateUpdateProductViewModel();

                ProductViewModel? product = await client.GetFromJsonAsync<ProductViewModel>($"api/products/{productId}");
                if (product == null)
                {
                    return RedirectToAction(nameof(Products));
                }

                ProductVariantViewModel? variant = product.Variants?.Find(v => productId == v.Id);
                if (variant == null)
                {
                    return RedirectToAction(nameof(Products));
                }

                productViewModel.Id = product.Id;
                productViewModel.Brand = product.Brand;
                productViewModel.Price = product.Price;
                productViewModel.Description = product.Description;
                productViewModel.Quantity = product.Quantity;
                productViewModel.CategoryId = product.Category!.Id;

                MemoryStream memoryStream = new MemoryStream(product.Image);
                IFormFile image = new FormFile(memoryStream, 0, memoryStream.Length, "image", "image.png");
                productViewModel.Image = image;

                switch (variant)
                {
                    case BCDViewModel bcd:
                    {
                        productViewModel.Model = bcd.Model;
                        productViewModel.Size = bcd.Size;
                        break;
                    }
                    case SuitViewModel suit:
                    {
                        productViewModel.Model = suit.Model;
                        productViewModel.Type = suit.Type;
                        productViewModel.Gender = suit.Gender;
                        productViewModel.Size = suit.Size;
                        productViewModel.Thickness = suit.Thickness;
                        break;
                    }
                    case TankViewModel tank:
                    {
                        productViewModel.Volume = tank.Volume;
                        break;
                    }
                    case RegulatorViewModel regulator:
                    {
                        productViewModel.FirstStage = regulator.FirstStage;
                        productViewModel.SecondStage = regulator.SecondStage;
                        productViewModel.Octopus = regulator.Octopus;
                        break;
                    }
                    case MaskViewModel mask:
                    {
                        productViewModel.Model = mask.Model;
                        break;
                    }
                    case FinViewModel fin:
                    {
                        productViewModel.Model = fin.Model;
                        productViewModel.Size = fin.Size;
                        break;
                    }
                }

                return View(productViewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Products));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(CreateUpdateProductViewModel productViewModel)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                ProductViewModel? product = await client.GetFromJsonAsync<ProductViewModel>($"api/products/{productViewModel.Id}");

                if (product == null)
                {
                    return RedirectToAction(nameof(Products));
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.Action = "CreateProduct";
                    return View(productViewModel);
                }

                if (productViewModel.CategoryId == 0)
                {
                    ViewBag.Action = "CreateProduct";
                    ModelState.AddModelError(nameof(AdminProductViewModel.CategoryId), "Vælg venligst en kategori.");
                    return View(productViewModel);
                }

                if (productViewModel.CategoryId != product.Category?.Id)
                {
                    ViewBag.Action = "EditProduct";
                    ModelState.AddModelError(nameof(AdminProductViewModel.CategoryId), "Kategori må ikke ændres ved ændring.");
                    return View(productViewModel);
                }

                if (productViewModel.Price < 0 || productViewModel.Quantity < 0)
                {
                    string propertyName = productViewModel.Price < 0 ? nameof(AdminProductViewModel.Price) : nameof(AdminProductViewModel.Quantity);
                    ModelState.AddModelError(propertyName, "Det kan ikke være negativ.");
                }

                ProductViewModel? validatedProduct = ValidateProduct(productViewModel);
                if (validatedProduct == null)
                {
                    ViewBag.Action = "CreateProduct";
                    return View(productViewModel);
                }

                validatedProduct.Description = productViewModel.Description ?? string.Empty;
                if (productViewModel.Image != null && productViewModel.Image.Length > 0)
                {
                    await using MemoryStream memoryStream = new MemoryStream();
                    await productViewModel.Image.CopyToAsync(memoryStream);
                    validatedProduct.Image = memoryStream.ToArray();
                }
                else
                {
                    validatedProduct.Image = product.Image;
                }

                ProductVariantViewModel variant = validatedProduct.Variants!.First();

                await client.PatchAsJsonAsync($"api/products/{productViewModel.Id}", new
                {
                    Brand = validatedProduct.Brand,
                    Price = validatedProduct.Price,
                    Description = validatedProduct.Description,
                    Image = validatedProduct.Image,
                    Quantity = validatedProduct.Quantity,
                    CategoryId = productViewModel.CategoryId,
                    Variant = variant
                });

                return RedirectToAction(nameof(Products));
            }
            catch
            {
                return View(productViewModel);
            }
        }

        private ProductViewModel? ValidateProduct(CreateUpdateProductViewModel productViewModel)
        {
            // key = categoryId, value = list of required properties for that category
            Dictionary<int, List<string>> requiredPropertiesByCategory = new Dictionary<int, List<string>>
            {
                { 1, new List<string> { "Model", "Size" } },
                { 2, new List<string> { "Model", "Type", "Gender", "Thickness", "Size" } },
                { 3, new List<string> { "Volume" } },
                { 4, new List<string> { "FirstStage", "SecondStage", "Octopus" } },
                { 5, new List<string> { "Model" } },
                { 6, new List<string> { "Model", "Size" } }
            };

            if (!requiredPropertiesByCategory.TryGetValue(productViewModel.CategoryId, out List<string>? requiredProperties))
            {
                return null;
            }

            foreach (string propertyName in requiredProperties)
            {
                var value = productViewModel
                    .GetType()
                    .GetProperty(propertyName)?
                    .GetValue(productViewModel);

                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    ModelState.AddModelError(propertyName, $"Dette felt er påkrævet for denne kategori.");
                }
            }

            if (!ModelState.IsValid)
            {
                return null;
            }

            ProductViewModel product = new ProductViewModel()
            {
                Brand = productViewModel.Brand,
                Price = productViewModel.Price,
                Description = productViewModel.Description ?? string.Empty,
                Quantity = productViewModel.Quantity,
                Variants = new List<ProductVariantViewModel>()
            };

            switch (productViewModel.CategoryId)
            {
                case 1:
                {
                    product.Variants.Add(new BCDViewModel()
                    {
                        Model = productViewModel.Model!,
                        Size = productViewModel.Size!
                    });

                    break;
                }
                case 2:
                {
                    product.Variants.Add(new SuitViewModel()
                    {
                        Model = productViewModel.Model!,
                        Type = productViewModel.Type!,
                        Size = productViewModel.Size!,
                        Gender = productViewModel.Gender!,
                        Thickness = productViewModel.Thickness!
                    });

                    break;
                }
                case 3:
                {
                    product.Variants.Add(new TankViewModel()
                    {
                        Volume = (int)productViewModel.Volume!
                    });

                    break;
                }
                case 4:
                {
                    product.Variants.Add(new RegulatorViewModel()
                    {
                        FirstStage = productViewModel.FirstStage!,
                        SecondStage = productViewModel.SecondStage!,
                        Octopus = productViewModel.Octopus!
                    });

                    break;
                }
                case 5:
                {
                    product.Variants.Add(new MaskViewModel()
                    {
                        Model = productViewModel.Model!
                    });

                    break;
                }
                case 6:
                {
                    product.Variants.Add(new FinViewModel()
                    {
                        Model = productViewModel.Model!,
                        Size = productViewModel.Size!
                    });

                    break;
                }
            }

            return product;
        }

        public async Task<IActionResult> DeleteProductVariant(int variantId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                await client.DeleteAsync($"api/products/{variantId}");
                return RedirectToAction(nameof(Products));
            }
            catch
            {
                return RedirectToAction(nameof(Products));
            }
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                ProductViewModel? product = await client.GetFromJsonAsync<ProductViewModel>($"api/products/{productId}");
                if (product == null)
                {
                    return RedirectToAction(nameof(Products));
                }

                List<int> ids = product.Variants
                    .Select(x => x.Id)
                    .ToList();

                foreach (int id in ids)
                {
                    await client.DeleteAsync($"api/products/{id}");
                }

                return RedirectToAction(nameof(Products));
            }
            catch
            {
                return RedirectToAction(nameof(Products));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Bookings()
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<BookingViewModel> bookings = await client.GetFromJsonAsync<List<BookingViewModel>>("api/admin/bookings");
                return View(bookings);
            }
            catch
            {
                return View(new List<BookingViewModel>());
            }
        }

        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                await client.DeleteAsync($"api/bookings/{bookingId}");
                return RedirectToAction(nameof(Bookings));
            }
            catch
            {
                return RedirectToAction(nameof(Bookings));
            }
        }

        public async Task<IActionResult> EditBooking(int bookingId)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                BookingViewModel? booking = await client.GetFromJsonAsync<BookingViewModel?>($"api/bookings/{bookingId}");
                if (booking == null)
                {
                    return RedirectToAction(nameof(Bookings));
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
                return RedirectToAction(nameof(Bookings));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditBooking(int bookingId, EditBookingViewModel booking)
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

                return RedirectToAction(nameof(Bookings));
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
