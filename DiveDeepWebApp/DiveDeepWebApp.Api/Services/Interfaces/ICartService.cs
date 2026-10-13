using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> GetCartDTOAsync(string userId);
        Task<CartItem?> GetByIdAsync(int id);

        Task CreateAsync(CartItem cartItem);
        Task CreateAsync(List<CartItem> cartItems);
        Task UpdateAsync(CartItem cartItem);
        Task DeleteAsync(int id);
        Task DeleteAsync(List<int> ids);
        Task DeleteByProductIdAsync(int productId);
        Task DeleteByProductIdAsync(List<int> productIds);
    }
}
