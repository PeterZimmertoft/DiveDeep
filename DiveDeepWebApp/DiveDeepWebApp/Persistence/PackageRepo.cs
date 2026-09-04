using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public static class PackageRepo
    {
        private static List<Package> packages;

        static PackageRepo()
        {
            packages = new List<Package>();
            Init();
        }

        public static List<Package> GetAll()
        {
            return packages;
        }

        private static void Init()
        {
            packages.Add(new Package
            {
                Id = 1,
                Name = "Komplet dykkersæt",
                Route = "divingSet",
                Products = new List<Product>()
                {
                    ProductRepo.GetById(1)!,  // BCD
                    ProductRepo.GetById(5)!,  // Dykkerdragt
                    ProductRepo.GetById(17)!, // Regulatorsæt
                    ProductRepo.GetById(13)!, // Tank
                    ProductRepo.GetById(27)!, // Finner
                    ProductRepo.GetById(20)!  // Maske/snorkel
                }
            });

            packages.Add(new Package
            {
                Id = 2,
                Name = "Komplet snorkelsæt",
                Route = "snorkelSet",
                Products = new List<Product>()
                {
                    ProductRepo.GetById(21)!, // Maske/snorkel
                    ProductRepo.GetById(28)!  // Finner
                }
            });
        }
    }
}
