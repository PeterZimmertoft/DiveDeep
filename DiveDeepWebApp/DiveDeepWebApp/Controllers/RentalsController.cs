using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
