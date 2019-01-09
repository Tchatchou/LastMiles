using System.Collections.Generic;
using System.Linq;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Base_Repository;
using Microsoft.EntityFrameworkCore;

namespace LastMiles.API.Repositories_UnitOfWork.Repositories.Identity_Repository
{

    public interface IDistributor_Repository : IRepository<Distributor>

    {
        
        List<Distributor> Search_Distributors(int? company_id, string distributorName);
        Distributor Distributor_Details(int distributor_id);
        void Update_Distributor(Distributor distributor);
    }

    public class Distributor_Repository : Repository<Distributor>,IDistributor_Repository
    {
      
        public Distributor_Repository(DataContext context) : base(context)
        {
         
        }

        public Distributor Distributor_Details(int distributor_id)
        {
          return  _context.Distributors
                          .Include(x=>x.distributor_type)
                          .FirstOrDefaultAsync(x=>x.distributor_id==distributor_id)   
                          .Result;                            
                               
        }

        public List<Distributor> Search_Distributors(int? company_id, string distributorName)
        {
          var result = new List<Distributor>();
          
          var query = _context.Distributors;
                               
        // search when Admin
          if(company_id == null)
          {
              if(!string.IsNullOrEmpty(distributorName))
                 result= query.Where(x=>x.name.Contains(distributorName)).ToListAsync().Result;
              else
                 result = query.ToListAsync().Result;
          }
          else
          {
              if(!string.IsNullOrEmpty(distributorName))
                  result= query.Where(x=>x.name.Contains(distributorName)).ToListAsync().Result;
              else
                 result = query.ToListAsync().Result;
          }
         
            return result;
        }

        public void Update_Distributor(Distributor distributor)
        {            
             _context.Distributors.Update(distributor);
        }
    }
}