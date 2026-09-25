using DiveDeepWebApp.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepWebApp.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public double Price { get; set; }

        [ValidateNever]
        [Required]
        public List<BookingProduct> BookingProducts { get; set; }

        [Required]
        [ValidateNever]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [ValidateNever]
        [BindNever]
        public ApplicationUser User { get; set; }
    }
}
