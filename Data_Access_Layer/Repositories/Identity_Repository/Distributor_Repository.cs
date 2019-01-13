using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories.Identity_Repository
{    

    public class Distributor_Repository : Repository<Distributor>,IDistributor_Repository
    {      
        public Distributor_Repository(DataContext context) : base(context){}
       
        public Distributor get_distributor_with_details(int distributor_id)
        {
          return  _context.Distributors
                          .Include(x=>x.distributor_type)
                          .FirstOrDefaultAsync(x=>x.distributor_id==distributor_id)   
                          .Result;  
        }

        public List<Distributor> search_distributors_without_loading_details(int? company_id, string distributorName)
        {
          var result = new List<Distributor>();
          
          var query = _context.Distributors;
                               
        // search when Admin
          if(company_id == 0)
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
        public void update_distributor(Distributor distributor)
        {            
             _context.Distributors.Update(distributor);
        }
    }
}