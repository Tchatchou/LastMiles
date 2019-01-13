using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
using Infrastructure.Communication.EmailSendgrid;
using Infrastructure.Communication.OrangeSMS;
using Infrastructure.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business_Layer.Identity
{
    public class Authentication : IAuthentication
    {        
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<Authentication>  _logger;
        private readonly IEmail _email;
        private readonly IOrangeSMSProvider _orangesms;
        private readonly IUnitOfWork_ReferenceData _uow_Reference_Data;



        public Authentication(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager,
                              IMapper mapper, ILogger<Authentication> logger,
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

        public async Task<User_Logged_Dto> login_user(User_For_Login_Dto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.UserName);

            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded)
            {
                // here you can configure the data to attach to the logged user in a 
                // variable like appuser (refer to video udemy section identity==>updating login)
               //  in the code just below we go look for the user and include his photos
               // var appUser = await _userManager.Users
               //                     .Include(p => p.Photos)
               //                     .FirstOrDefaultAsync( u => u.NormalizedUserName == userForLoginDto.UserName.ToUpper);
                 
                    var userRoles = new List<string> ();
    
                    var token = JwtTokenGenerationHelper.token(user,_config,_userManager, userRoles).Result;
                    
                    var userToReturn = _mapper.Map<User_For_Registration_Dto>(user);

                    if(user.UserRoles!=null)
                    userToReturn.Roles = (from r in user.UserRoles select new Role_Dto {role_id= r.Role.Id, role_name = r.Role.Name}).ToList();
    
    
                    if(!userRoles.Contains("SuperAdmin"))
                         if(!userRoles.Contains("Admin"))
                            userToReturn.permission =JsonConvert.DeserializeObject<List<Permission_Dto>>(user.UserAccessingEntityWithPermissions);
                    
                    return new User_Logged_Dto()
                    {
                        token =token,
                        user  = userToReturn
                    };
            
            }
        
            return null;
        }

        public async Task<dynamic> register_user(User_For_Registration_Dto userForRegistrationDto)
        {
             var userToCreate =  _mapper.Map<User>(userForRegistrationDto);

            List<int> role_ids_user_is_tobeset_with_defauld_permission = new List<int>();

            if(userForRegistrationDto.Roles.Count()==0)
              return new  Message_Dto { message_en ="User need to be assigned to at least one role / profile ", 
                                        message_fr = "Utilisateur avoir au moins un role valide"};

            foreach(var r in userForRegistrationDto.Roles)
            {
                  role_ids_user_is_tobeset_with_defauld_permission.Add(r.role_id);

                  if(!_roleManager.RoleExistsAsync(r.role_name).Result)
                            return new Message_Dto { message_en  ="Role does'not exist ",
                                                                message_fr = "Role n'existe pas"};
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

                    try {
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
                         
                    } catch (Exception ex) {
                        _logger.LogError("Communication error "+userForRegistrationDto.Email 
                                                               +userForRegistrationDto.FirstName 
                                                               +userForRegistrationDto.PhoneNumber
                                                               + "---"+ex.Message);
                    }
                     return userToReturn; 
               }
                else  
                     return  result2.Errors;        
            }
            else
                 return  result1.Errors;
        }

        public async Task<User_For_Registration_Dto> update_user(User_For_Registration_Dto userForRegistrationDto)
        {
            var user =await _userManager.FindByNameAsync(userForRegistrationDto.Username);

            if(user==null)
                return null;
            
            var userUpdate = _mapper.Map<User>(userForRegistrationDto);

            await _userManager.UpdateAsync(userUpdate);

            return userForRegistrationDto;
        }
    }
}