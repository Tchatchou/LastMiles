using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataTransferObject
{
    public class User_For_Registration_Dto
    {
        public int Id { get; set; }
        [Required] 
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }
            
        [Required] 
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }       
        public string Email { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        public Entity_UserMapTo EntityUserMapTo { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }


        [Required] 
        public List <Role_Dto> Roles { get; set; }

        public List<Permission_Dto> permission { get; set; }

        public User_For_Registration_Dto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }

    public class Role_Dto
    {
        [Required]
        public int role_id { get; set; }
        [Required]
        public string role_name { get; set; }
    }

    public class Entity_UserMapTo
    {
        [Required]
        public int entity_id { get; set; } // key id
        [Required]
        public string entity_name { get; set; } // nestle , soticam etc..
        [Required]
        public string entity_type { get; set; } // retailer, comapany etc.

    }
}