using Server.Models;

namespace Server.Dal
{
    public interface IGiftDal
    {
        Task<IEnumerable<Gift>> GetAllAsync();
        Task<Gift> GetByIdAsync(int id);
        Task AddAsync(Gift gift);
        Task UpdateAsync(Gift gift);
        Task DeleteAsync(int id);
        //public Task<List<Donor>> GetDonors(int id);
        //public Task<List<Gift>> Search(string name = "", string donor = "", int minSales = 0, int price = 10);
        //public Task<bool> TitleExists(string title);
        //public Task<List<Gift>> SortByPrice();
        //public Task<List<Gift>> SortByName();
    }
}
