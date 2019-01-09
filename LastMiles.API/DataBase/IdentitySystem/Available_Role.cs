using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastMiles.API.DataBase
{
    public class Available_Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int availablerole_id { get; set; }

        public string role_name { get; set; }
 public  ICollection<Role_Creation_Possibility> list_role_creation_possibility {get;set;}
    }
}