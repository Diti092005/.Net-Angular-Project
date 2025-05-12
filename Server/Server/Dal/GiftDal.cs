using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Dal
{
    public class GiftDal:IGiftDal
    {
            private readonly ApplicationDbContext _context;

            public GiftDal(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Gift>> GetAllAsync()
            {
                return await _context.Gifts.ToListAsync();
            }
            public async Task<Gift> GetByIdAsync(int id)
            {
                return await _context.Gifts.FirstOrDefaultAsync(g => g.Id == id);
            }

            public async Task AddAsync(Gift gift)
            {
                await _context.Gifts.AddAsync(gift);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Gift gift)
            {
                _context.Gifts.Update(gift);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var gift = await _context.Gifts.FindAsync(id);
                if (gift != null)
                {
                    _context.Gifts.Remove(gift);
                    await _context.SaveChangesAsync();
                }
            }
            //public Task<List<Donor>> GetDonors(int id)
            //{
            //var gifts = await _context.Gifts.Find(DonorId = id);
            //}
            //public Task<List<Gift>> Search(string name = "", string donor = "", int minSales = 0, int price = 10);
            //public Task<bool> TitleExists(string title);
            //public Task<List<Gift>> SortByPrice();
            //public Task<List<Gift>> SortByName();
    }
}