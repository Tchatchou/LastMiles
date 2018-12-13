
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LastMiles.API.DataBase
{
    public class User : IdentityUser <int>
    {        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}