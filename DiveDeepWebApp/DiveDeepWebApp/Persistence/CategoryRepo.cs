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
            categories.Add(new Category { Name =  "BCD", Description = "Beskrivelse her"});

            categories.Add(new Category { Name = "Dykkerdragter", Description = "Beskrivelse her" });

            categories.Add(new Category { Name = "Tanke", Description = "Beskrivelse her" });

            categories.Add(new Category { Name = "Regulatorsæt", Description = "Beskrivelse her" });

            categories.Add(new Category { Name = "Maske/Snorkel", Description = "Beskrivelse her" });

            categories.Add(new Category { Name = "Finner", Description = "Beskrivelse her" });


        }

        public static List<Category> GetAll()
        {
            return categories;
        }


         
        
        
    }
}
