using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface IPackageRepository
    {
        public List<Package> GetAll();

        public Package? GetById(int packageId);
    }
}
