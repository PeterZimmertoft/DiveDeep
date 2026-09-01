using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;

namespace DiveDeepWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = CategoryRepo.GetAll();
            return View(categories);
        }
    }
}
