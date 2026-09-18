namespace DiveDeepWebApp.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public List<PackageProduct> PackageProducts { get; set; }
        public List<CartItem> CartItemsWithPackage { get; set; }
    }
}
