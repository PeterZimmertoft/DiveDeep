namespace DiveDeepWebApp.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}