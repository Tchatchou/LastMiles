using System.Collections.Generic;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
using Microsoft.AspNetCore.Identity;

namespace Data_Access_Layer.Repositories.Reference_Data_Repository
{  
    public interface IRole_Permission_Repository
    {
          List<Available_Role_Dto>  Get_Role_Can_Create(int role);

            // by default user has all the permission that a role has (Get_Roles_With_Default_Permisions)
          List<Permission_Dto> Get_Roles_With_Default_Permisions(List<int> role_ids);

          List<Permission_Dto> Get_Permission_Of_User(string userName, UserManager<User> userManager);

          void Set_Permission_Of_User(string userName, UserManager<User> userManager, List<Permission_Dto> permission_Dtos);

    }
}