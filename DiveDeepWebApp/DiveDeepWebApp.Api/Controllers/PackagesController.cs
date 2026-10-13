using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Helpers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPackageService packageService;
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public PackagesController(UserManager<ApplicationUser> userManager, IPackageService packageService, IProductService productService, ICartService cartService)
        {
            this.userManager = userManager;
            this.packageService = packageService;
            this.productService = productService;
            this.cartService = cartService;
        }

        [HttpGet("package/{packageId}")]
        public IActionResult Package(int packageId)
        {
            PackageDTO packageDTO = new PackageDTO();
            try
            {
                packageDTO = packageService.GetPackageDTO(packageId);
            }
            catch
            {
                return NotFound();
            }
            return Ok(packageDTO);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Package(PackageDTO packageDTO)
        {
            string? userId = userManager.GetUserId(User);
            if (userId == null) return Unauthorized();

            Package? package = packageService.GetById(packageDTO.Id);
            if (package == null) return NotFound();

            List<List<Product>> productsWithVariants = new List<List<Product>>();

            packageDTO.Image = package.Image;
            packageDTO.packageProductDTOs.ForEach(productDTO =>
            {
                List<Product> variants = productService.GetAllByName(productDTO.ProductName);
                productsWithVariants.Add(variants);
            });

            if (!ModelState.IsValid) return BadRequest();

            List<CartItem> cartItems = new List<CartItem>();
            for (int index = 0; index < packageDTO.packageProductDTOs.Count; index++)
            {
                ProductDTO packageProductDTO = packageDTO.packageProductDTOs[index];
                Product? variant = productsWithVariants[index].Find(p => p.MatchesOptions(packageProductDTO.Size, packageProductDTO.Thickness, packageProductDTO.Gender));
                    

                if (productsWithVariants[index].Count == 1 && variant == null)
                {
                    variant = productsWithVariants[index].First();
                }

                if (variant == null)
                {
                    return BadRequest(packageDTO);
                }

                cartItems.Add(new CartItem
                {
                    UserId = userId,
                    ProductId = variant.Id,
                    PackageId = package.Id,
                    Quantity = 1
                });
            }

            cartService.Create(cartItems);

            return Ok();
        }
    }
}
