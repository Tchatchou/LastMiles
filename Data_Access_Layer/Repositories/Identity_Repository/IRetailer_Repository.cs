using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories.Identity_Repository
{

    public interface IRetailer_Repository : IRepository<Retailer>

    {
        List<Retailer> Get_Retailers(string company);
        Retailer Get_Retailers_WithDetails(int retailer);
    }

    public class Retailer_Repository : Repository<Retailer>,IRetailer_Repository
    {
        public Retailer_Repository(DataContext context) : base(context)
        {
            
        }

        public List<Retailer> Get_Retailers(string retailer)
        {
             var result = new List<Retailer>();
          
          if(string.IsNullOrEmpty(retailer))
                 result= _context.Retailers.ToListAsync().Result;
            else
               result= _context.Retailers.Where(x=>x.name.Contains(retailer)).ToListAsync().Result;

            return result;
        }

        public Retailer Get_Retailers_WithDetails(int retailer_id)
        {
           return  _context.Retailers
                          .Include(x=>x.retailer_type)
                          .Include(x=>x.list_retailer_disponibility)                         
                              
                          .FirstOrDefaultAsync(x=>x.retailer_id==retailer_id)   
                          .Result;    
        }
    }
}