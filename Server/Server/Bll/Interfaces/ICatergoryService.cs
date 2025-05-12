using Server.Models;

namespace Server.Bll.Interfaces
{
    public interface ICatergoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(int id,Category category);
        Task DeleteCategoryAsync(int id);
        Task<bool> IsExist(string name);
    }
}
