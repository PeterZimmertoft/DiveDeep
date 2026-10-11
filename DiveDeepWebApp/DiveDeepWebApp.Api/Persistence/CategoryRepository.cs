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

        public List<Category> GetAll()
        {
            return context.Categories
                .AsNoTracking()
                .ToList();
        }
    }
}
