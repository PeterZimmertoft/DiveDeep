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

        public List<Product> GetAllByName(string name)
        {
            return productRepository.GetAllByName(name);
        }

        public Product? GetById(int productId)
        {
            return productRepository.GetById(productId);
        }

        public CategoryProductsDTO GetByCategoryId(int categoryId)
        {
            List<Product> products = productRepository.GetByCategoryId(categoryId);

            string category = products.FirstOrDefault()?.Category?.Name ?? "Produkter";
            List<CategoryProductDTO> categoryProductDTOList = products
                .GroupBy(p => p.Name)
                .Select(g => g.First())
                .Select(p => new CategoryProductDTO
                {
                    Brand = p.Brand,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    SuitType = p is Suit suit ? suit.Type : null

                })
                .ToList();

            return new CategoryProductsDTO
            {
                CategoryName = category,
                CategoryProductDTOs = categoryProductDTOList
            };
        }


        public ProductDTO GetProductDTO(int productId)
        {
            Product? product = productRepository.GetById(productId);
            if (product == null) return new ProductDTO
            {
                VariantDTOs = new List<ProductVariantDTO>()
            };

            List<Product> products = productRepository.GetAllByName(product.Name);
            List<ProductVariantDTO> productVariantDTOs = products
                .Select(p => new ProductVariantDTO
                {
                    Id = p.Id,
                    Size = ConvertProductToProductVariantDTO.Size(p),
                    Thicikness = ConvertProductToProductVariantDTO.Thickness(p),
                    Gender = ConvertProductToProductVariantDTO.Gender(p)

                })
                .ToList();

                return new ProductDTO
                {
                    Brand = product.Brand,
                    ProductName = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Image = product.Image.Length > 0 ? product.Image : products.First().Category.Image,
                    VariantDTOs = productVariantDTOs
            };
        }

        public void Create(Product product)
        {
            productRepository.Create(product);
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        public void Delete(int productId)
        {
            productRepository.Delete(productId);
        }

        public void Delete(List<int> productIds)
        {
            productRepository.Delete(productIds);
        }
    }
}
