using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Server.Models.DTO;

namespace Server.Dal
{
    public class GiftDal:IGiftDal
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GiftDal(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GiftDTOResualt>> GetAllAsync()
        {
            var gifts = await _context.Gifts.Include(g => g.Donor)
                                            .Include(g => g.Category)
                                            .Include(g => g.Tickets)
                                            .Include(t => t.Winner)
                                            .ToListAsync();
            if (gifts == null || !gifts.Any())
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return _mapper.Map<List<GiftDTOResualt>>(gifts);
        }

        public async Task<List<GiftDTOResualt>> SortByCategory()
        {
            var gifts = await _context.Gifts.Include(g => g.Donor)
                                            .Include(g => g.Category)
                                            .Include(g => g.Tickets)
                                            .Include(t => t.Winner)
                                            .OrderBy(g => g.Category.CategoryName)
                                            .ToListAsync();
            if (gifts == null || !gifts.Any())
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return _mapper.Map<List<GiftDTOResualt>>(gifts);
        }

        public async Task<List<GiftDTOResualt>> SortByPrice()
        {
            var gifts = _context.Gifts.Include(g => g.Donor)
                                      .Include(g => g.Category)
                                      .Include(g => g.Tickets)
                                      .Include(t => t.Winner)
                                      .OrderBy(g => g.Price)
                                      .ToListAsync();
            if (gifts == null)
            {
                throw new KeyNotFoundException("No gifts found.");
            }
            return _mapper.Map<List<GiftDTOResualt>>(gifts);
        }

        public async Task<GiftDTOResualt> GetByIdAsync(int id)
        {
            var gift = await _context.Gifts.Include(g => g.Donor)
                                            .Include(g => g.Category)
                                            .Include(g => g.Tickets)
                                            .Include(t => t. Winner)
                                            .FirstOrDefaultAsync(g => g.Id == id);
            if (gift == null)
            {
                throw new KeyNotFoundException($"Gift with ID {id} not found.");
            }
            return _mapper.Map<GiftDTOResualt>(gift);
        }

        public async Task<GiftDTOResualt> Search(int? numBuyers, string? donorname, string? giftname)
        {
            var gifts = await _context.Gifts.Include(g => g.Donor)
                                            .Include(g => g.Category)
                                            .Include(g => g.Tickets)
                                            .Include(t => t.Winner)
                                            .ToListAsync();

            if (gifts == null || !gifts.Any())
            {
                throw new KeyNotFoundException("No gifts found.");
            }

            var filteredGifts = gifts.Where(g => (numBuyers == null || g.Tickets.Count >= numBuyers) &&
                                                 (donorname == null || g.Donor.Name.Contains(donorname)) &&
                                                 (giftname == null || g.GiftName.Contains(giftname)))
                                      .ToList();
            if (filteredGifts == null || !filteredGifts.Any())
                {
                throw new KeyNotFoundException("No gifts found with the specified criteria.");
            }
            return _mapper.Map<GiftDTOResualt>(filteredGifts);
        }

        public async Task<bool> IsTitleExists(string title)
        {
            var gift = await _context.Gifts.FirstOrDefaultAsync(g => g.GiftName == title);
            return gift != null;//????
        }

        public async Task AddAsync(Gift gift)
        {
            if (gift == null)
            {
                throw new ArgumentNullException(nameof(gift), "Gift cannot be null.");
            }
            await _context.Gifts.AddAsync(gift);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id,GiftDTO gift)
        {
            if (gift == null)
            {
                throw new ArgumentNullException(nameof(gift), "Gift cannot be null.");
            }
            var existingGift = await _context.Gifts.FindAsync(id);
            if (existingGift == null)
            {
                throw new KeyNotFoundException($"Gift with ID {id} not found.");
            }
            existingGift.GiftName = gift.GiftName;
            existingGift.Price = gift.Price;
            existingGift.Image = gift.Image;
            existingGift.Details = gift.Details;
            existingGift.CategoryId = gift.CategoryId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);
            if (gift == null)
            {
                throw new KeyNotFoundException($"Gift with ID {id} not found.");
            }
            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
        }
    }
    
}
