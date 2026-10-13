using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Api.Persistence
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DiveDeepContext context;

        public PackageRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public List<Package> GetAll()
        {
            return context.Packages
                .AsNoTracking()
                .Include(p => p.PackageProducts)
                .ThenInclude(pp => pp.Product)
                .ToList();
        }

        public Package? GetById(int packageId)
        {
            Package? package = context.Packages
                .Where(p => p.Id == packageId)
                .AsNoTracking()
                .Include(p => p.PackageProducts)
                .ThenInclude(pp => pp.Product)
                .FirstOrDefault();

            return package;
        }
    }
}
