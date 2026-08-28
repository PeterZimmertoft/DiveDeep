using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
