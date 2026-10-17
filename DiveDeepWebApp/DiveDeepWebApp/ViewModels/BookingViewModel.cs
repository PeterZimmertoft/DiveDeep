using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public string BookedBy { get; set; }

        [ValidateNever]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}