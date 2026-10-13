using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> GetAllByNameAsync(string name);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int productId);
        Task DeleteAsync(List<int> productIds);
    }
}
