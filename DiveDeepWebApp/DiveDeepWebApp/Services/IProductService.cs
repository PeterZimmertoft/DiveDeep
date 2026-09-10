using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IProductService
    {
        ProductsViewModel GetByCategoryId(int categoryId);
        Product? GetById(int productId);
        List<Product> GetAllByName(string name);
    }
}
