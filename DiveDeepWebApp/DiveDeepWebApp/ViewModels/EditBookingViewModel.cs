using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.ViewModels
{
    public class EditBookingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Der skal vælges en startdato.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Der skal vælges en slutdato.")]
        public DateTime EndDate { get; set; }

        [ValidateNever]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ValidateNever]
        public string? ErrorMessage { get; set; }
    }
}