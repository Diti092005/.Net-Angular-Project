using Server.Models;
using Server.Models.DTO;

namespace Server.Dal
{
    public interface IGiftDal
    {
        Task<List<GiftDTOResualt>> GetAllAsync();
        Task<List<GiftDTOResualt>> SortByCategory();
        Task<List<GiftDTOResualt>> SortByPrice();
        Task<GiftDTOResualt> GetByIdAsync(int id);
        Task<GiftDTOResualt> Search(int? numBuyers, string? donorname, string? giftname);
        Task<bool> IsTitleExists(string title);
        Task AddAsync(Gift gift);
        Task UpdateAsync(int id,GiftDTO gift);
        Task DeleteAsync(int id);

    }
}
