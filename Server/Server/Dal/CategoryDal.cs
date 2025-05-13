using Microsoft.EntityFrameworkCore;
using Server.Bll.Interfaces;
using Server.Dal.Interfaces;
using Server.Models;

namespace Server.Dal
{
    public class CategoryDal : ICategoryDal
    {
        private readonly ApplicationDbContext _context;

        public CategoryDal(ApplicationDbContext context)
        {
            _context = context;
        }
        async Task<List<Category>> ICategoryDal.GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        async Task<Category> ICategoryDal.GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(g => g.Id == id);
        }
        async Task ICategoryDal.AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        async Task ICategoryDal.UpdateAsync(int id,Category category)
        {
            var foundcategory = await _context.Categories.FindAsync(id);
            if (foundcategory != null) {
             foundcategory.CategoryName = category.CategoryName;
            _context.Categories.Update(foundcategory);
            await _context.SaveChangesAsync();
            }
        }
        async Task ICategoryDal.DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

            }
        }
        async Task<bool> ICategoryDal.IsExist(string name)
        {
          return await _context.Categories.AnyAsync(c=>c.CategoryName==name);
            
        }

    }
}
