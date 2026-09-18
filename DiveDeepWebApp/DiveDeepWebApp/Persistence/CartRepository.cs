using DiveDeepWebApp.Data;
using DiveDeepWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepWebApp.Persistence
{
    public class CartRepository : ICartRepository
    {
        private readonly DiveDeepContext context;

        public CartRepository(DiveDeepContext context)
        {
            this.context = context;
        }

        public List<CartItem> GetAllByUserId(string userId)
        {
            return context.CartItems
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Include(x => x.Product!.Category)
                .Include(x => x.Package)
                .Include(x => x.Package!.PackageProducts)
                .ToList();
        }

        public CartItem? GetById(int id)
        {
            return context.CartItems
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Create(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            context.SaveChanges();
        }

        public void Create(List<CartItem> cartItems)
        {
            context.CartItems.AddRange(cartItems);
            context.SaveChanges();
        }

        public void Update(CartItem cartItem)
        {
            CartItem? cartItemToUpdate = context.CartItems.Find(cartItem.Id);
            if (cartItemToUpdate == null) return;

            cartItemToUpdate.Quantity = cartItem.Quantity;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            CartItem? cartItemToDelete = context.CartItems.Find(id);
            if (cartItemToDelete == null) return;

            context.CartItems.Remove(cartItemToDelete);
            context.SaveChanges();
        }

        public void Delete(List<int> ids)
        {
            foreach (int id in ids)
            {
                CartItem? cartItemToDelete = context.CartItems.Find(id);
                if (cartItemToDelete == null) continue;

                context.CartItems.Remove(cartItemToDelete);
            }

            context.SaveChanges();
        }
    }
}
