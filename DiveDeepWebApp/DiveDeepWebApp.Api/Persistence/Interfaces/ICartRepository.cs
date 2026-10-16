using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetAllByUserIdAsync(string userId);
        Task<CartItem?> GetByIdAsync(int id);
        
        Task CreateAsync(CartItem cartItem);
        Task CreateAsync(List<CartItem> cartItems);
        Task UpdateAsync(CartItem cartItem);
        Task DeleteAsync(int id);
        Task DeleteAsync(List<int> id);
        Task DeleteByProductIdAsync(int productId);
    }
}
