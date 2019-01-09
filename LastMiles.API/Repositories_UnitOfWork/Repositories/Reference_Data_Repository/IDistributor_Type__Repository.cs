using LastMiles.API.DataBase;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Base_Repository;

namespace LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository
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