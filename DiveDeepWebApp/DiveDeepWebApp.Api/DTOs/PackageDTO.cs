namespace DiveDeepWebApp.Api.DTOs
{
    public class PackageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public List<ProductDTO>? Products { get; set; }
    }
}
