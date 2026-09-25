using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IProductService
    {
        ProductsViewModel GetByCategoryId(int categoryId);
        ProductViewModel GetProductViewModel(int productId);
        List<Product> GetAllByName(string name);
        void Create(Product product);
    }
}
