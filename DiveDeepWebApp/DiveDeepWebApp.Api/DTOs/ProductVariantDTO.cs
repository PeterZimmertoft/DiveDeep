using System.Text.Json.Serialization;
using DiveDeepWebApp.Api.DTOs.Variants;

namespace DiveDeepWebApp.Api.DTOs
{
    [JsonDerivedType(typeof(BcdDTO))]
    [JsonDerivedType(typeof(SuitDTO))]
    [JsonDerivedType(typeof(RegulatorDTO))]
    [JsonDerivedType(typeof(TankDTO))]
    [JsonDerivedType(typeof(MaskDTO))]
    [JsonDerivedType(typeof(FinDTO))]
    public class ProductVariantDTO
    {
        public int Id { get; set; }
    }
}
