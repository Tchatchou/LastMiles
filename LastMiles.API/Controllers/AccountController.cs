using System.Security.Claims;
using System.Threading.Tasks;
using Business_Layer.Identity;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
/* using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.BusinessLogic.Identity;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject; */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LastMiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ILogger _logger;
        private  IAccount_Creation _account_Creation;
        private readonly IAccount_Queries _account_Queries;
        private readonly IAccount_Update _account_Update;
        private readonly UserManager<User> _userManager;

        public AccountController(ILogger<AccountController> logger,
                                 IAccount_Creation account_Creation,
                                 IAccount_Queries account_Queries,
                                 IAccount_Update account_Update,
                                UserManager<User> userManager)
        {           
            _logger = logger;
            _account_Creation = account_Creation;
            _account_Queries = account_Queries;
            _account_Update = account_Update;
            _userManager = userManager;
        }


        [Authorize(Roles="SuperAdmin,Admin")]
        [HttpPost("CreateCompany")]
        public IActionResult CreateCompany([FromBody] Company_For_Registration_Dto company)
        {
            _account_Creation.create_new_company(company);
            return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin")]
        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies([FromQuery] string company)
        {
           var result = _account_Queries.search_company_and_load_details_along(company);
            return Ok(result);
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("CreateDistributor/{company_id}")]
        public async Task<IActionResult> CreateDistributor(int company_id,[FromBody] Distributor_For_Registration_Dto distributor)
        {  
            _account_Creation.create_new_Distributor(distributor, User,company_id);
            
            return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpGet("GetDistributors/{company_id}/{distributorName}")]
        public async Task<IActionResult> GetDistributors(int? company_id,string distributorName)
        {  
            var distributro = _account_Queries.search_distributors_without_loading_details(company_id,distributorName);
            
            return Ok(distributro);
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpGet("GetDistributorDetails/{distributor_id}")]
         public async Task<IActionResult> GetDistributorDetails(int distributor_id)
        {  
            var distributro = _account_Queries.get_distributor_with_details(distributor_id);
            
            return Ok(distributro);
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("AddDistributorToCompany/{company_id}/{distributor_id}")]
        public async Task<IActionResult> AddDistributorToCompany(int company_id,int distributor_id)
        {        
         
           _account_Creation.add_distributor_to_a_company(company_id,distributor_id);
            
            return Ok();
        }


        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("RemoveDistributorToCompany/{company_id}/{distributor_id}")]
        public async Task<IActionResult> RemoveDistributorToCompany(int company_id,int distributor_id)
        {        
         
           _account_Creation.remove_distributor_to_a_company(company_id,distributor_id);
            
            return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("UpdateDistributor")]
        public async Task<IActionResult> UpdateDistributor([FromBody] Distributor_For_Registration_Dto distributor)
        {        
         
           _account_Update.update_distributor(distributor);
            
            return Ok();
        }

        [Authorize(Roles="SuperAdmin,Admin")]
        [HttpPost("CreateRetailer")]
        public IActionResult CreateRetailer([FromBody] Retailer_For_Registration_Dto retailer)
        {
            _account_Creation.create_new_Retailer(retailer);
            return Ok();
        }
     
        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin,DistributorAdmin")]
        [HttpGet("GetRetailers")]
        public IActionResult GetRetailers([FromQuery]string retailer)
        {

            var response =  _account_Queries .search_retailers_without_loading_details(retailer);
            return Ok(response);
        }

        [Authorize(Roles="SuperAdmin,Admin")]
        [HttpGet("GetRetailerDetails/{retailer_id}")]
        public IActionResult GetRetailerDetails(int retailer_id)
        {

            var response =  _account_Queries.get_retailer_with_details(retailer_id);
            return Ok(response);
        }


    }
}
