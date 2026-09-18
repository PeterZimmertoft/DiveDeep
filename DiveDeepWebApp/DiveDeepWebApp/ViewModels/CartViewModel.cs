using System.ComponentModel.DataAnnotations;
using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.ViewModels
{
    public class CartViewModel
    {
        [ValidateNever]
        public List<CartItemViewModel> Items { get; set; }
        
        [ValidateNever]
        public string? ErrorMessage { get; set; }

        [Required(ErrorMessage = "Der skal vælges en startdato!")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Der skal vælges en slutdato!")]
        public DateTime? EndDate { get; set; }
    }
}
