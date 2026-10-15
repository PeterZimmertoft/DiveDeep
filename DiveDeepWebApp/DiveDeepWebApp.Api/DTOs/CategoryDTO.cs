namespace DiveDeepWebApp.Api.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public List<ProductDTO>? Products { get; set; }
    }
}
