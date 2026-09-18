using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;
using DiveDeepWebApp.Persistence;

namespace DiveDeepWebApp.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public CartViewModel GetCartViewModel(string userId)
        {
            List<CartItem> rawCartItems = cartRepository.GetAllByUserId(userId);
            List<CartItemViewModel> cartItems = rawCartItems
                .Where(x => x.PackageId == null)
                .Select(x => new CartItemViewModel
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
                    cartItems.Add(new CartItemViewModel
                    {
                        Package = package,
                        Products = items.ToList()
                    });
                }
            }

            return new CartViewModel
            {
                Items = cartItems
            };
        }

        public CartItem? GetById(int id)
        {
            return cartRepository.GetById(id);
        }

        public void Create(CartItem cartItem)
        {
            cartRepository.Create(cartItem);
        }

        public void Create(List<CartItem> cartItems)
        {
            cartRepository.Create(cartItems);
        }

        public void Update(CartItem cartItem)
        {
            cartRepository.Update(cartItem);
        }

        public void Delete(int id)
        {
            cartRepository.Delete(id);
        }

        public void Delete(List<int> ids)
        {
            cartRepository.Delete(ids);
        }
    }
}
