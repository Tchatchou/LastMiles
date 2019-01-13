using System.Collections.Generic;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base.DB_Identity_Management;

namespace Data_Access_Layer.Repositories.Identity_Repository
{
    public interface IDistributor_Repository : IRepository<Distributor>
    {        
        List<Distributor> search_distributors_without_loading_details(int? company_id, string distributorName);
        Distributor get_distributor_with_details(int distributor_id);
        void update_distributor(Distributor distributor);
    }
}