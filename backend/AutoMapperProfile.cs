using AutoMapper;
using backend.Model.Sead;

namespace backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserInfo,UserInfoDto>();
        }
        
    }
}