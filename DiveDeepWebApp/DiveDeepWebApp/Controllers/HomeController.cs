using DiveDeepWebApp.ViewModels;
using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiveDeepWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Package> packages = new List<Package>();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
