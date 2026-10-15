using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Mappers
{
    public static class PackageMapper
    {

        public static PackageDTO ToDTO(this Package package)
        {
            return new PackageDTO()
            {
                Id =  package.Id,
                Name = package.Name,
                Image = package.Image,
                Description = package.Description,
                Products = package.PackageProducts?.First()?.Product != null
                    ? package.PackageProducts?
                           .Select(p => p.Product.ToDTO())
                           .ToList()
                                ?? null
                    : null
            };
        }
    }
}