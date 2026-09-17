using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.ViewModels
{
    public class PackageViewModel
    {
        [ValidateNever]
        public int Id { get; set; }

        [ValidateNever]
        public string Name { get; set; }

        [ValidateNever]
        public byte[] Image { get; set; }

        [ValidateNever]
        public string Description { get; set; }
        
        public List<PackageProductViewModel> packageProductsVM { get; set; }

        [ValidateNever]
        public string? BookingError { get; set; }

        [Required(ErrorMessage = "Der skal vælges en startdato!")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Der skal vælges en slutdato!")]
        public DateTime? EndDate { get; set; }
    }
}
