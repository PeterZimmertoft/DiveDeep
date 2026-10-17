namespace DiveDeepWebApp.ViewModels.Variants
{
    public class SuitViewModel : ProductVariantViewModel
    {
        public string Model { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Gender { get; set; }
        public string? Thickness { get; set; }

        public override bool MatchesOptions(string? size, string? thickness, string? gender)
        {
            return Size == size && Thickness == thickness && Gender == gender;
        }
    }
}