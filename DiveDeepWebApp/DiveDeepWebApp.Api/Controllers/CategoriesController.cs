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
using DiveDeepWebApp.Api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DiveDeepWebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(UserManager<ApplicationUser> userManager, ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<Category> categories = await categoryRepository.GetAllAsync();
                List<CategoryDTO> categoryDTOs = categories
                    .Select(x => x.ToDTO())
                    .ToList();

                return Ok(categoryDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByIdAsync(int categoryId)
        {
            try
            {
                Category? category = await categoryRepository.GetByIdAsync(categoryId);
                if (category == null) return NotFound();

                CategoryDTO categoryDTO = category.ToDTO();
                return Ok(categoryDTO);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
