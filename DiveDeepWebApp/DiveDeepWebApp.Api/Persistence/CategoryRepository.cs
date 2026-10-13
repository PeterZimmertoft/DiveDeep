using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Api.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DiveDeepContext context;

        public CategoryRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            Category? category = await context.Categories
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Include(c => c.Products)
                .FirstOrDefaultAsync();

            if (category == null)
                return null;

            category.Products = category.Products
                .DistinctBy(p => p.Name)
                .ToList();

            return category;
        }
    }
}
