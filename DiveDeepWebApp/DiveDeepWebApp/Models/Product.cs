namespace DiveDeepWebApp.Models
{
    public abstract class Product
    {
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Attribute> Attributes { get; set; }
    }
}
