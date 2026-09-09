using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IProductRepository
    {
        List<Product> GetByCategoryId(int categoryId);
    }
}
