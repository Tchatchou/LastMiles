
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Helpers;
using LastMiles.API.Repositories_UnitOfWork.Repositories.Reference_Data_Repository;
using LastMiles.API.Repositories_UnitOfWork.UnitOfWorks;
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

        public AuthController(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager,
                              IMapper mapper, ILogger<AuthController> logger,
                              IEmail email,IOrangeSMSProvider orangesms,
                              IUnitOfWork_ReferenceData uow_reference_data
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
           
        }

   

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody]User_For_Login_Dto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.UserName);

            if (user == null)
                return NotFound(new Message_Dto{message_en = "username or password incorrect",message_fr = "incorrect username/mot de passe"});

            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded)
            {
                // here you can configure the data to attach to the logged user in a 
                // variable like appuser (refer to video udemy section identity==>updating login)
               //  in the code just below we go look for the user and include his photos
               // var appUser = await _userManager.Users
               //                     .Include(p => p.Photos)
               //                     .FirstOrDefaultAsync( u => u.NormalizedUserName == userForLoginDto.UserName.ToUpper);
  
                try {
                    var userRoles = new List<string> ();
    
                    var token = JwtTokenGenerationHelper.token(user,_config,_userManager, userRoles).Result;
                    
                    var userToReturn = _mapper.Map<User_For_Registration_Dto>(user);

                    if(user.UserRoles!=null)
                    userToReturn.Roles = (from r in user.UserRoles select new Role_Dto {role_id= r.Role.Id, role_name = r.Role.Name}).ToList();
    
    
                    if(!userRoles.Contains("SuperAdmin"))
                         if(!userRoles.Contains("Admin"))
                            userToReturn.permission =JsonConvert.DeserializeObject<List<Permission_Dto>>(user.UserAccessingEntityWithPermissions);
                    
                    return Ok(new
                    {
                        token =token,
                        user  = userToReturn
                    });
                } catch (Exception ex) {
                  _logger.LogError(ex.Message);
                }
            }

            return Unauthorized();

        }
    
        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public  async Task<IActionResult> RegisterUser ([FromBody]User_For_Registration_Dto userForRegistrationDto)
        {
           
            var userToCreate =  _mapper.Map<User>(userForRegistrationDto);

            List<int> role_ids_user_is_tobeset_with_defauld_permission = new List<int>();

            if(userForRegistrationDto.Roles.Count()==0)
              return BadRequest(new Message_Dto { message_en ="User need to be assigned to at least one role / profile ",
                                                 message_fr = "Utilisateur avoir au moins un role valide"});

            foreach(var r in userForRegistrationDto.Roles)
            {
                  role_ids_user_is_tobeset_with_defauld_permission.Add(r.role_id);

                  if(!_roleManager.RoleExistsAsync(r.role_name).Result)
                            return BadRequest(new Message_Dto { message_en  ="Role does'not exist ",
                                                                message_fr = "Role n'existe pas"});
            }
                   
           // set default permission
           var default_permision =_uow_Reference_Data.role.Get_Roles_With_Default_Permisions(role_ids_user_is_tobeset_with_defauld_permission);

           default_permision.ForEach(e=>e.isSelected = true);

           userToCreate.UserAccessingEntityWithPermissions =JsonConvert.SerializeObject(default_permision);           
           userToCreate.EntityUserMapTo_Id = userForRegistrationDto.EntityUserMapTo.entity_id;
           userToCreate.EntityUserMapTo_Name = userForRegistrationDto.EntityUserMapTo.entity_name;
           userToCreate.EntityUserMapTo_Type = userForRegistrationDto.EntityUserMapTo.entity_type;



           var result1 = await _userManager.CreateAsync(userToCreate, userForRegistrationDto.Password);
           var result2 = await _userManager.AddToRolesAsync(userToCreate,userForRegistrationDto.Roles.Select(r=>r.role_name));

           var userToReturn = _mapper.Map<User_For_Registration_Dto>(userToCreate);

               userToReturn.Roles = userForRegistrationDto.Roles;

            if(result1.Succeeded)
            {
               if(result2.Succeeded)
               {

                    _email.sendWelcomeEmailSendgrid(userForRegistrationDto.Email,userForRegistrationDto.FirstName,
                    new WelcomeEmail {
                        name=userForRegistrationDto.FirstName + " " +userForRegistrationDto.LastName,
                        username=userForRegistrationDto.Username,
                        password=userForRegistrationDto.Password,
                        customerServiceEmail=_config.GetSection("Sendgrid:customerServiceEmail").Value,
                        customerServiceNumber=_config.GetSection("Sendgrid:customerServiceNumber").Value
                    }
                    );

                    // if role is retails send email ==> to be study as a way to limit sms usage
                    _orangesms.send_SMS(userForRegistrationDto.PhoneNumber,"Votre compte a ete creer avec pour nom utilisateur :"+
                    userForRegistrationDto.Username + "et password :"+ userForRegistrationDto.Password +"Bien vouloir telecharger l'application ");
                     
                     return Ok(userToReturn); 
               }
                else  
                     return  BadRequest(result2.Errors);        
            }
            else
                 return  BadRequest(result1.Errors);

        }

    }
}