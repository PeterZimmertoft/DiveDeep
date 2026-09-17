using DiveDeepWebApp.Migrations;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
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

        public PackageViewModel GetPackageViewModel(int packageId)
        {
            PackageViewModel packageViewModel = new PackageViewModel();

            Package? package = packageRepository.GetById(packageId);
            if (package != null)
            {
                packageViewModel.Name = package.Name;
                packageViewModel.Description = package.Description;
                packageViewModel.Image = package.Image;
                packageViewModel.packageProductsVM = new List<PackageProductViewModel>();

                foreach (PackageProduct packageProduct in package.PackageProducts)
                {
                    
                    packageViewModel.packageProductsVM.Add( new PackageProductViewModel 
                    { 
                        ProductName = packageProduct.Product.Name,
                        Variants = productRepository.GetAllByName(packageProduct.Product.Name) 
                    });
                }
            }
            return packageViewModel;
        }
    }
}
