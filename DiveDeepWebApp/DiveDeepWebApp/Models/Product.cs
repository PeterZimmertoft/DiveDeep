using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

        //[Required]
        public abstract string Name { get; set; } 

        [Required]
        public double Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ValidateNever]
        [BindNever]
        public Category Category { get; set; }

        public List<BookingProduct> BookingProducts { get; set; }

        public virtual bool MatchesOptions(string? size, string? thickness, string? gender)
        {
            return false;
        }
    }
}
