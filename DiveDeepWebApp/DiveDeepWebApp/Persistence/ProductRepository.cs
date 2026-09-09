using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly DiveDeepContext context;

        public ProductRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return context.Products
                .AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .ToList();
        }
    }
}
