using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
