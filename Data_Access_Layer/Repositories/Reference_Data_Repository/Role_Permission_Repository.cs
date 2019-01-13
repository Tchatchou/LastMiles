using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

using Data_Access_Layer.Repositories.Base_Repository;
using Data_Base;
using Data_Base.DB_Identity_Management;
using Data_Base.Data_Transfer_Objects;

namespace Data_Access_Layer.Repositories.Reference_Data_Repository
{

    public class Role_Permission_Repository : IRole_Permission_Repository
    {
        public DataContext _context { get; }
        public Role_Permission_Repository(DataContext context) 
        {
            _context = context;
        }
        public   List<Available_Role_Dto>  Get_Role_Can_Create(int role)
        {
             var role_creation = _context.Set<Role_Creation_Possibility>().Where(r=> r.RoleId==role);
            List<Available_Role_Dto>  list_role_can_create =new List<Available_Role_Dto>() ;

            foreach (var item in role_creation)   
            {
             var available_role=   _context.Available_Roles.Find(item.availablerole_id);
                  list_role_can_create.Add(new Available_Role_Dto { availablerole_id = available_role.availablerole_id,role_name=available_role.role_name });
            }
           
            return list_role_can_create;
        }

        public List<Permission_Dto> Get_Roles_With_Default_Permisions(List<int> role_ids)
        {

           List<Permission_Dto>  list_role_withpermission =new List<Permission_Dto>() ;

            foreach(var role_id in role_ids) 
            {
                var roles = _context.Set<Role_Permission>().Where(r=> r.RoleId==role_id);           
    
                foreach (var item in roles)   
                {
                      var permission= _context.Permissions.Find(item.permission_id);
                      list_role_withpermission.Add(new Permission_Dto { permission_id = permission.permission_id,desc=permission.desc});
                }           
            }

            return list_role_withpermission.Distinct().ToList();
        }
       
        public List<Permission_Dto> Get_Permission_Of_User(string userName, UserManager<User> userManager)
        {
            var userAccessingEntityWithPermissions = userManager.FindByNameAsync(userName).Result.UserAccessingEntityWithPermissions;

            List<Permission_Dto> permission_Dtos = new  List<Permission_Dto>();

            if(string.IsNullOrEmpty(userAccessingEntityWithPermissions) 
            || string.IsNullOrWhiteSpace(userAccessingEntityWithPermissions)
            || userAccessingEntityWithPermissions.Contains("SuperAdmin") 
            || userAccessingEntityWithPermissions.Contains("Admin"))
             return permission_Dtos;

            permission_Dtos = JsonConvert.DeserializeObject<List<Permission_Dto>>(userAccessingEntityWithPermissions);
            return permission_Dtos;
        }

        public void Set_Permission_Of_User(string userName, UserManager<User> userManager, List<Permission_Dto> permission_Dtos)
        {
              var user = userManager.FindByNameAsync(userName).Result;

              user.UserAccessingEntityWithPermissions = JsonConvert.SerializeObject(permission_Dtos);

              userManager.UpdateAsync(user);
        }
    }
}