using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IProductRepository
    {
        List<Product> GetByCategoryId(int categoryId);
        Product? GetById(int productId);
        List<Product> GetAllByName(string name);
    }
}
