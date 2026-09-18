using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface ICartRepository
    {
        List<CartItem> GetAllByUserId(string userId);
        CartItem? GetById(int id);

        void Create(CartItem cartItem);
        void Create(List<CartItem> cartItems);
        void Update(CartItem cartItem);
        void Delete(int id);
        void Delete(List<int> id);
    }
}
