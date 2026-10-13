using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.DTOs
{
    public class BcdDTO : ProductVariantDTO
    {
        public string Size { get; set; }
    }
}