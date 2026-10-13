using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.Api.DTOs
{
    public class PackageDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public List<ProductDTO> packageProductDTOs { get; set; }
        
    }
}
