using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Helpers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;

namespace DiveDeepWebApp.Api.Services
{
    public class PackageService : IPackageService
    {
        private readonly IProductRepository productRepository;
        private readonly IPackageRepository packageRepository;

        public PackageService(IPackageRepository packageRepository, IProductRepository productRepository)
        {
            this.packageRepository = packageRepository;
            this.productRepository = productRepository;
        }

        public List<Package> GetAll()
        {
            return packageRepository.GetAll();
        }

        public Package? GetById(int packageId)
        {
            return packageRepository.GetById(packageId);
        }

        public PackageDTO GetPackageDTO(int packageId)
        {
            PackageDTO packageDTO = new PackageDTO();

            Package? package = packageRepository.GetById(packageId);
            if (package != null)
            {
                packageDTO.Id = package.Id;
                packageDTO.Name = package.Name;
                packageDTO.Description = package.Description;
                packageDTO.Image = package.Image;
                packageDTO.packageProductDTOs = new List<ProductDTO>();

                foreach (PackageProduct packageProduct in package.PackageProducts)
                {
                    packageDTO.packageProductDTOs.Add(new ProductDTO
                    {
                        Brand = packageProduct.Product.Brand,
                        ProductName = packageProduct.Product.Name,
                        Price = packageProduct.Product.Price,
                        Description = packageProduct.Product.Description,
                        Image = packageProduct.Product.Image,
                        VariantDTOs = productRepository.GetAllByName(packageProduct.Product.Name)
                                    .Select(p => new ProductVariantDTO
                                    {
                                        Id = p.Id,
                                        Size = ConvertProductToProductVariantDTO.Size(p),
                                        Thicikness = ConvertProductToProductVariantDTO.Thickness(p),
                                        Gender = ConvertProductToProductVariantDTO.Gender(p)
                                    })
                                    .ToList()
                    });
                }
            }
            else
                throw new Exception();
            
            return packageDTO;
        }
    }
}
