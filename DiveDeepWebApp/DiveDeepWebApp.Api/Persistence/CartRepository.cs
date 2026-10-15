using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Api.Persistence
{
    public class CartRepository : ICartRepository
    {
        private readonly DiveDeepContext context;

        public CartRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public async Task<List<CartItem>> GetAllByUserIdAsync(string userId)
        {
            return await context.CartItems
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Include(x => x.Product!.Category)
                .Include(x => x.Package)
                .Include(x => x.Package!.PackageProducts)
                .ToListAsync();
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await context.CartItems
                .Where(x => x.Id == id)
                .Include(x => x.Package)
                    .ThenInclude(x => x!.PackageProducts)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();
        }

        public async Task CreateAsync(List<CartItem> cartItems)
        {
            context.CartItems.AddRange(cartItems);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            CartItem? cartItemToUpdate = await context.CartItems.FindAsync(cartItem.Id);
            if (cartItemToUpdate == null) return;

            cartItemToUpdate.Quantity = cartItem.Quantity;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CartItem? cartItemToDelete = await context.CartItems.FindAsync(id);
            if (cartItemToDelete == null) return;

            context.CartItems.Remove(cartItemToDelete);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<int> ids)
        {
            foreach (int id in ids)
            {
                CartItem? cartItemToDelete = await context.CartItems.FindAsync(id);
                if (cartItemToDelete == null) continue;

                context.CartItems.Remove(cartItemToDelete);
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteByProductIdAsync(int productId)
        {
            List<CartItem> cartItemsWithProductId = await context.CartItems
                .Where(x => x.ProductId == productId)
                .ToListAsync();

            context.CartItems.RemoveRange(cartItemsWithProductId);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByProductIdAsync(List<int> productIds)
        {
            foreach (int productId in productIds)
            {
                List<CartItem> cartItemsWithProductId = await context.CartItems
                    .Where(x => x.ProductId == productId)
                    .ToListAsync();

                context.CartItems.RemoveRange(cartItemsWithProductId);
            }

            await context.SaveChangesAsync();
        }
    }
}
