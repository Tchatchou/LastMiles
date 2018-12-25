using AutoMapper;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;

namespace LastMiles.API.Helpers
{
    public class AutoMapperProfilesHelper : Profile
    {
        
        public AutoMapperProfilesHelper()
        {
            CreateMap<User,UserForRegistrationDto>();
            CreateMap<UserForRegistrationDto,User>();
        }
    }
}