
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data_Base.DB_Identity_Management;
using Data_Base.Data_Transfer_Objects;
using Infrastructure.Communication;
using Infrastructure.Helpers;
/* using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Helpers;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository;  */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Infrastructure.Communication.EmailSendgrid;
using Infrastructure.Communication.OrangeSMS;
using Data_Access_Layer.Repositories.Reference_Data_Repository;
using Business_Layer.Identity;

namespace LastMiles.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         private  UserManager<User> _userManager { get; }
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
         private readonly  ILogger<UserController>   _logger;
        private readonly IConfiguration _config;
        private readonly IEmail _email;
        private readonly IOrangeSMSProvider _orangesms;
        private readonly IUser_Management _user_Management;

        private RoleManager<Role> _roleManager { get; }
        public IRole_Permission_Repository _role_Permission_Repository { get; }

        public UserController(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager,
                              IMapper mapper,
                              ILogger<UserController> logger,
                              IConfiguration config,
                              IEmail email, IOrangeSMSProvider orangesms,
                              IRole_Permission_Repository role_Permission_Repository ,   
                              IUser_Management user_Management                          
                              )
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
            _config = config;
            _email = email;
            _orangesms = orangesms;
            _role_Permission_Repository = role_Permission_Repository;
            _user_Management = user_Management;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string UserName)
        {
          var result =await _user_Management.get_user(UserName);
            
          if(result is null)
          return NotFound();  

          return Ok(result);
        }

         [HttpGet("GetUsersForAnEntity")]
        public async Task<IActionResult> GetUsersForAnEntity(int entity_id, string entity_type)
        {
            var result =  _user_Management.get_users_for_an_entity(entity_id,entity_type);   

            return Ok(result);     
        } 

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]Change_Password_Dto changePasswordDto)
        {
          var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

          dynamic result =await _user_Management.change_user_password(changePasswordDto,userId);

          if(result is IEnumerable<Microsoft.AspNetCore.Identity.IdentityError>)
          return BadRequest(result);
          
          if(result is null)
           return BadRequest(result);

          return Ok(result);
           
        }

        [AllowAnonymous]
        [HttpPost("ResetUser")] // same as forgot password        
        public async Task<IActionResult> ResetUser(string UserName)
        {
            //http://aryalnishan.com.np/asp-net-mvc/solved-reset-user-password-using-usermanager-asp-net-identity/
               
            var result =await _user_Management.reset_user_access(UserName);
            
           if(result is null)
              return BadRequest();  

             return Ok(result);
        }
       
        [Authorize(Roles="SuperAdmin,RetailerAdmin,DistributeurAdmin,CompanyAdmin")]
        [HttpPost("LockUser")] 
        public async Task<IActionResult> LockUser(string UserName)
        {
            // later check  if the user requesting for unlocking / locking another user is authorizer
            var result =await _user_Management.lock_user(UserName);
            
           if(result is null)
              return BadRequest();  

             return Ok(result);
        }

        [Authorize(Roles="SuperAdmin,RetailerAdmin,DistributeurAdmin,CompanyAdmin")]
        [HttpPost("UnLockUser")] 
        public async Task<IActionResult> UnLockUser(string UserName)
        {
            var result =await _user_Management.unlock_user(UserName);
            
           if(result is null)
              return BadRequest();  

             return Ok(result);

        }

        [Authorize(Roles="SuperAdmin,RetailerAdmin,DistributeurAdmin,CompanyAdmin")]
        [HttpPost("UpdateUserPermissions")] 
        public async Task<IActionResult> UpdateUserPermissions(string userName, [FromBody] List<Permission_Dto> permission_Dto)
        {  
             _role_Permission_Repository.Set_Permission_Of_User(userName,_userManager,permission_Dto);

             return Ok();
        }
   
   
   
    }
}