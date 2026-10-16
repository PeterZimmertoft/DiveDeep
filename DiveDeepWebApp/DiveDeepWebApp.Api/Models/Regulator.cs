using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.Models
{
    public class Regulator : Product
    {
        public override string Name
        {
            get => $"{FirstStage} / {SecondStage}";
            set;
        }

        [Required]
        public string FirstStage { get; set; } = string.Empty;
        
        [Required]
        public string SecondStage { get; set; } = string.Empty;

        [Required] 
        public string Octopus {  get; set; } = string.Empty;
    }
}
