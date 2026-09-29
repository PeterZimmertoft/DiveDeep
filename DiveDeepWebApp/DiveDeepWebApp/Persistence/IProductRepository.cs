using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IProductRepository
    {
        List<Product> GetByCategoryId(int categoryId);
        Product? GetById(int productId);
        List<Product> GetAllByName(string name);
        void Create(Product product);
        void Update(Product product);
        void Delete(int productId);
        void Delete(List<int> productIds);
    }
}
