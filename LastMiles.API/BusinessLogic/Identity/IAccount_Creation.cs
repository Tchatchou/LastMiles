using System.Collections.Generic;
using System.Security.Claims;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Repositories_UnitOfWork.UnitOfWorks;

namespace LastMiles.API.BusinessLogic.Identity
{
    public interface IAccount_Creation
    {
        void  create_new_company(Company_For_Registration_Dto company );

        List<Company_For_Registration_Dto>  search_company_withDetails(string company );

        void create_new_Distributor(Distributor_For_Registration_Dto distributor, ClaimsPrincipal user,int entity_id_to_Map_User);

        void create_new_Retailer(Retailer_For_Registration_Dto retailer);

        List<Distributor_For_Registration_Dto>  Search_Distributors(int? company_id, string distributorName);

        Distributor_For_Registration_Dto Distributor_Details(int distributor_id);

        void Update_Distributor(Distributor_For_Registration_Dto distributor);
        List<Retailer_For_Registration_Dto> Get_Retailers(string retailer);
        Retailer_For_Registration_Dto Get_Retailers_WithDetails(int retailer);
    } 
  
}