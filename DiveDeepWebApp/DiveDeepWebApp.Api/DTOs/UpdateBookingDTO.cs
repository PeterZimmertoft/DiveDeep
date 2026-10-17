namespace DiveDeepWebApp.Api.DTOs
{
    public class UpdateBookingDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}