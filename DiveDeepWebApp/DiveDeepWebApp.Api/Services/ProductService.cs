using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Helpers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;

namespace DiveDeepWebApp.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllByNameAsync(string name)
        {
            return await productRepository.GetAllByNameAsync(name);
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await productRepository.GetByIdAsync(productId);
        }

        public async Task<ProductDTO?> GetProductDTOAsync(int productId)
        {
            return null;

            // Product? product = await productRepository.GetByIdAsync(productId);
            // if (product == null) return;
            //
            // List<Product> products = await productRepository.GetAllByNameAsync(product.Name);
            // List<ProductVariantDTO> productVariantDTOs = products
            //     .Select(p => new ProductVariantDTO
            //     {
            //         Id = p.Id,
            //         Size = ConvertProductToProductVariantDTO.Size(p),
            //         Thicikness = ConvertProductToProductVariantDTO.Thickness(p),
            //         Gender = ConvertProductToProductVariantDTO.Gender(p)
            //
            //     })
            //     .ToList();
            //
            //     return new ProductDTO
            //     {
            //         Brand = product.Brand,
            //         Name = product.Name,
            //         Price = product.Price,
            //         Description = product.Description,
            //         Image = product.Image.Length > 0 ? product.Image : products.First().Category.Image,
            //         Variants = productVariantDTOs
            // };
        }

        public async Task CreateAsync(Product product)
        {
            await productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int productId)
        {
            await productRepository.DeleteAsync(productId);
        }

        public async Task DeleteAsync(List<int> productIds)
        {
            await productRepository.DeleteAsync(productIds);
        }
    }
}
