namespace DiveDeepWebApp.ViewModels.Variants
{
    public class TankViewModel : ProductVariantViewModel
    {
        public int Volume { get; set; }

        public override bool MatchesOptions(string size, string thickness, string gender)
        {
            return true;
        }
    }
}