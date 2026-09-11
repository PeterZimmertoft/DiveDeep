using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Fin : Product
    {
        public override string Name
        {
            get => Model;
            set;
        }

        [Required]
        public string Model { get; set; } = string.Empty;
        
        [Required]
        public string Size { get; set; } = string.Empty;

        public override bool MatchesOptions(string? size, string? thickness, string? gender)
        {
            return Size == size;
        }
    }
}
