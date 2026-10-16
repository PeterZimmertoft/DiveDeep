using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DiveDeepWebApp.Data;

namespace DiveDeepWebApp.Controllers
{
    public class PackagesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public PackagesController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        // public IActionResult Package(int packageId)
        // {
        //     PackageViewModel packageVM = packageService.GetPackageViewModel(packageId);
        //     return View(packageVM);
        // }
        //
        // [HttpPost]
        // public IActionResult Package(PackageViewModel packageVM)
        // {
        //     string? userId = userManager.GetUserId(User);
        //     if (userId == null) return View(packageVM);
        //
        //     Package? package = packageService.GetById(packageVM.Id);
        //     if (package == null) return View(packageVM);
        //
        //     packageVM.Image = package.Image;
        //     packageVM.packageProductsVM.ForEach(productVM =>
        //     {
        //         List<Product> variants = productService.GetAllByName(productVM.ProductName);
        //         productVM.Variants = variants;
        //     });
        //
        //     if (!ModelState.IsValid) return View(packageVM);
        //
        //     List<CartItem> cartItems = new List<CartItem>();
        //     for (int index = 0; index < packageVM.packageProductsVM.Count; index++)
        //     {
        //         ProductViewModel packageProductVM = packageVM.packageProductsVM[index];
        //         Product? variant = packageProductVM.Variants.Find(p => p.MatchesOptions(packageProductVM.Size, packageProductVM.Thickness, packageProductVM.Gender));
        //
        //         if (packageProductVM.Variants.Count == 1 && variant == null)
        //         {
        //             variant = packageProductVM.Variants.First();
        //         }
        //
        //         if (variant == null)
        //         {
        //             return View(packageVM);
        //         }
        //
        //         cartItems.Add(new CartItem
        //         {
        //             UserId = userId,
        //             ProductId = variant.Id,
        //             PackageId = package.Id,
        //             Quantity = 1
        //         });
        //     }
        //
        //     cartService.Create(cartItems);
        //     TempData["Message"] = "Du har tilføjet denne pakke til din kurv.";
        //
        //     return RedirectToAction(
        //         nameof(Package),
        //         new
        //         {
        //             packageId = package.Id
        //         }
        //     );
        // }
    }
}
