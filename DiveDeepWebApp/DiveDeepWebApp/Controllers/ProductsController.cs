using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;

namespace DiveDeepWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductRepo.
            return View();
        }
    }
}
