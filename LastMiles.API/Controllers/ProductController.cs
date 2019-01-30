using System.Threading.Tasks;
using Business_Layer.Product_Management;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LastMiles.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct_Creation_Update _product_Creation_Update;
        private readonly IProduct_Queries _product_Queries;

        public ProductController(IProduct_Creation_Update product_Creation_Update,
                                 IProduct_Queries product_Queries)
        {
            _product_Creation_Update = product_Creation_Update;
            _product_Queries = product_Queries;
        }
        
        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Product_Registration_Dto product_Registration_Dto)
        {
           await  _product_Creation_Update.add_new_product_to_company(product_Registration_Dto);
           return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product_Update_And_List_Dto product_Update_Dto)
        {
           await  _product_Creation_Update.update_product(product_Update_Dto);

           return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("SetProductSpecialPricingForDistributeur")]
        public async Task<IActionResult> SetProductSpecialPricingForDistributeur([FromBody] Product_Pricing_Table_Distributor_Set_Dto speciale_pricing_distributor)
        {
           await  _product_Creation_Update.set_product_special_pricing_for_distributeur(speciale_pricing_distributor);

           return Ok();
        }

          [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("SetProductSpecialPricingForRetailer")]
        public async Task<IActionResult> SetProductSpecialPricingForRetailer([FromBody] Product_Pricing_Table_Retailer_Set_Dto special_pricing_retailer)
        {
           await  _product_Creation_Update.set_product_special_pricing_for_retailer(special_pricing_retailer);

           return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpGet("GetProduct/{product_id}")]
        public async Task<IActionResult> GetProduct(int product_id)
        {
          var prod =  await  _product_Queries.get_product(product_id);

           return Ok(prod);
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] Product_Search_Criteria_Dto search)
        {
           var prods = await  _product_Queries.get_products(search);

           return Ok(prods);
        }

        
    }
    
}