using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IProductService
    {
        ProductsViewModel GetByCategoryId(int categoryId);
        ProductViewModel GetProductViewModel(int productId);
    }
}
