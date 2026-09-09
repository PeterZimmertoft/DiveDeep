using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.ViewModels
{
    public class ProductsViewModel
    {
        public string CategoryName { get; set; }
        public Dictionary<string, List<Product>> ProductsByName { get; set; }
    }
}
