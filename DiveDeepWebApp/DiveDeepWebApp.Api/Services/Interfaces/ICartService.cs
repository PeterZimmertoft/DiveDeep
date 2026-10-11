using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface ICartService
    {
        CartDTO GetCartDTO(string userId);
        CartItem? GetById(int id);

        void Create(CartItem cartItem);
        void Create(List<CartItem> cartItems);
        void Update(CartItem cartItem);
        void Delete(int id);
        void Delete(List<int> ids);
        void DeleteByProductId(int productId);
        void DeleteByProductId(List<int> productIds);
    }
}
