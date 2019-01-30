using System;
using System.Threading.Tasks;
using Data_Access_Layer.Repositories.Product_Repository;
using Data_Base;

namespace Data_Access_Layer.UnitOfWorks
{
    public interface IUnitOfWork_Product_Management: IDisposable
    {
        IProduct_Repository repo_products { get; }
        IProduct_Pricing_Table_Distributor_Repository repo_product_pricing_table_distributors { get; }   
        IProduct_Pricing_Table_Retailer_Repository repo_product_pricing_table_retailers { get; }   
      
         Task<int> save();
    }

     public class UnitOfWork_Product_Management : IUnitOfWork_Product_Management
    {
      
        public IProduct_Repository repo_products { get; }   
        public IProduct_Pricing_Table_Distributor_Repository repo_product_pricing_table_distributors { get; }   

        public IProduct_Pricing_Table_Retailer_Repository repo_product_pricing_table_retailers { get; }   
        private readonly DataContext _context;

        public UnitOfWork_Product_Management(DataContext context)
        {
            _context = context;
            repo_products = new Product_Repository(_context);
            repo_product_pricing_table_distributors = new Product_Pricing_Table_Distributor_Repository(_context);
            repo_product_pricing_table_retailers = new Product_Pricing_Table_Retailer_Repository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> save()
        {
            return await  _context.SaveChangesAsync();
        }

    }
}