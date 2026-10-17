using DiveDeepWebApp.ViewModels;
using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiveDeepWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                List<PackageViewModel> packages = await client.GetFromJsonAsync<List<PackageViewModel>>("api/packages");
                return View(packages);
            }
            catch
            {
                return View(new List<PackageViewModel>());
            }
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
