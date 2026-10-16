using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService packageService;

        public PackagesController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<PackageDTO> packageDTOs = await packageService.GetAllAsync();
                return Ok(packageDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{packageId}")]
        public async Task<IActionResult> Package(int packageId)
        {
            try
            {
                PackageDTO packageDTO = await packageService.GetByIdAsync(packageId);
                if (packageDTO == null) return NotFound();

                return Ok(packageDTO);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
