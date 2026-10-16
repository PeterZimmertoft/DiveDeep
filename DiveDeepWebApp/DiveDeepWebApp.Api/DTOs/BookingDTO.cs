namespace DiveDeepWebApp.Api.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public List<ProductDTO> Products { get; set; }
        public string BookedBy { get; set; }
    }
}