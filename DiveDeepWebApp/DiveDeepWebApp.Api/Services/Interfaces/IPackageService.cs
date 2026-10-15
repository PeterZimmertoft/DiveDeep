using DiveDeepWebApp.Api.DTOs;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IPackageService
    {
        Task<List<PackageDTO>> GetAllAsync();
        Task<PackageDTO?> GetByIdAsync(int packageId);
    }
}

