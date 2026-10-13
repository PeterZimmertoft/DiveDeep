using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllAsync();

        Task<Package?> GetByIdAsync(int packageId);
    }
}
