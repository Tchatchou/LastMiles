using System.Collections.Generic;
using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Identity
{
    public interface IAccount_Queries
    {
        List<Company_For_Details_Dto>  search_company_and_load_details_along(string company );

        
        List<Distributor_For_Details_Dto>  search_distributors_without_loading_details(int? company_id, string distributorName);

        Distributor_For_Details_Dto get_distributor_with_details(int distributor_id);
      
        
        List<Retailer_For_Registration_Dto> search_retailers_without_loading_details(string retailer);     
        
        Retailer_For_Registration_Dto get_retailer_with_details(int retailer);
    
        
    }
}