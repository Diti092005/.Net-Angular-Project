using Server.Models;
using Server.Models.DTO;

namespace Server.Bll
{
    public interface IGiftService
    {
        Task<GiftDTOResualt> GetGiftById(int id);
        Task<List<GiftDTOResualt>> GetAllGifts();
        Task AddGift(Gift gift);
        Task UpdateGift(int id, GiftDTO gift);
        Task DeleteGift(int id);
        Task<List<GiftDTOResualt>> SortByCategory();
        Task<List<GiftDTOResualt>> SortByPrice();
        Task<GiftDTOResualt> Search(int? numBuyers, string? donorname, string? giftname);
        Task<bool> IsTitleExists(string title);

    }
}
