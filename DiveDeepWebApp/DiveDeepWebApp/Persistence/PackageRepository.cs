using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Persistence
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
                .ToList();
        }

        public Package? GetById(int packageId)
        {
            Package? package = context.Packages
                .Where(p => p.Id == packageId)
                .AsNoTracking()
                .Include(p => p.PackageProducts)
                .Include(p => p.PackageProducts)
                .FirstOrDefault();

            return package == null ? null : package;


        }
    }
}
