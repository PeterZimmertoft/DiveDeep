using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
