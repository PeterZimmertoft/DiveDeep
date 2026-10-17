using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public CategoryViewModel? Category { get; set; }
        public List<ProductVariantViewModel>? Variants { get; set; }

        [Required(ErrorMessage = "Der skal vælges en størrelse!")]
        public string? Size { get; set; }

        [Required(ErrorMessage = "Der skal vælges en tykkelse!")]
        public string? Thickness { get; set; }

        [Required(ErrorMessage = "Der skal vælges et køn!")]
        public string? Gender { get; set; }
    }
}