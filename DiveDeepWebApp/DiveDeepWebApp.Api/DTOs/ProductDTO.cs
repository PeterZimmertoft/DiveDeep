using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.DTOs
{
    public class ProductDTO
    {
        public string Brand { get; set; } = string.Empty;

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public byte[] Image { get; set; }

        //public int Quantity { get; set; } = 5;

        public List<ProductVariantDTO> Variants { get; set; }


        //[Required(ErrorMessage = "Der skal vælges en størrelse!")]
        public string? Size { get; set; }

        //[Required(ErrorMessage = "Der skal vælges en tykkelse!")]
        public string? Thickness { get; set; }

        //[Required(ErrorMessage = "Der skal vælges et køn!")]
        public string? Gender { get; set; }
    }
}
