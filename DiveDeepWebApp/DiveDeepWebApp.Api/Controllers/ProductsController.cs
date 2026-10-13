using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Helpers;
using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiveDeepWebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;

        public ProductsController(UserManager<ApplicationUser> userManager, IProductService productService, ICartService cartService)
        {
            this.userManager = userManager;
            this.productService = productService;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> Product(int productId)
        {
            try
            {
                ProductDTO? productDTO = await productService.GetProductDTOAsync(productId);

                if (productDTO == null)
                {
                    return NotFound(productId);
                }

                return Ok(productDTO);
            }
            catch
            {
                return BadRequest(productId);
            }
        }

        // [Authorize]
        // [HttpPost("post")]
        // public IActionResult Product([FromBody] ProductDTO productDTO)
        // {
        //     string? userId = userManager.GetUserId(User);
        //     if (userId == null) return Unauthorized();
        //
        //     List<Product> variants = productService.GetAllByName(productDTO.ProductName);
        //     productDTO.VariantDTOs = variants
        //         .Select(p => new ProductVariantDTO
        //         {
        //             Id = p.Id,
        //             Size = ConvertProductToProductVariantDTO.Size(p),
        //             Thicikness = ConvertProductToProductVariantDTO.Thickness(p),
        //             Gender = ConvertProductToProductVariantDTO.Gender(p)
        //         })
        //         .ToList();
        //
        //
        //     Product? variant = variants.Find(p => p.MatchesOptions(productDTO.Size, productDTO.Thickness, productDTO.Gender));
        //     if (variants.Count == 1 && variant == null)
        //     {
        //         variant = variants.First();
        //     }
        //
        //     if (variant == null)
        //     {
        //         return NotFound(productDTO);
        //     }
        //
        //     cartService.Create(new CartItem
        //     {
        //         UserId = userId,
        //         ProductId = variant.Id,
        //         Quantity = 1
        //     });
        //
        //
        //     return Ok();
        // }
    }
}
