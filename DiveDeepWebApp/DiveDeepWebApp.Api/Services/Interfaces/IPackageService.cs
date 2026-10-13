using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(int packageId);
        Task<PackageDTO> GetPackageDTOAsync(int packageId);
    }
}

