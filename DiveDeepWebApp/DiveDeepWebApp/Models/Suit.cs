using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Suit : Product
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

        [Required]
        public string Type {  get; set; } = string.Empty;

        [Required]
        public string Gender {  get; set; } = string.Empty;

        public string? Thickness { get; set; } = string.Empty;

        public override bool MatchesOptions(string? size, string? thickness, string? gender)
        {
            return Size == size && Thickness == thickness && Gender == gender;
        }
    }
}
