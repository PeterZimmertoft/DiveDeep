using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface ICartService
    {
        CartViewModel GetCartViewModel(string userId);
        CartItem? GetById(int id);

        void Create(CartItem cartItem);
        void Create(List<CartItem> cartItems);
        void Update(CartItem cartItem);
        void Delete(int id);
        void Delete(List<int> ids);
    }
}
