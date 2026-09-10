using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Tank : Product
    {
        public override string Name
        {
            get => $"{Volume}L tank";
            set;
        }

        [Required]
        public int Volume { get; set; }
    }
}
