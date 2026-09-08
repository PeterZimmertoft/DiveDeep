using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

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

        public int PackageId { get; set; }

        [ValidateNever]
        [BindNever]
        public Package Package { get; set; }

        public BCD? BCD { get; set; }

        public Fin? Fin {  get; set; }

        public Mask? Mask { get; set; }

        public Regulator? Regulator { get; set; }

        public Suit? Suit { get; set; }

        public Tank? Tank { get; set; }

        public IList<PackageProduct> PackageProducts { get; set; }

    }

}
