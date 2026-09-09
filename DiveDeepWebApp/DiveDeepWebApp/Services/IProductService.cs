using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IProductService
    {
        ProductsViewModel GetByCategoryId(int categoryId);
    }
}
