using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.Api.DTOs
{
    public class CartItemDTO
    {
        public List<CartItem> Products { get; set; }
        public Package? Package { get; set; }

        [ValidateNever]
        public string? ErrorMessage { get; set; }
    }
}
