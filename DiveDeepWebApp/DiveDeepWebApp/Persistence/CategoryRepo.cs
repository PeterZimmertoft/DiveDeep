using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public static class CategoryRepo
    {
        private static List<Category> categories;

        static CategoryRepo()
        {
            categories = new List<Category>();
            Init();
        }
        private static void Init() 
        {
            categories.Add(new Category { Name =  "BCD", Description = "Beskrivelse her", Route = "bcd"});

            categories.Add(new Category { Name = "Dykkerdragter", Description = "Beskrivelse her", Route = "suit" });

            categories.Add(new Category { Name = "Tanke", Description = "Beskrivelse her", Route = "tank" });

            categories.Add(new Category { Name = "Regulatorsæt", Description = "Beskrivelse her", Route = "regulator" });

            categories.Add(new Category { Name = "Maske/Snorkel", Description = "Beskrivelse her", Route = "Mask"});

            categories.Add(new Category { Name = "Finner", Description = "Beskrivelse her", Route = "fin" });


        }

        public static List<Category> GetAll()
        {
            return categories;
        }


         
        
        
    }
}
