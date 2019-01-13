
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business_Layer.Identity;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
using Infrastructure.Communication.EmailSendgrid;
using Infrastructure.Communication.OrangeSMS;
using Infrastructure.Helpers;
/* using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Helpers;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository;
using LastMiles.API.Repositories_UnitOfWork.UnitOfWorks; */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LastMiles.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
         private readonly ILogger<AuthController>  _logger;
        private readonly IEmail _email;
        private readonly IOrangeSMSProvider _orangesms;
        private readonly IUnitOfWork_ReferenceData _uow_Reference_Data;
        private readonly IAuthentication _authentication;

        public AuthController(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager,
                              IMapper mapper, ILogger<AuthController> logger,
                              IEmail email,IOrangeSMSProvider orangesms,
                              IUnitOfWork_ReferenceData uow_reference_data,
                              IAuthentication authentication
                              )
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _config =config;
            _logger = logger;
            _email = email;
            _orangesms = orangesms;
            _uow_Reference_Data = uow_reference_data;
            _authentication = authentication;
        }

   

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody]User_For_Login_Dto userForLoginDto)
        {
            var login = await _authentication.login_user(userForLoginDto);

            if(login==null)
            return NotFound();
            else
            return Ok(login); 

        }
    
        [AllowAnonymous] // this should be access only by admin type of user
        [HttpPost("RegisterUser")]
        public  async Task<IActionResult> RegisterUser ([FromBody]User_For_Registration_Dto userForRegistrationDto)
        {
         
          dynamic result = await _authentication.register_user(userForRegistrationDto);   
         
          string type = result.GetType().ToString();  

          if(result is IEnumerable<Microsoft.AspNetCore.Identity.IdentityError>)
          return BadRequest(result);
          
          if(result is Message_Dto)
           return BadRequest(result);

          return Ok(result);
        }

         [AllowAnonymous] // this should be access only by admin type of user
        [HttpPost("UpdateUser")]
        public  async Task<IActionResult> UpdateUser ([FromBody]User_For_Registration_Dto userForRegistrationDto)
        {
         
         //this will update all field
          dynamic result = await _authentication.update_user(userForRegistrationDto);   
        
          if(result is null)
          return BadRequest(result);
                   
          return Ok(result); 
        }

    }
}