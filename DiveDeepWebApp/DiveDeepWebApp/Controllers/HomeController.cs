using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiveDeepWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Package> packages = PackageRepo.GetAll();
            return View(packages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
