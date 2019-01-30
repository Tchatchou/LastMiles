using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Product_Management
{
    public interface IProduct_Queries
    {
      Task<List<Product_Update_And_List_Dto>> get_products(Product_Search_Criteria_Dto search);

      Task<Product_Details_Dto> get_product(int product_id);

      // ==> create a method to get the list of product with special pricing (if not special pricing apply standard pricing)
      // the method shoudld perfom this task per for a given ditributor, or retails 
    }
}