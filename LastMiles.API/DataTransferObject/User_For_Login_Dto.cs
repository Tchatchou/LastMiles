using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataTransferObject
{
    public class User_For_Login_Dto
    {
         [Required]
        public string UserName { get; set; }   
         [Required] 
        public string Password { get; set; }
    }
}