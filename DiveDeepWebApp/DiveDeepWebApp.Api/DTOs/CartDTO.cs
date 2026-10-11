using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.DTOs
{
    public class CartDTO
    {
        [ValidateNever]
        public List<CartItemDTO> Items { get; set; }

        [ValidateNever]
        public string? ErrorMessage { get; set; }

        [Required(ErrorMessage = "Der skal vælges en startdato!")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Der skal vælges en slutdato!")]
        public DateTime? EndDate { get; set; }
    }
}
