using System.Threading.Tasks;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
using Infrastructure.Communication.EmailSendgrid;
using Infrastructure.Communication.OrangeSMS;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business_Layer.Identity
{
    public class User_Management : IUser_Management
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<User_Management>  _logger;
        private readonly IEmail _email;
        private readonly IOrangeSMSProvider _orangesms;
        private readonly IUnitOfWork_ReferenceData _uow_Reference_Data;

         public User_Management(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager,
                              IMapper mapper, ILogger<User_Management> logger,
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

        public async Task<User_For_Registration_Dto> get_user(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if(user == null)
             return null;
            
            var userToReturn = _mapper.Map<User_For_Registration_Dto>(user);

            foreach(var role in user.UserRoles)
                userToReturn.Roles.Add(new Role_Dto {role_id = role.Role.Id, role_name = role.Role.Name});

            return userToReturn;
        }

        public List<User_For_Registration_Dto> get_users_for_an_entity(int entity_id, string entity_type)
        {
            var list_user =  _userManager.Users.Where(u => u.EntityUserMapTo_Id==entity_id
                                                                && u.EntityUserMapTo_Type.ToUpper()== entity_type.ToUpper())
                                                            .ToList();
            
            return  _mapper.Map<List<User_For_Registration_Dto>>(list_user);
        }

        public async Task<dynamic> change_user_password(Change_Password_Dto changePasswordDto,string userId)
        {            

            var user =await _userManager.FindByIdAsync(userId);

            if (user ==null )
                return null;

            var result  = await _userManager.ChangePasswordAsync(user,changePasswordDto.CurrentPassword,changePasswordDto.NewPassword);
               
             if (result.Succeeded)
            {
                return  new Message_Dto {message_en = "Password Change",message_fr = "mot de passe change"};      
            }
              return result.Errors;            

        }
        
        public async Task<Message_Dto> reset_user_access(string UserName)
        {
            var user =await _userManager.FindByNameAsync(UserName);
               
             if (user ==null )
                return null;

             if ( await _userManager.HasPasswordAsync(user))
                {
                    try {
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
                         
                         return new Message_Dto {message_en = "User is reset ", message_fr="Utilisateur est reconfigure"};
                    
                    } catch (Exception ex) {
                       _logger.LogError("Communication error issue sending reset message notification" + ex.Message);
                    }
                }

            return null;
        }
        
        public async Task<Message_Dto> lock_user(string UserName)
        {
             var user =await _userManager.FindByNameAsync(UserName);          
              
             if (user ==null )
                return null;

                var lockoutEndDate = new DateTime(2999,01,01);
                await _userManager.SetLockoutEnabledAsync(user,true);
                await  _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

                return new Message_Dto {message_en = "User is lock", message_fr="Utilisateur est bloque"};

        }
       
        public async Task<Message_Dto> unlock_user(string UserName)
        {
             var user =await _userManager.FindByNameAsync(UserName);
               
             if (user ==null )
                return null;

                var lockoutEndDate = DateTime.Now;
                await _userManager.SetLockoutEnabledAsync(user,true);
                await  _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

                return new Message_Dto {message_en = "User is unlock", message_fr="Utilisateur est debloque"};

        }
        public async Task update_user_permission(string userId,List<Permission_Dto> permissions)
        {
           var user =await _userManager.FindByIdAsync(userId);

            permissions.ForEach(e=>e.isSelected = true);

            user.UserAccessingEntityWithPermissions =JsonConvert.SerializeObject(permissions); 

           await  _userManager.UpdateAsync(user);        
        }
    }
}