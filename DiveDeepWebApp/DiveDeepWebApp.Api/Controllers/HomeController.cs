// using DiveDeepWebApp.Api.DTOs;
// using DiveDeepWebApp.Api.Mappers;
// using DiveDeepWebApp.Api.Models;
// using DiveDeepWebApp.Api.Services.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using System.Diagnostics;
//
// namespace DiveDeepWebApp.Api.Controllers
// {
//     public class HomeController : ControllerBase
//     {
//         private readonly IPackageService packageService;
//         private readonly IProductService productService;
//
//         public HomeController(IPackageService packageService, IProductService productService)
//         {
//             this.packageService = packageService;
//             this.productService = productService;
//         }
//
//         public IActionResult Index()
//         {
//             List<Package> packages = packageService.GetAll();
//             PackageDTO packageDTO = new PackageDTO();
//             packageDTO.Products = packages
//                 .Select(p => p.PackageProducts.Select(p => p.Product.ToDTO()).ToList())
//                 .ToList();
//
//
//             return View(packages);
//         }
//
//         public IActionResult Privacy()
//         {
//             return View();
//         }
//
//         public IActionResult AboutUs()
//         {
//             return View();
//         }
//
//         public IActionResult Contact()
//         {
//             return View();
//         }
//     }
// }
