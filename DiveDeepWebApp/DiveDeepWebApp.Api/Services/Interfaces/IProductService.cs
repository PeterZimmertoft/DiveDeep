using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IProductService
    {
        Product? GetById(int productId);
        CategoryProductsDTO GetByCategoryId(int categoryId);
        ProductDTO GetProductDTO(int productId);
        List<Product> GetAllByName(string name);
        void Create(Product product);
        void Update(Product product);
        void Delete(int productId);
        void Delete(List<int> productIds);
    }
}
