using Server.Bll.Interfaces;
using Server.Dal;
using Server.Dal.Interfaces;
using Server.Models;

namespace Server.Bll
{
    public class CatergoryService:ICatergoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CatergoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        Task<List<Category>> ICatergoryService.GetAllCategoryAsync()
        {
            return _categoryDal.GetAllAsync();
        }
        Task<Category> ICatergoryService.GetCategoryByIdAsync(int id)
        {
            return _categoryDal.GetByIdAsync(id);
        }
        Task ICatergoryService.AddCategoryAsync(Category category)
        {
            return _categoryDal.AddAsync(category);

        }
        Task ICatergoryService.UpdateCategoryAsync(int id,Category category)
        {
            return _categoryDal.UpdateAsync(id,category);

        }
        Task ICatergoryService.DeleteCategoryAsync(int id)
        {
            return _categoryDal.DeleteAsync(id);

        }
        Task<bool> ICatergoryService.IsExist(string name)
        {
            return _categoryDal.IsExist(name);

        }

    }
}
