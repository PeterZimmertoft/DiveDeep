using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;
        private readonly IBookingRepository bookingRepository;

        public ProductsController(ICategoryRepository categoryRepository, IProductService productService, IBookingRepository bookingRepository) 
        {
            this.categoryRepository = categoryRepository;
            this.productService = productService;
            this.bookingRepository = bookingRepository;
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

        [HttpPost]
        public IActionResult Product(ProductViewModel productVM)
        {
            List<Product> variants = productService.GetAllByName(productVM.ProductName);
            productVM.Variants = variants;

            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            if (DateTime.Today > productVM.StartDate)
            {
                ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Startdatoen skal ligge i fremtiden!");
                return View(productVM);
            }

            if (productVM.StartDate > productVM.EndDate)
            {
                ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Slutdato skal være efter startdato!");
                return View(productVM);
            }

            Product? variant = variants.Find(p => p.MatchesOptions(productVM.Size, productVM.Thickness, productVM.Gender));
            if (variants.Count == 1 && variant == null)
            {
                variant = variants.First();
            }

            if (variant == null)
            {
                ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Der opstod en fejl!");
                return View(productVM);
            }

            DateTime startDate = (DateTime)productVM.StartDate;
            DateTime endDate = (DateTime)productVM.EndDate;

            if (bookingRepository.HasOverlappingBooking(variant.Id, startDate, endDate))
            {
                ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Produktet er allerede udlejet i denne periode!");
                return View(productVM);
            }

            bookingRepository.Create(new Booking
            {
                StartDate = (DateTime)productVM.StartDate,
                EndDate = (DateTime)productVM.EndDate!,
                BookingProducts = new List<BookingProduct>
                {
                    new BookingProduct
                    {
                        ProductId = variant.Id
                    }
                }
            });

            TempData["BookingSuccess"] = true;
            TempData["BookingStart"] = startDate;
            TempData["BookingEnd"] = endDate;

            return RedirectToAction(
                nameof(Product),
                new {
                    categoryId = variant.CategoryId,
                    productId = variant.Id 
                }
            );
        }
        
        public IActionResult Package(string package)
        {
            List<ProductViewModel> productsVM = new List<ProductViewModel>();

            if (package == "DivingSet")
            {
                //productsVM.Add(productService.GetProductViewModel(13) );

                ViewBag.Action = "DivingSet";
            }
            else if (package == "SnorkelSet")
            {
                ViewBag.Action = "SnorkelSet";
            }

            return View();
        }
    }
}
