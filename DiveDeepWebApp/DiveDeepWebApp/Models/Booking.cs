namespace DiveDeepWebApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Product> Products { get; set; }
    }
}
