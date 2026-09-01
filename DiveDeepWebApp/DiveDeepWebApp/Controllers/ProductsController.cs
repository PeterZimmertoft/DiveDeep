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

        public IActionResult Products(string category)
        {
            Dictionary<string, Type> map = new Dictionary<string, Type>
            {
                { "bcd", typeof(BCD) },
                { "suit", typeof(Suit) },
                { "tank", typeof(Tank) },
                { "regulator", typeof(Regulator) },
                { "mask", typeof(Mask) },
                { "fin", typeof(Fin) }
            };

            

            return View();
        }
    }
}
