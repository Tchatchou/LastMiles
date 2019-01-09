using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Data_Base.DB_Identity_Management
{
    public class Role_Creation_Possibility : IdentityUserRole<int>
    {         
          [JsonIgnore]
          public  Role Role {get;set;}
          public int availablerole_id { get; set; }
          [JsonIgnore]
          public  Available_Role  available_role {get;set;}
    }
}