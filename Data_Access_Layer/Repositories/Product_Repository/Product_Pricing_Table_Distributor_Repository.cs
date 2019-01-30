using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Product_Management;

namespace Data_Access_Layer.Repositories.Product_Repository
{
    public class Product_Pricing_Table_Distributor_Repository:Repository<Product_Pricing_Table_Distributor>,IProduct_Pricing_Table_Distributor_Repository
    {    
        public Product_Pricing_Table_Distributor_Repository(DataContext context) : base(context){}  
        
    }
}