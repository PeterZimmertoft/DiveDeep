using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<CartItem>> GetAllByUserIdAsync(string userId);
        Task<List<CartItemDTO>> GetAllDTOsByUserIdAsync(string userId);

        Task CreateAsync(string userId, CreateCartItemDTO cartItemDTO);
        Task UpdateAsync(int cartItemId, UpdateCartItemDTO cartItemDTO);
        Task DeleteAsync(int cartItemId);
        Task DeleteAsync(List<int> cartItemIds);
        Task DeleteByProductIdAsync(int productId);
    }
}
