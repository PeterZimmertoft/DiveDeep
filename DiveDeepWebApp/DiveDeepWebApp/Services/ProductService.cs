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
                .GroupBy(product => product.Name)
                .ToDictionary(group => group.Key, group => group.ToList());

            return new ProductsViewModel
            {
                CategoryName = category,
                ProductsByName = productsByName
            };
        }

        public Product? GetById(int productId)
        {
            return productRepository.GetById(productId);
        }

        public List<Product> GetAllByName(string name)
        {
            return productRepository.GetAllByName(name);
        }
    }
}
