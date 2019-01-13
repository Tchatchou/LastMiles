using System.Collections.Generic;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base.DB_Identity_Management;

namespace Data_Access_Layer.Repositories.Identity_Repository
{     public interface ICompany_Repository :IRepository<Company> 
    {
        void add_distributor_to_a_company(int company, int distributor);

        void remove_distributor_to_a_company(int company, int distributor);
        
        List<Company> search_company_and_load_details_along (string company);
    }

}