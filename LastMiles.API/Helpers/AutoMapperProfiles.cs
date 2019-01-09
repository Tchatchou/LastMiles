using AutoMapper;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;

namespace LastMiles.API.Helpers
{
    public class AutoMapperProfilesHelper : Profile
    {
        
        public AutoMapperProfilesHelper()
        {
            CreateMap<User,User_For_Registration_Dto>();
            CreateMap<User_For_Registration_Dto,User>();

            // company mapping
            CreateMap<Company_For_Listing_Dto,Company>();
            CreateMap<Company,Company_For_Listing_Dto>();

            CreateMap<Company_For_Details_Dto,Company>();
            CreateMap<Company,Company_For_Details_Dto>();

            CreateMap<Company_For_Registration_Dto,Company>();
            CreateMap<Company,Company_For_Registration_Dto>();

            CreateMap<Company_Contact,Company_Contact_Dto>();
            CreateMap<Company_Contact_Dto,Company_Contact>();

            CreateMap<Company_Type_Dto,Company_Type>();
            CreateMap<Company_Type,Company_Type_Dto>();

             // Distributor mapping
            CreateMap<Distributor_For_Registration_Dto,Distributor>();
            CreateMap<Distributor,Distributor_For_Registration_Dto>();

            CreateMap<Retailer_For_Registration_Dto,Retailer>();
            CreateMap<Retailer,Retailer_For_Registration_Dto>();

            CreateMap<Available_Role_Dto,Available_Role>();
            CreateMap<Available_Role,Available_Role_Dto>();
            
        }
    }
}