using System.ComponentModel.DataAnnotations;
using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.ViewModels
{
    public class ProductCreateViewModel 
    {
        [Required(ErrorMessage = "Mærket er påkrævet.")]
        public string Brand { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Prisen er påkrævet.")]
        public double Price { get; set; }

        [MaxLength(500, ErrorMessage = "Beskrivelsen må maksimalt være 500 tegn.")]        
        
        [ValidateNever]
        public string Description { get; set; } = string.Empty;
        
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Lagerantal er påkrævet.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Kategorien er påkrævet.")]
        public int CategoryId { get; set; }

        public string? Model { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? Thickness { get; set; }
        public int? Volume { get; set; }
        public string? FirstStage { get; set; }
        public string? SecondStage { get; set; }
        public string? Octopus { get; set; }
    }
}
