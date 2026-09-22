using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Data
{
    public static class ImageSeeder
    {
        private static readonly Dictionary<int, string> PackageImagePaths = new Dictionary<int, string>()
        {
            [1] = "diving-set.png",
            [2] = "snorkel-set.png"
        };

        private static readonly Dictionary<int, string> CategoryImagePaths = new Dictionary<int, string>()
        {
            [1] = "bcd.png",
            [2] = "suit.png",
            [3] = "tank.png",
            [4] = "regulator.png",
            [5] = "mask.png",
            [6] = "fin.png"
        };

        public static async Task SeedAsync(DiveDeepContext context)
        { 
            foreach ((int packageId, string imagePath) in PackageImagePaths)
            {
                Package? package = await context.Packages.FindAsync(packageId);
                if (package == null) continue;
                if (package.Image != null && package.Image.Length > 0) continue;
                
                package.Image = File.ReadAllBytes($"./wwwroot/packages/{imagePath}");
            }

            foreach ((int categoryId, string imagePath) in CategoryImagePaths)
            {
                Category? category = await context.Categories.FindAsync(categoryId);
                if (category == null) continue;
                if (category.Image != null && category.Image.Length > 0) continue;

                category.Image = File.ReadAllBytes($"./wwwroot/categories/{imagePath}");
            }

            context.SaveChanges();
        }
    }
}
