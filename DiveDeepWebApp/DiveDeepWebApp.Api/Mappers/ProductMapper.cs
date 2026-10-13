using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                Brand = product.Brand,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image
            };
        }
    }
}
