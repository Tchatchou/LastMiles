using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories.Identity_Repository
{
    public interface ICompany_Repository :IRepository<Company> 
    {
        void Add_Distributor(int company, int distributor);

        List<Company> Search_Company_WithDetails (string company);
    }

    public class Company_Repository : Repository<Company>,ICompany_Repository
    {    

        public Company_Repository(DataContext context) : base(context)
        {
            
        }

        public void Add_Distributor(int company, int distributor)
        {
          _context.Add(new Distributor_Company {company_id = company, distributor_id = distributor});          
        }

        public List<Company> Search_Company_WithDetails(string company)
        {
          var result = new List<Company>();
          
          if(string.IsNullOrEmpty(company))
                 result= _context.Companies.Include(x=>x.contacts)
                               .Include(x=>x.company_Type).ToListAsync().Result;
            else
               result= _context.Companies.Include(x=>x.contacts)
                               .Include(x=>x.company_Type)
                               .Where(x=>x.name.Contains(company)).ToListAsync().Result;
            return result;
        }

    }

}