using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataTransferObject
{
    public class UserForLoginDto
    {
         [Required]
        public string UserName { get; set; }   
         [Required] 
        public string Password { get; set; }
    }
}