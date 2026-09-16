using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.ViewModels
{
    public class PackageProductViewModel
    {
        [ValidateNever]
        public List<Product> Variants { get; set; }

        [ValidateNever]
        public string? BookingError { get; set; }

        public string ProductName { get; set; }

        [Required(ErrorMessage = "Der skal vælges en størrelse!")]
        public string? Size { get; set; }

        [Required(ErrorMessage = "Der skal vælges en tykkelse!")]
        public string? Thickness { get; set; }

        [Required(ErrorMessage = "Der skal vælges et køn!")]
        public string? Gender { get; set; }
    }
}
