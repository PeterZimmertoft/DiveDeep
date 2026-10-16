using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Mappers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;

namespace DiveDeepWebApp.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICartService cartService;

        public ProductService(IProductRepository productRepository, ICartService cartService)
        {
            this.productRepository = productRepository;
            this.cartService = cartService;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            List<Product> products = await productRepository.GetAllAsync();
            List<Product> uniqueProducts = products
                .DistinctBy(x => x.Name)
                .ToList();

            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (Product product in uniqueProducts)
            {
                List<Product> productsByName = products
                    .Where(p => p.Name == product.Name)
                    .ToList();

                List<ProductVariantDTO> variants = productsByName
                    .Select(p => p.ToVariantDTO())
                    .ToList();

                ProductDTO productDTO = product.ToDTO();
                productDTO.Variants = variants;

                productDTOs.Add(productDTO);
            }

            return productDTOs;
        }

        public async Task<ProductDTO?> GetByIdAsync(int productId)
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

        public async Task CreateAsync(CreateProductDTO productDTO)
        {
            Product product = productDTO.ToModel();
            await productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(int productId, UpdateProductDTO productDTO)
        {
            Product product = productDTO.ToModel();
            product.Id = productId;

            Console.WriteLine($"Updating product with ID: {productId}");
            Console.WriteLine($"Product details: Brand={product.Brand} Name={product.Name}, Description={product.Description}, Price={product.Price}, CategoryId={product.CategoryId}, Image={product.Image}");
            await productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int productId)
        {
            await cartService.DeleteByProductIdAsync(productId);
            await productRepository.DeleteAsync(productId);
        }
    }
}
