

using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;

namespace Data_Access_Layer.Repositories.Reference_Data_Repository
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