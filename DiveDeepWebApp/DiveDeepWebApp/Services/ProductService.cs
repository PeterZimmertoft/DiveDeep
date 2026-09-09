using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductsViewModel GetByCategoryId(int categoryId)
        {
            List<Product> products = productRepository.GetByCategoryId(categoryId);
            
            string category = products.FirstOrDefault()?.Category?.Name ?? "Produkter";
            Dictionary<string, List<Product>> productsByName = products
                .GroupBy(product => 
                {
                    if (product is Tank tank)
                    {
                        return $"{tank.Volume} liters tank";
                    } 
                    else if (product is Regulator regulator)
                    {
                        return $"{regulator.FirstStage} / {regulator.SecondStage}";
                    }

                    dynamic dynamicProduct = (dynamic)product;
                    string model = (string)dynamicProduct.Model;
                    return model;
                })
                .ToDictionary(group => group.Key, group => group.ToList());

            return new ProductsViewModel
            {
                CategoryName = category,
                ProductsByName = productsByName
            };
        }
    }
}
