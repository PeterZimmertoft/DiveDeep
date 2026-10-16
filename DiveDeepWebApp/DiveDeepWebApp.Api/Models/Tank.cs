using System.ComponentModel.DataAnnotations;

namespace DiveDeepWebApp.Api.Models
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
