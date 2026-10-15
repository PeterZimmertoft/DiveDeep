using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Image = category.Image,
                Products = category.Products?
                    .Select(p => p.ToDTO())
                    .ToList()
                           ?? null
            };
        }
    }
}