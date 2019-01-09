using Microsoft.AspNetCore.Identity;

namespace LastMiles.API.DataBase
{
    public class Role_Permission : IdentityUserRole<int>
    {         
          public  Role Role {get;set;}
          public int permission_id { get; set; }
          public  Permission  permission {get;set;}

    }
}