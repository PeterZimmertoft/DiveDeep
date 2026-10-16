using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.Models
{
    public class Mask : Product
    {
        public override string Name
        {
            get => Model;
            set;
        }

        [Required]
        public string Model { get; set; } = string.Empty;
    }
}
