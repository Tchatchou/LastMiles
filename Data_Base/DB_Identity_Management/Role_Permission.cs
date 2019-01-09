using Microsoft.AspNetCore.Identity;

namespace Data_Base.DB_Identity_Management
{
 
    public class Role_Permission : IdentityUserRole<int>
    {         
          public  Role Role {get;set;}
          public int permission_id { get; set; }
          public  Permission  permission {get;set;}

    }
}