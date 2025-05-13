using Server.Models;
using Server.Models.DTO;

namespace Server.Bll.Interfaces
{
    public interface IDonorService
    {
        Task<Donor> GetDonorById(int id);
        Task<List<DonorDTOResault>> GetAllDonors();
        Task<bool> AddDonor(Donor donor);
        Task<bool> UpdateDonor(int id, DonorDTO donor);
        Task<bool> DeleteDonor(int id);
        Task<List<DonorDTOResault>> GetAllDonorsByType(string? mail, string? name, string? giftname);
    }
}
