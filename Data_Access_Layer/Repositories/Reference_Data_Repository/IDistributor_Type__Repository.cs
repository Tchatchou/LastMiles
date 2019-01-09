
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;

namespace Data_Access_Layer.Repositories.Reference_Data_Repository
{
    public interface IDistributor_Type_Repository:IRepository<Distributor_Type>                                   
                                          
    {
        
    }

    public class Distributor_Type_Repository : Repository<Distributor_Type>,IDistributor_Type_Repository
    {
        public Distributor_Type_Repository(DataContext context) : base(context)
        {
        }
    }
}