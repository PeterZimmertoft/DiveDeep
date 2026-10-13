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

        public async Task<List<Package>> GetAllAsync()
        {
            return await context.Packages
                .AsNoTracking()
                .Include(p => p.PackageProducts)
                .ThenInclude(pp => pp.Product)
                .ToListAsync();
        }

        public async Task<Package?> GetByIdAsync(int packageId)
        {
            Package? package = await context.Packages
                .Where(p => p.Id == packageId)
                .AsNoTracking()
                .Include(p => p.PackageProducts)
                .ThenInclude(pp => pp.Product)
                .FirstOrDefaultAsync();

            return package;
        }
    }
}
