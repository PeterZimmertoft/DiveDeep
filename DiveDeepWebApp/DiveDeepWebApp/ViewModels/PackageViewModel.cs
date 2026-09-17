using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.ViewModels
{
    public class PackageViewModel
    {
        [ValidateNever]
        public string Name { get; set; }

        [ValidateNever]
        public byte[] Image { get; set; }

        [ValidateNever]
        public string Description { get; set; }
        
        public List<PackageProductViewModel> packageProductsVM { get; set; }
    }
}
