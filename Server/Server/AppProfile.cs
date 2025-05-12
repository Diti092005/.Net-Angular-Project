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
                CreateMap<Gift, GiftDTOResualt>();
                CreateMap<CategoryDTO, Category>();
            }
        }
    }
}
