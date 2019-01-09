using System.ComponentModel.DataAnnotations;

namespace Data_Base.Data_Transfer_Objects
{
    public class Change_Password_Dto
    {      
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string NewPassword { get; set; }
    }
}