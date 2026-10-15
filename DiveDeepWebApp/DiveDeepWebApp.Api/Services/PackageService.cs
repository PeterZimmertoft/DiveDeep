using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Mappers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;

namespace DiveDeepWebApp.Api.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;
        private readonly IProductRepository productRepository;

        public PackageService(IPackageRepository packageRepository, IProductRepository productRepository)
        {
            this.packageRepository = packageRepository;
            this.productRepository = productRepository;
        }

        public async Task<List<PackageDTO>> GetAllAsync()
        {
            List<Package> packages = await packageRepository.GetAllAsync();
            List<PackageDTO> packageDTOs = packages
                .Select(p => p.ToDTO())
                .ToList();

            foreach (PackageDTO packageDTO in packageDTOs)
            {
                double price = packageDTO.Products.Sum(p => p.Price);

                packageDTO.Price = price;
                packageDTO.DiscountedPrice = price * 0.8;
            }

            return packageDTOs;
        }

        public async Task<PackageDTO?> GetByIdAsync(int packageId)
        {
            Package package = await packageRepository.GetByIdAsync(packageId);
            if (package == null) return null;

            PackageDTO packageDTO = package.ToDTO();
            foreach (ProductDTO product in packageDTO.Products)
            {
                List<Product> productsByName = await productRepository.GetAllByNameAsync(product.Name);
                List<ProductVariantDTO> variants = productsByName
                    .Select(p => p.ToVariantDTO())
                    .ToList();

                product.Variants = variants;
            }

            double price = packageDTO.Products.Sum(p => p.Price);
            packageDTO.Price = price;
            packageDTO.DiscountedPrice = price * 0.8;

            return packageDTO;
        }
    }
}
