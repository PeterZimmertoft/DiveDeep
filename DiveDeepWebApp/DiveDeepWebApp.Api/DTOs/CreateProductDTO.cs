namespace DiveDeepWebApp.Api.DTOs
{
    public class CreateProductDTO
    {
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public ProductVariantDTO? Variant { get; set; }
    }
}