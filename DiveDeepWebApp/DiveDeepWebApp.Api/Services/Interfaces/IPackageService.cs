using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IPackageService
    {
        public List<Package> GetAll();
        public Package? GetById(int packageId);
        public PackageDTO GetPackageDTO(int packageId);
    }
}

