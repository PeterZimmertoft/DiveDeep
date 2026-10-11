using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.DTOs;
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
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public ProductsController(UserManager<ApplicationUser> userManager, ICategoryRepository categoryRepository, IProductService productService, ICartService cartService)
        {
            this.userManager = userManager;
            this.categoryRepository = categoryRepository;
            this.productService = productService;
            this.cartService = cartService;
        }
        
        [HttpGet("categories")]
        public IActionResult GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            List<CategoryDTO> categoryDTOs;
            try
            {
                categories = categoryRepository.GetAll();

                categoryDTOs = categories
                    .Select(c => new CategoryDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        Image = c.Image
                    })
                    .ToList();


            }
            catch { return BadRequest(); }

            return Ok(categoryDTOs);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult Products(int categoryId)
        {
            CategoryProductsDTO categoryProductsDTO;
            try
            {
                categoryProductsDTO = productService.GetByCategoryId(categoryId);


            }
            catch { return NotFound("Category was not found"); }

            return Ok(categoryProductsDTO);
        }

        [HttpGet("product/{productId}")]
        public IActionResult Product(int productId)
        {
            ProductDTO productDTO = new ProductDTO();
            try
            {
                productDTO = productService.GetProductDTO(productId);
            }
            catch
            {
                return BadRequest(productId);
            }

            return Ok(productDTO);
        }

        //[Authorize]
        //[HttpPost("post")]
        //public IActionResult Product([FromBody] ProductDTO productDTO)
        //{
        //    string? userId = userManager.GetUserId(User);
        //    if (userId == null) return Unauthorized(productDTO);

        //    List<Product> variants = productService.GetAllByName(productDTO.ProductName);
        //    productDTO.Variants = variants;

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(productDTO);
        //    }

        //    Product? variant = variants.Find(p => p.MatchesOptions(productDTO.Size, productDTO.Thickness, productDTO.Gender));
        //    if (variants.Count == 1 && variant == null)
        //    {
        //        variant = variants.First();
        //    }

        //    if (variant == null)
        //    {
        //        return NotFound(productDTO);
        //    }

        //    cartService.Create(new CartItem
        //    {
        //        UserId = userId,
        //        ProductId = variant.Id,
        //        Quantity = 1
        //    });


        //    return Ok();
        //}



    //TempData["Message"] = "Du har tilføjet dette produkt til din kurv.";

    //return RedirectToAction(
    //    nameof(Product),
    //    new
    //    {
    //        categoryId = variant.CategoryId,
    //        productId = variant.Id
    //    }
    //);

}
}
