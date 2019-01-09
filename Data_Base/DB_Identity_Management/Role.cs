using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Data_Base.DB_Identity_Management
{  public class Role : IdentityRole<int>
    {
        public ICollection<User_Role> UserRoles { get; set; }

        public  ICollection<Role_Permission> list_role_permissions{get;set;}

         public  ICollection<Role_Creation_Possibility> list_role_creation_possibility {get;set;}
    }
}