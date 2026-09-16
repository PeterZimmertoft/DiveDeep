using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface IPackageRepository
    {
        public List<Package> GetAll();
    }
}
