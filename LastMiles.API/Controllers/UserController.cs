
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Helpers;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        private RoleManager<Role> _roleManager { get; }
        public IRole_Permission_Repository _role_Permission_Repository { get; }

        public UserController(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager,
                              IMapper mapper,
                              ILogger<UserController> logger,
                              IConfiguration config,
                              IEmail email, IOrangeSMSProvider orangesms,
                              IRole_Permission_Repository role_Permission_Repository                              
                              )
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
            _config = config;
            _email = email;
            _orangesms = orangesms;
            _role_Permission_Repository = role_Permission_Repository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if(user == null)
             return NotFound(new{ message = "User not found"});
            
            var userToReturn = _mapper.Map<User_For_Registration_Dto>(user);

            foreach(var role in user.UserRoles)
                userToReturn.Roles.Add(new Role_Dto {role_id = role.Role.Id, role_name = role.Role.Name});

            return Ok(userToReturn);
            
        }

       /*  [HttpGet("GetUserByRole")]
        public async Task<IActionResult> GetUserByRole(List<string> roles)
        {
            return Ok();            
        } */

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]Change_Password_Dto changePasswordDto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user =await _userManager.FindByIdAsync(userId);

            if (user ==null )
                return BadRequest(new { error ="User do not exist "});

            var result  = await _userManager.ChangePasswordAsync(user,changePasswordDto.CurrentPassword,changePasswordDto.NewPassword);
               
             if (result.Succeeded)
            {
                return Ok( new Message_Dto {message_en = "Password Change",message_fr = "mot de passe change"});      
            }
              return NotFound ( new Message_Dto {message_en = "Invalid password ",message_fr = "mot de pass invalide"});            

        }

        [AllowAnonymous]
        [HttpPost("ResetUser")] // same as forgot password        
        public async Task<IActionResult> ResetUser(string UserName)
        {
            //http://aryalnishan.com.np/asp-net-mvc/solved-reset-user-password-using-usermanager-asp-net-identity/
               
             var user =await _userManager.FindByNameAsync(UserName);
               
             if (user ==null )
                return BadRequest(new Message_Dto {message_en ="Invalid user",message_fr ="invalide utilisateur"});

                if ( await _userManager.HasPasswordAsync(user))
                {
                    var new_Password = PasswordGeneratorHelper.password();
                     await   _userManager.RemovePasswordAsync(user);
                     await   _userManager.AddPasswordAsync(user,new_Password);
 
                     // send mail or sms to share the new password.
                       _email.sendWelcomeEmailSendgrid(user.Email,user.FirstName,
                    new WelcomeEmail {
                        name=user.FirstName + " " +user.LastName,
                        username=user.UserName,
                        password=new_Password,
                        customerServiceEmail=_config.GetSection("Sendgrid:customerServiceEmail").Value,
                        customerServiceNumber=_config.GetSection("Sendgrid:customerServiceNumber").Value
                    }
                    );


                    // if role is retails send email ==> to be study as a way to limit sms usage
                    _orangesms.send_SMS(user.PhoneNumber,"Votre compte a ete reconfigure avec ce nouveau password :"+ new_Password +"Bien vouloir vous connecter");
                     
                     return Ok(new Message_Dto {message_en = "User is reset ", message_fr="Utilisateur est reconfigure"});
                }


            return Ok(user);

        }
       
        [Authorize(Roles="SuperAdmin,RetailerAdmin,DistributeurAdmin,CompanyAdmin")]
        [HttpPost("LockUser")] 
        public async Task<IActionResult> LockUser(string UserName)
        {
           

            // later check  if the user requesting for unlocking / locking another user is authorizer
            var user =await _userManager.FindByNameAsync(UserName);          
              
             if (user ==null )
                return BadRequest(new { error ="User not found"});

                var lockoutEndDate = new DateTime(2999,01,01);
                await _userManager.SetLockoutEnabledAsync(user,true);
                await  _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

                return Ok(new Message_Dto {message_en = "User is lock", message_fr="Utilisateur est bloque"});

        }

        [Authorize(Roles="SuperAdmin,RetailerAdmin,DistributeurAdmin,CompanyAdmin")]
        [HttpPost("UnLockUser")] 
        public async Task<IActionResult> UnLockUser(string UserName)
        {
            
            var user =await _userManager.FindByNameAsync(UserName);
               
             if (user ==null )
                return BadRequest(new { error ="User not found"});

                var lockoutEndDate = DateTime.Now;
                await _userManager.SetLockoutEnabledAsync(user,true);
                await  _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

                return Ok(new Message_Dto {message_en = "User is unlock", message_fr="Utilisateur est debloque"});

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