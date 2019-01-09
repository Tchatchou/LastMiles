using System.ComponentModel.DataAnnotations;

namespace Data_Base.Data_Transfer_Objects
{
    public class User_For_Login_Dto
    {
         [Required]
        public string UserName { get; set; }   
         [Required] 
        public string Password { get; set; }
    }
}