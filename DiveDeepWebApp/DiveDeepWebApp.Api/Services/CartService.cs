using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;

namespace DiveDeepWebApp.Api.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<CartDTO> GetCartDTOAsync(string userId)
        {
            List<CartItem> rawCartItems = await cartRepository.GetAllByUserIdAsync(userId);
            List<CartItemDTO> cartItems = rawCartItems
                .Where(x => x.PackageId == null)
                .Select(x => new CartItemDTO
                {
                    Products = new List<CartItem> { x },
                })
                .ToList();

            Dictionary<int, List<CartItem>> cartItemsByPackage = rawCartItems
                .Where(x => x.PackageId != null)
                .GroupBy(x => x.PackageId)
                .ToDictionary(g => g.Key ?? 0, g => g.ToList());

            foreach (int packageId in cartItemsByPackage.Keys)
            {
                List<CartItem> packageCartItems = cartItemsByPackage[packageId];
                Package package = packageCartItems.First().Package!;
                int packageProductsCount = package.PackageProducts.Count;

                List<CartItem[]> packageItems = packageCartItems
                    .OrderBy(x => x.Id)
                    .Chunk(packageProductsCount)
                    .ToList();

                foreach (CartItem[] items in packageItems)
                {
                    cartItems.Add(new CartItemDTO
                    {
                        Package = package,
                        Products = items.ToList()
                    });
                }
            }

            return new CartDTO
            {
                Items = cartItems
            };
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await cartRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CartItem cartItem)
        {
            await cartRepository.CreateAsync(cartItem);
        }

        public async Task CreateAsync(List<CartItem> cartItems)
        {
            await cartRepository.CreateAsync(cartItems);
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            await cartRepository.UpdateAsync(cartItem);
        }

        public async Task DeleteAsync(int id)
        {
            await cartRepository.DeleteAsync(id);
        }

        public async Task DeleteAsync(List<int> ids)
        {
            await cartRepository.DeleteAsync(ids);
        }

        public async Task DeleteByProductIdAsync(int productId)
        {
            await cartRepository.DeleteByProductIdAsync(productId);
        }

        public async Task DeleteByProductIdAsync(List<int> productIds)
        {
            await cartRepository.DeleteByProductIdAsync(productIds);
        }
    }
}
