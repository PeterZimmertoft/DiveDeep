using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Variants { get; set; }

        public string? Size { get; set; }
        public string? Thickness { get; set; }
        public string? Gender { get; set; }

    }
}
