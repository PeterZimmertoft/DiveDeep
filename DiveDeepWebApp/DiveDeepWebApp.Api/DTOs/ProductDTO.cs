namespace DiveDeepWebApp.Api.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public int Quantity { get; set; }
        public CategoryDTO? Category { get; set; }
        public List<ProductVariantDTO>? Variants { get; set; }
    }
}
