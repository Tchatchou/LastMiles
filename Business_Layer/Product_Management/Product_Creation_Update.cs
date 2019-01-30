using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Product_Management;

namespace Business_Layer.Product_Management
{
    public class Product_Creation_Update : IProduct_Creation_Update
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork_Product_Management _unitOfWork_Product_Management;

        public Product_Creation_Update (IMapper mapper,IUnitOfWork_Product_Management unitOfWork_Product_Management)
        {
            _mapper = mapper;
            _unitOfWork_Product_Management = unitOfWork_Product_Management;
        }
        public async Task add_new_product_to_company(Product_Registration_Dto product_Registration_Dto)
        {
            var prod = _mapper.Map<Product>(product_Registration_Dto);

            _unitOfWork_Product_Management.repo_products.Add(prod);

            await _unitOfWork_Product_Management.save();
        }
     
        public async Task update_product(Product_Update_And_List_Dto product_Update_And_List_Dto)
        {
             var prod = _mapper.Map<Product>(product_Update_And_List_Dto);

            _unitOfWork_Product_Management.repo_products.Update(prod);

            await _unitOfWork_Product_Management.save();
        }
   
        public async Task set_product_special_pricing_for_distributeur(Product_Pricing_Table_Distributor_Set_Dto special_pricing)
        {
          var price =  _unitOfWork_Product_Management
                        .repo_product_pricing_table_distributors
                        .Find(p=>p.product_id== special_pricing.product_id
                                && p.company_id==special_pricing.company_id
                                && p.distributor_id==special_pricing.distributor_id
                             )
                        .Result.FirstOrDefault();

            if(price == null)
             _unitOfWork_Product_Management
              .repo_product_pricing_table_distributors
              .Add(_mapper.Map<Product_Pricing_Table_Distributor>(special_pricing));
            
            else
            {
               price.agree_unitpricing = special_pricing.agree_unitpricing;
               price.comment = special_pricing.comment;

              _unitOfWork_Product_Management
                .repo_product_pricing_table_distributors.Update(price);
              
            } 

            await  _unitOfWork_Product_Management.save();    
                  
        }

        public async Task set_product_special_pricing_for_retailer(Product_Pricing_Table_Retailer_Set_Dto special_pricing_retailer)
        {
            var price =  _unitOfWork_Product_Management
                        .repo_product_pricing_table_retailers
                        .Find(p=>p.product_id== special_pricing_retailer.product_id
                                && p.retailer_id==special_pricing_retailer.retailer_id
                                && p.distributor_id==special_pricing_retailer.distributor_id
                             )
                        .Result.FirstOrDefault();

            if(price == null)
             _unitOfWork_Product_Management
              .repo_product_pricing_table_retailers
              .Add(_mapper.Map<Product_Pricing_Table_Retailer>(special_pricing_retailer));
            
            else
            {
               price.agree_unitpricing = special_pricing_retailer.agree_unitpricing;
               price.comment = special_pricing_retailer.comment;

              _unitOfWork_Product_Management
                .repo_product_pricing_table_retailers.Update(price);

              await  _unitOfWork_Product_Management.save();
            }     
        }
    }
}