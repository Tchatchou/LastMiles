

using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;

namespace Data_Access_Layer.Repositories.Reference_Data_Repository
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