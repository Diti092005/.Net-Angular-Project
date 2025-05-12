using Server.Models;

namespace Server.Dal.Interfaces
{
    public interface ICategoryDal
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(int id,Category category);
        Task DeleteAsync(int id);
        Task<bool> IsExist(string name);
    }
}
