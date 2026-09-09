using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Persistence
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
