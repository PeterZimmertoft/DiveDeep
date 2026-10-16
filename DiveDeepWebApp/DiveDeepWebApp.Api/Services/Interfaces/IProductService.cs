using DiveDeepWebApp.Api.DTOs;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(int productId);

        Task CreateAsync(CreateProductDTO productDTO);
        Task UpdateAsync(int productId, UpdateProductDTO productDTO);
        Task DeleteAsync(int productId);
    }
}
