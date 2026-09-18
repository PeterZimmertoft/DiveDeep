using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.ViewModels
{
    public class CartItemViewModel
    {
        public List<CartItem> Products { get; set; }
        public Package? Package { get; set; }

        [ValidateNever]
        public string? ErrorMessage { get; set; }
    }
}
