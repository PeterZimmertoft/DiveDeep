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

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            Product? productToUpdate = context.Products.Find(product.Id);
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
                suitToUpdate.Thickness =  suit.Thickness;
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

            context.SaveChanges();
        }

        public void Delete(int productId)
        {
            Product? productToDelete = context.Products.Find(productId);
            if (productToDelete == null) return;

            context.Products.Remove(productToDelete);
            context.SaveChanges();
        }

        public void Delete(List<int> productIds)
        {
            foreach (int productId in productIds)
            {
                Product? productToDelete = context.Products.Find(productId);
                if (productToDelete == null) continue;

                context.Products.Remove(productToDelete);
            }

            context.SaveChanges();
        }
    }
}
