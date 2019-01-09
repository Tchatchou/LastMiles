using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataTransferObject
{
    public class Company_For_Registration_Dto
    {
           [Required]
           public int company_type_id { get; set; }
           [Required]
           public string name { get; set; }
           [Required]
           public string comment { get; set; }
           [Required]

           public List<Company_Contact_Dto> contacts { get; set; } 
    }
}