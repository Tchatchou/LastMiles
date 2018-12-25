
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LastMiles.API.DataBase
{
    public class User : IdentityUser <int>
    {        
        public ICollection<UserRole> UserRoles { get; set; }

        [Required] 
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }  

        public DateTime Created { get; set; }
        
        public DateTime LastActive { get; set; }
    }
}