namespace DiveDeepWebApp.Api.DTOs.Variants
{
    public class RegulatorDTO : ProductVariantDTO
    {
        public string FirstStage { get; set; } = string.Empty;

        public string SecondStage { get; set; } = string.Empty;

        public string Octopus { get; set; } = string.Empty;
    }
}
