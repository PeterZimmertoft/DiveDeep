using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.DTOs
{
    public class ProductDTO
    {
        public string Brand { get; set; } = string.Empty;
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public List<ProductVariantDTO>? Variants { get; set; }
    }
}
