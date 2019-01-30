using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Product_Management;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Product_Repository
{
    public class Product_Repository :Repository<Product>,IProduct_Repository
    {    
        public Product_Repository(DataContext context) : base(context){}


        public async Task<Product> get_product_with_details(int product_id)
        {
          return await  _context.Products
                                .Include(p => p.list_product_with_special_pricing_distributor)
                                .Include(p => p.list_product_with_special_pricing_retailer)
                                .Include(p => p.product_Category)
                                .Where(pr=>pr.product_id ==product_id)
                                .FirstOrDefaultAsync();                               
                                
        }
    }
}