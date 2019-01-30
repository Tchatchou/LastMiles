using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Product_Management;

namespace Business_Layer.Product_Management
{
    public class Product_Queries : IProduct_Queries
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork_Product_Management _unitOfWork_Product_Management;

        public Product_Queries (IMapper mapper,IUnitOfWork_Product_Management unitOfWork_Product_Management)
        {
            _mapper = mapper;
            _unitOfWork_Product_Management = unitOfWork_Product_Management;
        }

        public async Task<Product_Details_Dto> get_product(int product_id)
        {
             var prod = await _unitOfWork_Product_Management.repo_products
                                 .get_product_with_details(product_id);
                               

            return _mapper.Map<Product_Details_Dto>(prod);
        }

        public async Task<List<Product_Update_And_List_Dto>> get_products(Product_Search_Criteria_Dto search)
        {
            var predicate = PredicateBuilder.True<Product>(); 

           // var query  = Enumerable<Product>();
            IEnumerable<Product> query = new List<Product>();

            if(search.company_id>0) 
            predicate.And(p=>  p.company_id==search.company_id);

            if(search.product_Category_id>0)
            predicate = predicate.And(p=>  p.product_Category_id==search.product_Category_id);
            
            if(search.product_Category_id>0)
            predicate = predicate.And(p=>  p.product_Category_id==search.product_Category_id);

            if(!string.IsNullOrEmpty(search.product_code))
            predicate = predicate.And(p=>  p.product_code.ToLower().Contains(search.product_code));

            if(!string.IsNullOrEmpty(search.name))
            predicate = predicate.And(p=>  p.name.ToLower().Contains(search.name));

             query = await _unitOfWork_Product_Management.repo_products.Find(predicate); 

            return _mapper.Map<List<Product_Update_And_List_Dto>>(query);
        }
    }
}