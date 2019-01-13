using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Identity
{
    public interface IAccount_Creation
    {
        void create_new_company(Company_For_Registration_Dto companyForRegistrationDto);       

        void  create_new_Distributor(Distributor_For_Registration_Dto distributor, ClaimsPrincipal user,int entity_id_to_Map_User);

        void  add_distributor_to_a_company(int company_id, int distributor_id);

        void  remove_distributor_to_a_company(int company_id, int distributor_id);

        void  create_new_Retailer(Retailer_For_Registration_Dto retailer);      
    }   
}