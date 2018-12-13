using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LastMiles.API.DataBase
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}