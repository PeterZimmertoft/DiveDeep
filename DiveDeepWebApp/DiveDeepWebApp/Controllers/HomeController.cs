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
        public HomeController(IPackageService packageService)
        {
            this.packageService = packageService;
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




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
