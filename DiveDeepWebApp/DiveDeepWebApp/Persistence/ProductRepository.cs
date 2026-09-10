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

        public Product? GetById(int productId)
        {
            return context.Products
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .FirstOrDefault(); 
        }

        public List<Product> GetAllByName(string name)
        {
            return context.Products
                .AsNoTracking()
                .Where(p => p.Name == name)
                .Include(p => p.Category)
                .ToList();
        }

    }
}
