using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IPackageService
    {
        public List<Package> GetAll();
        public Package? GetById(int packageId);
        public PackageViewModel GetPackageViewModel(int packageId);
    }
}
