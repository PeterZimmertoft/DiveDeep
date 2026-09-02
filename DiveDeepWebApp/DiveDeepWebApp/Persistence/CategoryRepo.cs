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

            categories.Add(new Category { Name = "Maske/Snorkel", Description = "Beskrivelse her", Route = "mask"});

            categories.Add(new Category { Name = "Finner", Description = "Beskrivelse her", Route = "fin" });

            categories.Add(new Category { Name = "Dykkersæt", Description = "Beskrivelse her", Route = "completeSet" });

            categories.Add(new Category { Name = "Snorkelsæt", Description = "Beskrivelse her", Route = "snorkelSet" });
        }

        public static List<Category> GetAll()
        {
            return categories;
        }


         
        
        
    }
}
