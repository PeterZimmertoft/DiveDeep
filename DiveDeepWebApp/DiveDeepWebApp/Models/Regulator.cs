using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Regulator : Product
    {
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public string FirstStage { get; set; } = string.Empty;
        
        [Required]
        public string SecondStage { get; set; } = string.Empty;

        [Required] 
        public string Octopus {  get; set; } = string.Empty;
    }
}
