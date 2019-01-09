using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Data_Base.DB_Identity_Management
{
    public class User : IdentityUser <int>
    {        
        public ICollection<User_Role> UserRoles { get; set; }

        [Required] 
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }  

        public DateTime Created { get; set; }
        
        public DateTime ? LastActive { get; set; }

         [Required]
        public int EntityUserMapTo_Id { get; set; } // key id,      id =0 means user is admin.supe admin
        [Required]
        public string EntityUserMapTo_Name { get; set; } // nestle , soticam etc..
        [Required]
        public string EntityUserMapTo_Type { get; set; } // retailer, comapany etc.
        [Required]
        public string UserAccessingEntityWithPermissions {get;set;}
    }
}