namespace DiveDeepWebApp.Api.DTOs
{
    public class CategoryProductDTO
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string? SuitType { get; set; }
    }
}

