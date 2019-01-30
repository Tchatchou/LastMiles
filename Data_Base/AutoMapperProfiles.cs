using AutoMapper;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
using Data_Base.DB_Product_Management;

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

            CreateMap<Distributor_For_Details_Dto,Distributor>();
            CreateMap<Distributor,Distributor_For_Details_Dto>();

            CreateMap<Retailer_For_Registration_Dto,Retailer>();
            CreateMap<Retailer,Retailer_For_Registration_Dto>();

            CreateMap<Available_Role_Dto,Available_Role>();
            CreateMap<Available_Role,Available_Role_Dto>();

            //Product mapping            
            CreateMap<Product_Registration_Dto,Product>();
            CreateMap<Product,Product_Registration_Dto>();
            
            CreateMap<Product_Pricing_Table_Distributor_Get_Dto,Product_Pricing_Table_Distributor>();
            CreateMap<Product_Pricing_Table_Distributor,Product_Pricing_Table_Distributor_Get_Dto>();

            CreateMap<Product_Pricing_Table_Distributor_Set_Dto,Product_Pricing_Table_Distributor>();
            CreateMap<Product_Pricing_Table_Distributor,Product_Pricing_Table_Distributor_Set_Dto>();
   
            CreateMap<Product_Pricing_Table_Retailer_Get_Dto,Product_Pricing_Table_Retailer>();
            CreateMap<Product_Pricing_Table_Retailer,Product_Pricing_Table_Retailer_Get_Dto>();

            CreateMap<Product_Pricing_Table_Retailer_Set_Dto,Product_Pricing_Table_Retailer>();
            CreateMap<Product_Pricing_Table_Retailer,Product_Pricing_Table_Retailer_Set_Dto>();
            
            CreateMap<Product_Update_And_List_Dto,Product>();
            CreateMap<Product,Product_Update_And_List_Dto>();

            CreateMap< Product_Details_Dto,Product>();
            CreateMap<Product, Product_Details_Dto>();

            CreateMap<Product_Category_Dto,Product_Category>();
            CreateMap<Product_Category,Product_Category_Dto>();
            
        }
    }
}