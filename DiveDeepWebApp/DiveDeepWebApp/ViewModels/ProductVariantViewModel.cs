using System.Text.Json.Serialization;
using DiveDeepWebApp.ViewModels.Variants;

namespace DiveDeepWebApp.ViewModels
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "categoryId")]
    [JsonDerivedType(typeof(BCDViewModel), 1)]
    [JsonDerivedType(typeof(SuitViewModel), 2)]
    [JsonDerivedType(typeof(TankViewModel), 3)]
    [JsonDerivedType(typeof(RegulatorViewModel), 4)]
    [JsonDerivedType(typeof(MaskViewModel), 5)]
    [JsonDerivedType(typeof(FinViewModel), 6)]
    public class ProductVariantViewModel
    {
        public int Id { get; set; }

        public virtual bool MatchesOptions(string? size, string? thickness, string? gender)
        {
            return false;
        }
    }
}