namespace DiveDeepWebApp.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public PackageViewModel? Package { get; set; }
        public int Quantity { get; set; }
    }
}