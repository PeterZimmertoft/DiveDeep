using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.DTOs
{
    public class ProductVariantDTO
    {
        public int Id { get; set; }

        public string? Size { get; set; }
        public string? Thicikness { get; set; }
        public string? Gender { get; set; }


    }
}
