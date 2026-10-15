using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Helpers;
using DiveDeepWebApp.Api.Mappers;
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
            Product? product = await productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            List<Product> productsByName = await productRepository.GetAllByNameAsync(product.Name);
            List<ProductVariantDTO> variants = productsByName
                .Select(p => p.ToVariantDTO())
                .ToList();

            ProductDTO productDTO = product.ToDTO();
            productDTO.Variants = variants;

            return productDTO;
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
