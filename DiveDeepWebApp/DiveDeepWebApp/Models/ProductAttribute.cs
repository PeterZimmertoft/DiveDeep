namespace DiveDeepWebApp.Models
{
    public class ProductAttribute
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Unit {  get; set; }
        public List<Value> Values { get; set; }
    }
}
