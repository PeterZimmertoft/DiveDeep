namespace DiveDeepWebApp.Api.DTOs
{
    public class BcdDTO : ProductVariantDTO
    {
        public string Model { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;
    }
}