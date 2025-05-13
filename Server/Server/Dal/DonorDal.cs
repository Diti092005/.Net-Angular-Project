using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Dal.Interfaces;
using Server.Models;
using Server.Models.DTO;

namespace Server.Dal
{
    public class DonorDal: IDonorDal
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DonorDal(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Donor> GetDonorById(int id)
        {
            
        var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                throw new KeyNotFoundException($"Donor with ID {id} not found.");
            }
            return donor;
        }

        public async Task<List<DonorDTOResault>> GetAllDonors()
        {
            var donors = await _context.Donors.Include(g=>g.Gifts).ToListAsync();
            if (donors == null || !donors.Any())
            {
                throw new KeyNotFoundException("No donors found.");
            }
            return _mapper.Map<List<DonorDTOResault>>(donors);
        }
        
        public async Task AddDonor(Donor donor)
        {
            if (donor == null)
            {
                throw new ArgumentNullException(nameof(donor), "Donor cannot be null.");
            }
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDonor(int id, DonorDTO donor)
        {
            if (donor == null)
            {
                throw new ArgumentNullException(nameof(donor), "Donor cannot be null.");
            }
            var existingDonor = await _context.Donors.FindAsync(id);
            if (existingDonor == null)
            {
                throw new KeyNotFoundException($"Donor with ID {id} not found.");
            }
            existingDonor.Name = donor.Name;
            existingDonor.Email = donor.Email;
            existingDonor.ShowMe = donor.ShowMe;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDonor(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                throw new KeyNotFoundException($"Donor with ID {id} not found.");
            }
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }
        public async Task<List<DonorDTOResault>> GetAllDonorsByType(string? mail, string? name, string? giftname)
        {
            var query = _context.Donors.AsQueryable();

            if (!string.IsNullOrEmpty(mail))
            {
                query = query.Where(d => d.Email.Contains(mail)).Include(g=>g.Gifts);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(d => d.Name.Contains(name)).Include(g => g.Gifts);
            }

            if (!string.IsNullOrEmpty(giftname))
            {
                query = query.Include(d => d.Gifts)
                             .Where(d => d.Gifts.Any(g => g.GiftName.Contains(giftname)));
            }
            var res = await query.ToListAsync();
           return _mapper.Map<List<DonorDTOResault>>(res);

        }
    }
    
}
