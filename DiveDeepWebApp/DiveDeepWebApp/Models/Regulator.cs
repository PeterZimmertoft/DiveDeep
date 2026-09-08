using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Regulator : Product
    {
        [Required]
        public string FirstStage { get; set; } = string.Empty;
        
        [Required]
        public string SecondStage { get; set; } = string.Empty;

        [Required] 
        public string Octopus {  get; set; } = string.Empty;
    }
}
