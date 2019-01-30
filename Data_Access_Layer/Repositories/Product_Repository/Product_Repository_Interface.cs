using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Product_Management;

namespace Data_Access_Layer.Repositories.Product_Repository
{
    public interface IProduct_Repository : IRepository<Product>
    {
       Task<Product> get_product_with_details(int product_id);
    }
}