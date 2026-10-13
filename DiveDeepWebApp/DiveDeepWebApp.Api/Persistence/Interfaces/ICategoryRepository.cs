using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Persistence.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}
