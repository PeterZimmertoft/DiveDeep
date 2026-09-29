using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;
        private readonly IBookingRepository bookingRepository;
        private readonly ICartService cartService;

        public AdminController(ICategoryRepository categoryRepository, IProductService productService, IBookingRepository bookingRepository, ICartService cartService)
        {
            this.categoryRepository = categoryRepository;
            this.productService = productService;
            this.bookingRepository = bookingRepository;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<ProductsViewModel> productsVM = new List<ProductsViewModel>();
            List<Category> categories = categoryRepository.GetAll();
            categories.ForEach(category =>
            {
                ProductsViewModel productsViewModel = productService.GetByCategoryId(category.Id);
                productsVM.Add(productsViewModel); 
            });

            return View(productsVM);
        }

        public IActionResult CreateProduct()
        {
            ViewBag.Action = "CreateProduct";
            AdminProductViewModel adminProductVm = new AdminProductViewModel();

            return View(adminProductVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AdminProductViewModel adminProductVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = "CreateProduct";
                return View(adminProductVm);
            }

            if (adminProductVm.CategoryId == 0)
            {
                ViewBag.Action = "CreateProduct";
                ModelState.AddModelError(nameof(AdminProductViewModel.CategoryId), "Vælg venligst en kategori.");
                return View(adminProductVm);
            }

            if (adminProductVm.Price < 0 || adminProductVm.Quantity < 0)
            {
                string propertyName = adminProductVm.Price < 0 ? nameof(AdminProductViewModel.Price) : nameof(AdminProductViewModel.Quantity);
                ModelState.AddModelError(propertyName, "Det kan ikke være negativ.");
            }

            Product? product = ValidateProduct(adminProductVm);
            if (product == null)
            {
                ViewBag.Action = "CreateProduct";
                return View(adminProductVm);
            }

            product.Description = adminProductVm.Description ?? string.Empty;
            if (adminProductVm.Image != null && adminProductVm.Image.Length > 0)
            {
                await using MemoryStream memoryStream = new MemoryStream();
                await adminProductVm.Image.CopyToAsync(memoryStream);
                product.Image = memoryStream.ToArray();
            }
            else
            {
                product.Image = new byte[] {};
            }

            productService.Create(product);
            return RedirectToAction(nameof(Products));
        }

        public IActionResult EditProduct(int productId)
        {
            ViewBag.Action = "EditProduct";

            Product? product = this.productService.GetById(productId);
            if (product == null) return RedirectToAction(nameof(Products));

            MemoryStream memoryStream = new MemoryStream(product.Image);
            IFormFile image = new FormFile(memoryStream, 0, memoryStream.Length, "image", "image.png");

            AdminProductViewModel productViewModel = new AdminProductViewModel()
            {
                ProductId = product.Id,
                Brand = product.Brand,
                Price = product.Price,
                Description = product.Description,
                Image = image,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId
            };

            if (product is BCD bcd)
            {
                productViewModel.Model = bcd.Model;
                productViewModel.Size = bcd.Size;
            }
            else if (product is Suit suit)
            {
                productViewModel.Model = suit.Model;
                productViewModel.Type = suit.Type;
                productViewModel.Gender = suit.Gender;
                productViewModel.Size = suit.Size;
                productViewModel.Thickness =  suit.Thickness;
            }
            else if (product is Tank tank)
            {
                productViewModel.Volume = tank.Volume;
            }
            else if (product is Regulator regulator)
            {
                productViewModel.FirstStage = regulator.FirstStage;
                productViewModel.SecondStage = regulator.SecondStage;
                productViewModel.Octopus = regulator.Octopus;
            }
            else if (product is Mask mask)
            {
                productViewModel.Model = mask.Model;
            }
            else if (product is Fin fin)
            {
                productViewModel.Model = fin.Model;
                productViewModel.Size = fin.Size;
            }

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(AdminProductViewModel adminProductVm)
        {
            Product? product = productService.GetById(adminProductVm.ProductId);
            if (product == null)
            {
                ViewBag.Action = "EditProduct";
                return View(adminProductVm);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Action = "EditProduct";
                return View(adminProductVm);
            }

            if (adminProductVm.CategoryId == 0)
            {
                ViewBag.Action = "EditProduct";
                ModelState.AddModelError(nameof(AdminProductViewModel.CategoryId), "Vælg venligst en kategori.");
                return View(adminProductVm);
            }

            if (adminProductVm.CategoryId != product.CategoryId)
            {
                ViewBag.Action = "EditProduct";
                ModelState.AddModelError(nameof(AdminProductViewModel.CategoryId), "Kategori må ikke ændres ved ændring.");
                return View(adminProductVm);
            }

            if (adminProductVm.Price < 0 || adminProductVm.Quantity < 0)
            {
                string propertyName = adminProductVm.Price < 0 ? nameof(AdminProductViewModel.Price) : nameof(AdminProductViewModel.Quantity);
                ModelState.AddModelError(propertyName, "Det kan ikke være negativ.");
            }

            Product? newProduct = ValidateProduct(adminProductVm);
            if (newProduct == null)
            {
                ViewBag.Action = "EditProduct";
                return View(adminProductVm);
            }

            newProduct.Id = product.Id;
            newProduct.Description = adminProductVm.Description ?? string.Empty;
            if (adminProductVm.Image != null && adminProductVm.Image.Length > 0)
            {
                await using MemoryStream memoryStream = new MemoryStream();
                await adminProductVm.Image.CopyToAsync(memoryStream);
                newProduct.Image = memoryStream.ToArray();
            }
            else
            {
                newProduct.Image = product.Image;
            }

            productService.Update(newProduct);
            return RedirectToAction(nameof(Products));
        }

        private Product? ValidateProduct(AdminProductViewModel adminProductVm)
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

            if (!requiredPropertiesByCategory.TryGetValue(adminProductVm.CategoryId, out List<string>? requiredProperties))
            {
                return null;
            }

            foreach (string propertyName in requiredProperties)
            {
                var value = adminProductVm.GetType().GetProperty(propertyName)?.GetValue(adminProductVm);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    ModelState.AddModelError(propertyName, $"Dette felt er påkrævet for denne kategori.");
                }
            }

            if (!ModelState.IsValid)
            {
                return null;
            }

            switch (adminProductVm.CategoryId)
            {
                case 1:
                    return new BCD
                    {
                        Brand = adminProductVm.Brand,
                        Price = adminProductVm.Price,
                        Description = adminProductVm.Description,
                        Quantity = adminProductVm.Quantity,
                        CategoryId = adminProductVm.CategoryId,
                        Model = adminProductVm.Model!,
                        Size = adminProductVm.Size!
                    };
                case 2:
                    return new Suit
                    {
                        Brand = adminProductVm.Brand,
                        Price = adminProductVm.Price,
                        Description = adminProductVm.Description,
                        Quantity = adminProductVm.Quantity,
                        CategoryId = adminProductVm.CategoryId,
                        Model = adminProductVm.Model!,
                        Type = adminProductVm.Type!,
                        Gender = adminProductVm.Gender!,
                        Thickness = adminProductVm.Thickness!,
                        Size = adminProductVm.Size!
                    };
                case 3:
                    return new Tank
                    {
                        Brand = adminProductVm.Brand,
                        Price = adminProductVm.Price,
                        Description = adminProductVm.Description,
                        Quantity = adminProductVm.Quantity,
                        CategoryId = adminProductVm.CategoryId,
                        Volume = (int)adminProductVm.Volume!
                    };
                case 4:
                    return new Regulator
                    {
                        Brand = adminProductVm.Brand,
                        Price = adminProductVm.Price,
                        Description = adminProductVm.Description,
                        Quantity = adminProductVm.Quantity,
                        CategoryId = adminProductVm.CategoryId,
                        FirstStage = adminProductVm.FirstStage!,
                        SecondStage = adminProductVm.SecondStage!,
                        Octopus = adminProductVm.Octopus!
                    };
                case 5:
                    return new Mask
                    {
                        Brand = adminProductVm.Brand,
                        Price = adminProductVm.Price,
                        Description = adminProductVm.Description,
                        Quantity = adminProductVm.Quantity,
                        CategoryId = adminProductVm.CategoryId,
                        Model = adminProductVm.Model!
                    };
                case 6:
                    return new Fin
                    {
                        Brand = adminProductVm.Brand,
                        Price = adminProductVm.Price,
                        Description = adminProductVm.Description,
                        Quantity = adminProductVm.Quantity,
                        CategoryId = adminProductVm.CategoryId,
                        Model = adminProductVm.Model!,
                        Size = adminProductVm.Size!
                    };
            }

            return null;    
        }

        public IActionResult DeleteProductVariant(int productId)
        {
            cartService.DeleteByProductId(productId);
            productService.Delete(productId);

            return RedirectToAction(nameof(Products));
        }

        public IActionResult DeleteProduct(int productId)
        {
            Product? product = productService.GetById(productId);
            if (product != null)
            {
                List<Product> variants = productService.GetAllByName(product.Name);
                List<int> variantIds =  variants.Select(v => v.Id).ToList();

                cartService.DeleteByProductId(variantIds);
                productService.Delete(variantIds);
            }

            return RedirectToAction(nameof(Products));
        }

        public IActionResult Bookings()
        {
            List<Booking> bookings = bookingRepository.GetAll(); 
            return View(bookings);
        }

        public IActionResult DeleteBooking(int bookingId)
        {
            bookingRepository.Delete(bookingId);
            return RedirectToAction(nameof(Bookings)); 
        }

        public IActionResult EditBooking(int bookingId)
        {
            Booking? booking = bookingRepository.GetById(bookingId);
            if (booking == null) return View();

            BookingEditViewModel bookingVM = new BookingEditViewModel(booking);
            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult EditBooking(BookingEditViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookingVM);
            }

            DateTime startDate = (DateTime)bookingVM.StartDate!;
            DateTime endDate = (DateTime)bookingVM.EndDate!;

            if (DateTime.Today > startDate)
            {
                ModelState.AddModelError(nameof(BookingEditViewModel.ErrorMessage), "Startdatoen må ikke være i fortiden.");
                return View(bookingVM);
            }

            if (startDate > endDate)
            {
                ModelState.AddModelError(nameof(BookingEditViewModel.ErrorMessage), "Startdatoen må ikke være efter slutdatoen.");
                return View(bookingVM);
            }

            try
            {
                bookingRepository.Update(bookingVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(BookingEditViewModel.ErrorMessage), "Denne booking er blevet ændret af en anden");
                return View(bookingVM);
            }
            
            return RedirectToAction(nameof(Bookings));
        }
    }
}
