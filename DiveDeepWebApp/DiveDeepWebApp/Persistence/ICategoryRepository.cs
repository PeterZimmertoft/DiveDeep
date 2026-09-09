using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
