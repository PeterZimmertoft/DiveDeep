using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Api.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly DiveDeepContext context;

        public ProductRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .Include(p => p.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllByNameAsync(string name)
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Name == name)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            Product? productToUpdate = await context.Products.FindAsync(product.Id);
            if (productToUpdate == null) return;

            productToUpdate.Brand = product.Brand;
            productToUpdate.Price = product.Price;
            productToUpdate.Description = product.Description;
            productToUpdate.Image = product.Image;
            productToUpdate.Quantity = product.Quantity;

            if (productToUpdate is BCD bcdToUpdate && product is BCD bcd)
            {
                bcdToUpdate.Model = bcd.Model;
                bcdToUpdate.Size = bcd.Size;
            }
            else if (productToUpdate is Suit suitToUpdate && product is Suit suit)
            {
                suitToUpdate.Model = suit.Model;
                suitToUpdate.Type = suit.Type;
                suitToUpdate.Gender = suit.Gender;
                suitToUpdate.Size = suit.Size;
                suitToUpdate.Thickness = suit.Thickness;
            }
            else if (productToUpdate is Tank tankToUpdate && product is Tank tank)
            {
                tankToUpdate.Volume = tank.Volume;
            }
            else if (productToUpdate is Regulator regulatorToUpdate && product is Regulator regulator)
            {
                regulatorToUpdate.FirstStage = regulator.FirstStage;
                regulatorToUpdate.SecondStage = regulator.SecondStage;
                regulatorToUpdate.Octopus = regulator.Octopus;
            }
            else if (productToUpdate is Mask maskToUpdate && product is Mask mask)
            {
                maskToUpdate.Model = mask.Model;
            }
            else if (productToUpdate is Fin finToUpdate && product is Fin fin)
            {
                finToUpdate.Model = fin.Model;
                finToUpdate.Size = fin.Size;
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            Product? productToDelete = await context.Products.FindAsync(productId);
            if (productToDelete == null) return;

            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync();
        }
    }
}
