using System.Collections.Generic;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base.DB_Identity_Management;

namespace Data_Access_Layer.Repositories.Identity_Repository
{   
    public interface IRetailer_Repository : IRepository<Retailer>
    {
        List<Retailer> search_retailers_without_loading_details(string company);
        Retailer get_retailer_with_details(int retailer);
    }
}