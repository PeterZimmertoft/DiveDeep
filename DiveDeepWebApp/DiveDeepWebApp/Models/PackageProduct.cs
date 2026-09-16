namespace DiveDeepWebApp.Models
{
    public class PackageProduct
    {
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
