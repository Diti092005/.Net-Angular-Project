using Server.Dal;
using Server.Models;

namespace Server.Bll
{
    public class GiftService : IGiftService
    {
        private readonly IGiftDal _giftRepository;

        public GiftService(IGiftDal giftRepository)
        {
            _giftRepository = giftRepository;
        }

        public async Task<IEnumerable<Gift>> GetAllGiftsAsync()
        {
            return await _giftRepository.GetAllAsync();
        }

        public async Task<Gift> GetGiftByIdAsync(int id)
        {
            return await _giftRepository.GetByIdAsync(id);
        }

        public async Task AddGiftAsync(Gift gift)
        {
            await _giftRepository.AddAsync(gift);
        }

        public async Task UpdateGiftAsync(Gift gift)
        {
            await _giftRepository.UpdateAsync(gift);
        }

        public async Task DeleteGiftAsync(int id)
        {
            await _giftRepository.DeleteAsync(id);
        }

    }
}
