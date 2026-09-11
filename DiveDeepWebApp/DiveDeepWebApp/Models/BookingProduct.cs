namespace DiveDeepWebApp.Models
{
    public class BookingProduct
    {
        public Booking Booking { get; set; }

        public Product Product { get; set; }

        public int BookingId { get; set; }
        public int ProductId { get; set; }
    }
}
