using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Mappers;
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

        public async Task<List<CartItemDTO>> GetAllByUserIdAsync(string userId)
        {
            List<CartItem> rawCartItems = await cartRepository.GetAllByUserIdAsync(userId);
            List<CartItemDTO> cartItems = rawCartItems
                .Where(x => x.PackageId == null)
                .Select(x =>
                {
                    ProductDTO productDTO = x.Product.ToDTO();
                    productDTO.Variants = new List<ProductVariantDTO>()
                    {
                        x.Product.ToVariantDTO()
                    };

                    return new CartItemDTO()
                    {
                        Id = x.Id,
                        Quantity = x.Quantity,
                        Products = new List<ProductDTO>()
                        {
                            productDTO
                        }
                    };
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
                    PackageDTO packageDTO = package.ToDTO();

                    double price = items.Sum(x => x.Product!.Price);
                    packageDTO.Price = price;
                    packageDTO.DiscountedPrice = price * 0.8;

                    cartItems.Add(new CartItemDTO
                    {
                        Id = items.First().Id,
                        Quantity = 1,
                        Package = packageDTO,
                        Products = items
                            .Select(x =>
                            {
                                ProductDTO productDTO = x.Product.ToDTO();
                                productDTO.Variants = new List<ProductVariantDTO>()
                                {
                                    x.Product.ToVariantDTO()
                                };

                                return productDTO;
                            })
                            .ToList()
                    });
                }
            }

            return cartItems;
        }

        public async Task CreateAsync(string userId, CreateCartItemDTO cartItemDTO)
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (var productId in cartItemDTO.ProductIds)
            {
                CartItem cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    PackageId = cartItemDTO.PackageId,
                    Quantity = 1
                };

                cartItems.Add(cartItem);
            }

            await cartRepository.CreateAsync(cartItems);
        }

        public async Task UpdateAsync(int cartItemId, UpdateCartItemDTO cartItemDTO)
        {
            CartItem? cartItem = await cartRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                throw new Exception("Cart item not found");
            }

            cartItem.Quantity = cartItemDTO.Quantity;
            await cartRepository.UpdateAsync(cartItem);
        }

        public async Task DeleteAsync(int cartItemId)
        {
            CartItem? cartItem = await cartRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                throw new Exception("Cart item not found");
            }

            List<int> ids = new List<int>()
            {
                cartItem.Id
            };

            if (cartItem.Package != null)
            {
                for (int i = 1; i < cartItem.Package.PackageProducts.Count; i++)
                {
                    ids.Add(cartItem.Id + i);
                }
            }

            await cartRepository.DeleteAsync(ids);
        }
    }
}
