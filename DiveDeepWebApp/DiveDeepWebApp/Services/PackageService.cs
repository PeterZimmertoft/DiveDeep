using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;

namespace DiveDeepWebApp.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        public List<Package> GetAll()
        {
            return packageRepository.GetAll();
        }
    }
}
