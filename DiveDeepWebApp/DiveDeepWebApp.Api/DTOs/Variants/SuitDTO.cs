namespace DiveDeepWebApp.Api.DTOs.Variants
{
    public class SuitDTO : ProductVariantDTO
    {
        public string Model { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string? Thickness { get; set; } = string.Empty;
    }
}
