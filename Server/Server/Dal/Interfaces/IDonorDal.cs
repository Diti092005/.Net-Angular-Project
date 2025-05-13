using Server.Models;
using Server.Models.DTO;

namespace Server.Dal.Interfaces
{
    public interface IDonorDal
    {
        Task<Donor> GetDonorById(int id);
        Task<List<DonorDTOResault>> GetAllDonors();
        Task AddDonor(Donor donor);
        Task UpdateDonor(int id, DonorDTO donor);
        Task DeleteDonor(int id);
        Task<List<DonorDTOResault>> GetAllDonorsByType(string? mail, string? name, string? giftname);
    }
}
      