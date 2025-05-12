using Server.Models;

namespace Server.Bll
{
    public interface IGiftService
    {
        Task<IEnumerable<Gift>> GetAllGiftsAsync();
        Task<Gift> GetGiftByIdAsync(int id);
        Task AddGiftAsync(Gift gift);
        Task UpdateGiftAsync(Gift gift);
        Task DeleteGiftAsync(int id);
    }
}
