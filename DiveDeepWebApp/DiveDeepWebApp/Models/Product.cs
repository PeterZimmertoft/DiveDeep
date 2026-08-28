namespace DiveDeepWebApp.Models
{
    public abstract class Product
    {
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
