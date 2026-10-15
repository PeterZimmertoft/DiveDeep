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

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByIdAsync(int productId)
        {
            try
            {
                ProductDTO? productDTO = await productService.GetProductDTOAsync(productId);
                if (productDTO == null) return NotFound();

                return Ok(productDTO);
            }
            catch
            {
                return BadRequest(productId);
            }
        }
    }
}
