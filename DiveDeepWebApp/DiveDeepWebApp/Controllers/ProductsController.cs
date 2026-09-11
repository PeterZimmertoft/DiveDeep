using Microsoft.AspNetCore.Mvc;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;

        public ProductsController(ICategoryRepository categoryRepository, IProductService productService) 
        {
            this.categoryRepository = categoryRepository;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll();
            return View(categories);
        }

        public IActionResult Products(int categoryId)
        {
            ProductsViewModel productsViewModel = productService.GetByCategoryId(categoryId);
            return View(productsViewModel);
        }

        public IActionResult Product(int productId)
        {
            ProductViewModel productViewModel = productService.GetProductViewModel(productId);
            return View(productViewModel);
        }
    }
}
