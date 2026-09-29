using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IProductService
    {
        Product? GetById(int productId);
        ProductsViewModel GetByCategoryId(int categoryId);
        ProductViewModel GetProductViewModel(int productId);
        List<Product> GetAllByName(string name);
        void Create(Product product);
        void Update(Product product);
        void Delete(int productId);
        void Delete(List<int> productIds);
    }
}
