using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public class CategoryRepo
    {
        private List<Category> categories = new List<Category>();

        public CategoryRepo()
        {
            List<string> tempCategories = new List<string> { "BCD", "Dykkerdragter", "Tanke", "Regulatorsæt", "Maske/Snorkel", "Finner" };

            foreach (var category in tempCategories)
            {
                categories.Add(new Category { Name = category });
            }
        }
    }
}
