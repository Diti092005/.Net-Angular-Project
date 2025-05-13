using AutoMapper;
using Server.Models;
using Server.Models.DTO;

namespace Server
{

    namespace Server.Profiles
    {
        public class AppProfile : Profile
        {
            public AppProfile()
            {
                CreateMap<GiftDTO, Gift>();
                CreateMap<Gift, GiftDTOResualt>()
                .ForMember(dest=>dest.CategoryName,opt=>opt.MapFrom(src => src.Category.CategoryName));
                CreateMap<Donor, DonorDTOResault>();
                CreateMap<CategoryDTO, Category>();
                CreateMap<DonorDTO, Donor>();
                CreateMap<Donor, DonorDTOTheen>();
                CreateMap<Gift, GiftDTOTheen>();
                CreateMap<User, UserDTOTheen>();
                CreateMap<Ticket, TicketsDTOTheen>();
            }
        }
    }
}
