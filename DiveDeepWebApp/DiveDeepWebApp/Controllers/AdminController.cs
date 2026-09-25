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

        public AdminController(ICategoryRepository categoryRepository, IProductService productService, IBookingRepository bookingRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productService = productService;
            this.bookingRepository = bookingRepository;
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
            ProductCreateViewModel productVM = new ProductCreateViewModel();
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            if (productVM.CategoryId == 0)
            {
                ModelState.AddModelError(nameof(ProductCreateViewModel.CategoryId), "Vælg venligst en kategori.");
                return View(productVM);
            }

            if (productVM.Price < 0 || productVM.Quantity < 0)
            {
                string propertyName = productVM.Price < 0 ? nameof(ProductCreateViewModel.Price) : nameof(ProductCreateViewModel.Quantity);
                ModelState.AddModelError(propertyName, "Det kan ikke være negativ.");
            }

            Product? product = ValidateProduct(productVM);
            if (product == null)
            {
                return View(productVM);
            }

            product.Description = productVM.Description ?? string.Empty; 
            if (productVM.Image != null && productVM.Image.Length > 0)
            {
                await using MemoryStream memoryStream = new MemoryStream();
                await productVM.Image.CopyToAsync(memoryStream);
                product.Image = memoryStream.ToArray();
            }
            else
            {
                product.Image = new byte[] {};
            }

            productService.Create(product);
            return RedirectToAction(nameof(Products));
        }

        private Product? ValidateProduct(ProductCreateViewModel productVM)
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
            
            if (!requiredPropertiesByCategory.TryGetValue(productVM.CategoryId, out List<string>? requiredProperties))
            {
                return null; 
            }

            foreach (string propertyName in requiredProperties)
            {
                var value = productVM.GetType().GetProperty(propertyName)?.GetValue(productVM);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    ModelState.AddModelError(propertyName, $"Dette felt er påkrævet for denne kategori.");
                }
            }

            if (!ModelState.IsValid)
            {
                return null; 
            }

            switch (productVM.CategoryId)
            {
                case 1:
                    return new BCD
                    {
                        Brand = productVM.Brand,
                        Price = productVM.Price,
                        Description = productVM.Description,
                        Quantity = productVM.Quantity,
                        CategoryId = productVM.CategoryId,
                        Model = productVM.Model!,
                        Size = productVM.Size!
                    };
                case 2:
                    return new Suit
                    {
                        Brand = productVM.Brand,
                        Price = productVM.Price,
                        Description = productVM.Description,
                        Quantity = productVM.Quantity,
                        CategoryId = productVM.CategoryId,
                        Model = productVM.Model!,
                        Type = productVM.Type!,
                        Gender = productVM.Gender!,
                        Thickness = productVM.Thickness!,
                        Size = productVM.Size!
                    };
                case 3:
                    return new Tank
                    {
                        Brand = productVM.Brand,
                        Price = productVM.Price,
                        Description = productVM.Description,
                        Quantity = productVM.Quantity,
                        CategoryId = productVM.CategoryId,
                        Volume = (int)productVM.Volume!
                    };
                case 4:
                    return new Regulator
                    {
                        Brand = productVM.Brand,
                        Price = productVM.Price,
                        Description = productVM.Description,
                        Quantity = productVM.Quantity,
                        CategoryId = productVM.CategoryId,
                        FirstStage = productVM.FirstStage!,
                        SecondStage = productVM.SecondStage!,
                        Octopus = productVM.Octopus!
                    };
                case 5:
                    return new Mask
                    {
                        Brand = productVM.Brand,
                        Price = productVM.Price,
                        Description = productVM.Description,
                        Quantity = productVM.Quantity,
                        CategoryId = productVM.CategoryId,
                        Model = productVM.Model!
                    };
                case 6:
                    return new Fin
                    {
                        Brand = productVM.Brand,
                        Price = productVM.Price,
                        Description = productVM.Description,
                        Quantity = productVM.Quantity,
                        CategoryId = productVM.CategoryId,
                        Model = productVM.Model!,
                        Size = productVM.Size!
                    };
            }

            return null;    
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

            bookingRepository.Update(bookingVM);
            return RedirectToAction(nameof(Bookings));
        }
    }
}
