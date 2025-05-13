using AutoMapper;
using Server.Dal;
using Server.Models;
using Server.Models.DTO;

namespace Server.Bll
{
    public class GiftService : IGiftService
    {
        private readonly IGiftDal _giftDal;
        private readonly IMapper _mapper;
        public GiftService(IGiftDal giftDal, IMapper mapper)
        {
            _giftDal = giftDal;
            _mapper = mapper;
        }
        public async Task<GiftDTOResualt> GetGiftById(int id)
        {
            var gift = await _giftDal.GetByIdAsync(id);
            if (gift == null)
            {
                throw new KeyNotFoundException($"Gift with ID {id} not found.");
            }
            return gift;
        }
        public async Task<List<GiftDTOResualt>> GetAllGifts()
        {
            var gifts = await _giftDal.GetAllAsync();
            if (gifts == null || !gifts.Any())
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return gifts;
        }
        public async Task AddGift(Gift gift)
        {
            if (gift == null)
            {
                throw new ArgumentNullException(nameof(gift), "Gift cannot be null.");
            }
            await _giftDal.AddAsync(gift);
        }
        public async Task UpdateGift(int id, GiftDTO gift)
        {
            if (gift == null)
            {
                throw new ArgumentNullException(nameof(gift), "Gift cannot be null.");
            }
            await _giftDal.UpdateAsync(id, gift);
        }
        public async Task DeleteGift(int id)
        {
            var existingGift = await _giftDal.GetByIdAsync(id);
            if (existingGift == null)
            {
                throw new KeyNotFoundException($"Gift with ID {id} not found.");
            }
            await _giftDal.DeleteAsync(id);
        }
        public async Task<List<GiftDTOResualt>> SortByCategory()
        {
            var gifts = await _giftDal.SortByCategory();
            if (gifts == null || !gifts.Any())
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return gifts;
        }
        public async Task<List<GiftDTOResualt>> SortByPrice()
        {
            var gifts = await _giftDal.SortByPrice();
            if (gifts == null || !gifts.Any())
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return gifts;
        }
        public async Task<GiftDTOResualt> Search(int? numBuyers, string? donorname, string? giftname)
        {
            var gift = await _giftDal.Search(numBuyers, donorname, giftname);
            if (gift == null)
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return gift;
        }
        public async Task<bool> IsTitleExists(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title), "Title cannot be null or empty.");
            }
            return await _giftDal.IsTitleExists(title);
        }

    }
}
