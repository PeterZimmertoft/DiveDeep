using DiveDeepWebApp.ViewModels;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DiveDeepWebApp.Services;

namespace DiveDeepWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IProductService productService;
        private readonly IBookingRepository bookingRepository;

        public HomeController(IPackageService packageService, IProductService productService, IBookingRepository bookingRepository)
        {
            this.packageService = packageService;
            this.productService = productService;
            this.bookingRepository = bookingRepository;
        }

        public IActionResult Index()
        {
            List<Package> packages = packageService.GetAll();
            return View(packages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Package(int packageId)
        {
            PackageViewModel packageVM = packageService.GetPackageViewModel(packageId);
            return View(packageVM);
        }

        [HttpPost]
        public IActionResult Package(PackageViewModel packageVM)
        {
            Package? package = packageService.GetById(packageVM.Id);
            if (package == null) return View(packageVM);

            packageVM.Image = package.Image;
            packageVM.packageProductsVM.ForEach(productVM =>
            {
                List<Product> variants = productService.GetAllByName(productVM.ProductName);
                productVM.Variants = variants;
            });

            if (!ModelState.IsValid) return View(packageVM);

            if (DateTime.Today > packageVM.StartDate)
            {
                ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Startdatoen skal ligge i fremtiden!");
                return View(packageVM);
            }

            if (packageVM.StartDate > packageVM.EndDate)
            {
                ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Slutdato skal være efter startdato!");
                return View(packageVM);
            }

            DateTime startDate = (DateTime)packageVM.StartDate;
            DateTime endDate = (DateTime)packageVM.EndDate;

            for (int index = 0; index < packageVM.packageProductsVM.Count; index++)
            {
                PackageProductViewModel packageProductVM = packageVM.packageProductsVM[index];
                Product? variant = packageProductVM.Variants.Find(p => p.MatchesOptions(packageProductVM.Size, packageProductVM.Thickness, packageProductVM.Gender));
                if (packageProductVM.Variants.Count == 1 && variant == null)
                {
                    variant = packageProductVM.Variants.First();
                }

                if (variant == null)
                {
                    ModelState.AddModelError(nameof(ProductViewModel.BookingError), "Der opstod en fejl!");
                    return View(packageVM);
                }

                if (bookingRepository.HasOverlappingBooking(variant.Id, startDate, endDate))
                {
                    ModelState.AddModelError(nameof(PackageViewModel.BookingError), "En af de valgte produkter i pakke, er allerede udlejet i denne periode!");
                    ModelState.AddModelError($"packageProductsVM[{index}].BookingError", "Produktet er allerede udlejet i denne periode!");

                    return View(packageVM);
                }
            }

            return View(packageVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
