using System.Collections.Generic;
using System.Threading.Tasks;
using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Repositories_UnitOfWork.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LastMiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork_ReferenceData _unitOfWork_ReferenceData;
        private readonly DataContext _context;
        public ReferenceDataController(DataContext context, 
                                       ILogger<ReferenceDataController> logger, 
                                       UserManager<User> userManager,
                                        RoleManager<Role> roleManager,
                                       IUnitOfWork_ReferenceData  unitOfWork_ReferenceData)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork_ReferenceData = unitOfWork_ReferenceData;
        }
      
        [HttpGet("GetCompanyType")]
        public IActionResult GetCompanyType()
        {
            var type =_unitOfWork_ReferenceData.companies_type.GetAll();

            return Ok(type);
        }

         [HttpGet("GetRetailerType")]
        public IActionResult GetRetailerType()
        {
            var type = _unitOfWork_ReferenceData.retailers_type.GetAll();

            return Ok(type);
        }

         [HttpGet("GetDistributorType")]
        public IActionResult GetDistributorType()
        {
            var type = _unitOfWork_ReferenceData.distributors_type.GetAll();

            return Ok(type);
        }

         [Authorize]
         [HttpGet("GetRoleCanCreate")]
        public IActionResult GetRoleCanCreate()
        {
            var user = this._userManager.FindByNameAsync(User.Identity.Name).Result ;

            var roles = _userManager.GetRolesAsync(user).Result;

            List<Available_Role_Dto> role_can_create = new List<Available_Role_Dto>();

            foreach(var r in roles)
            {
              var role_id= _roleManager.FindByNameAsync(r).Result.Id;              
              
                role_can_create.AddRange(_unitOfWork_ReferenceData.role.Get_Role_Can_Create(role_id));            
            }                   
            return Ok(role_can_create);
        }


    }
}
