using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public byte[] Image { get; set; }

        public List<Product> Products { get; set; }
    }
}
