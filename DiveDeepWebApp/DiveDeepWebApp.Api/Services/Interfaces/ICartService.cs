using DiveDeepWebApp.Api.DTOs;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<CartItemDTO>> GetAllByUserIdAsync(string userId);

        Task CreateAsync(string userId, CreateCartItemDTO cartItemDTO);
        Task UpdateAsync(int cartItemId, UpdateCartItemDTO cartItemDTO);
        Task DeleteAsync(int cartItemId);
    }
}
