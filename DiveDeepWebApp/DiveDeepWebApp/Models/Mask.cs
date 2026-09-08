using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Mask : Product
    {
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public string Model { get; set; } = string.Empty;
    }
}
