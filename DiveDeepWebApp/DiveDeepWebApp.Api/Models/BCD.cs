using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.Models
{
    public class BCD : Product
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
