using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product?> GetByIdAsync(int productId);
        Task<ProductDTO?> GetProductDTOAsync(int productId);
        Task<List<Product>> GetAllByNameAsync(string name);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int productId);
        Task DeleteAsync(List<int> productIds);
    }
}
