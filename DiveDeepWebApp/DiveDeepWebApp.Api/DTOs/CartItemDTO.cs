using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.Api.DTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public List<ProductDTO> Products { get; set; }
        public PackageDTO? Package { get; set; }
        public int Quantity { get; set; }
    }
}
