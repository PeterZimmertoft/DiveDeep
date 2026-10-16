using System.Text.Json.Serialization;
using DiveDeepWebApp.Api.DTOs.Variants;

namespace DiveDeepWebApp.Api.DTOs
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "categoryId")]
    [JsonDerivedType(typeof(BcdDTO), 1)]
    [JsonDerivedType(typeof(SuitDTO), 2)]
    [JsonDerivedType(typeof(TankDTO), 3)]
    [JsonDerivedType(typeof(RegulatorDTO), 4)]
    [JsonDerivedType(typeof(MaskDTO), 5)]
    [JsonDerivedType(typeof(FinDTO), 6)]
    public class ProductVariantDTO
    {
        public int Id { get; set; }
    }
}
