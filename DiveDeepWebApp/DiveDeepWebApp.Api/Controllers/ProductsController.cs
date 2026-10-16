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
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<ProductDTO> productDTOs = await productService.GetAllAsync();
                return Ok(productDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByIdAsync(int productId)
        {
            try
            {
                ProductDTO? productDTO = await productService.GetByIdAsync(productId);
                if (productDTO == null) return NotFound();

                return Ok(productDTO);
            }
            catch
            {
                return BadRequest(productId);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDTO productDTO)
        {
            try
            {
                await productService.CreateAsync(productDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProductAsync(int productId, [FromBody] UpdateProductDTO productDTO)
        {
            try
            {
                await productService.UpdateAsync(productId, productDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            try
            {
                await productService.DeleteAsync(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
    }
}
