using LastMiles.API.DataBase;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Base_Repository;

namespace LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository
{
    public interface ICompany_Type_Repository:IRepository<Company_Type>                                   
                                          
    {
        
    }

    public class Company_Type_Repository : Repository<Company_Type>,ICompany_Type_Repository
    {
        public Company_Type_Repository(DataContext context) : base(context)
        {
        }
    }
}