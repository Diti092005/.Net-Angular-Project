using Server.Bll.Interfaces;
using Server.Dal;
using Server.Dal.Interfaces;
using Server.Models;
using Server.Models.DTO;

namespace Server.Bll
{
    public class DonorService:IDonorService
    {
        private readonly IDonorDal _donorDal;
        public DonorService(IDonorDal donorDal)
        {
            _donorDal = donorDal;
        }
        public async Task<Donor> GetDonorById(int id)
        {
            return await _donorDal.GetDonorById(id);
        }
        public async Task<List<DonorDTOResault>> GetAllDonors()
        {
            return await _donorDal.GetAllDonors();
        }
        public async Task<bool> AddDonor(Donor donor)
        {
            try
            {
                await _donorDal.AddDonor(donor);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
        public async Task<bool> UpdateDonor(int id, DonorDTO donor)
        {
            try
            {
                await _donorDal.UpdateDonor(id, donor);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
        public async Task<bool> DeleteDonor(int id)
        {
            try
            {
                await _donorDal.DeleteDonor(id);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
        public async Task<List<DonorDTOResault>> GetAllDonorsByType(string? mail, string? name, string? giftname)
        {
            return await _donorDal.GetAllDonorsByType(mail, name, giftname);
        }

    }
}
