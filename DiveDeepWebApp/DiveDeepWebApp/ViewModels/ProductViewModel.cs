using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.ViewModels
{
    public class ProductViewModel : ProductSelectionViewModel
    {
        [Required(ErrorMessage = "Der skal vælges en startdato!")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Der skal vælges en slutdato!")]
        public DateTime? EndDate { get; set; }
    }
}
