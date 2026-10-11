using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
