using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataTransferObject
{
    public class UserForRegistrationDto
    {
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

        
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }


        [Required] 
        public List <string> Roles { get; set; }

        public UserForRegistrationDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}