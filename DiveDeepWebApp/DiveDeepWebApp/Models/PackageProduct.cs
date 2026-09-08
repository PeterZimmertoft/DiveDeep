using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DiveDeepWebApp.Models
{
    public class PackageProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
