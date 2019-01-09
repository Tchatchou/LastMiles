using System.Security.Claims;
using System.Threading.Tasks;
using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.BusinessLogic.Identity;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
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
        private readonly UserManager<User> _userManager;

        public AccountController(ILogger<AccountController> logger,
                                 IAccount_Creation account_Creation,
                                UserManager<User> userManager)
        {           
            _logger = logger;
            _account_Creation = account_Creation;
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
           var result = _account_Creation.search_company_withDetails(company);
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
            var distributro = _account_Creation.Search_Distributors(company_id,distributorName);
            
            return Ok(distributro);
        }

        [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpGet("GetDistributorDetails/{distributor_id}")]
         public async Task<IActionResult> GetDistributorDetails(int distributor_id)
        {  
            var distributro = _account_Creation.Distributor_Details(distributor_id);
            
            return Ok(distributro);
        }

         [Authorize(Roles="SuperAdmin,Admin,CompanyAdmin")]
        [HttpPost("UpdateDistributor")]
        public async Task<IActionResult> UpdateDistributor([FromBody] Distributor_For_Registration_Dto distributor)
        {        
         
           _account_Creation.Update_Distributor(distributor);
            
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

            var response =  _account_Creation.Get_Retailers(retailer);
            return Ok(response);
        }

        [Authorize(Roles="SuperAdmin,Admin")]
        [HttpGet("GetRetailerDetails/{retailer_id}")]
        public IActionResult GetRetailerDetails(int retailer_id)
        {

            var response =  _account_Creation.Get_Retailers_WithDetails(retailer_id);
            return Ok(response);
        }


    }
}
