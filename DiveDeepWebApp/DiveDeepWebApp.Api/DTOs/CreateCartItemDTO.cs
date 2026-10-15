namespace DiveDeepWebApp.Api.DTOs
{
    public class CreateCartItemDTO
    {
        public int? PackageId { get; set; }
        public List<int> ProductIds { get; set; }
     }
}