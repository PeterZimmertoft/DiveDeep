using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public ProductViewModel GetProductViewModel(int productId)
        {

            Product? product = productRepository.GetById(productId);
            if (product == null) return new ProductViewModel
            {
                Variants = new List<Product>()
            };

            List<Product> products = productRepository.GetAllByName(product.Name);
            return new ProductViewModel
            {
                Variants = products
            };

        }

        
    }
}
