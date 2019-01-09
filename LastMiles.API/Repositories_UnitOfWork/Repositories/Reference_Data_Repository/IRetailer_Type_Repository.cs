using LastMiles.API.DataBase;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Base_Repository;

namespace LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository
{
    public interface IRetailer_Type_Repository:IRepository<Retailer_Type>                                   
                                          
    {
        
    }

    public class Retailer_Type_Repository : Repository<Retailer_Type>,IRetailer_Type_Repository
    {
        public Retailer_Type_Repository(DataContext context) : base(context)
        {
        }
    }
}