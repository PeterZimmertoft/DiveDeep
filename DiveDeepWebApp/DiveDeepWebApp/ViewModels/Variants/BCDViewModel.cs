namespace DiveDeepWebApp.ViewModels.Variants
{
    public class BCDViewModel : ProductVariantViewModel
    {
        public string Model { get; set; }
        public string Size { get; set; }

        public override bool MatchesOptions(string? size, string? thickness, string? gender)
        {
            return Size == size;
        }
    }
}