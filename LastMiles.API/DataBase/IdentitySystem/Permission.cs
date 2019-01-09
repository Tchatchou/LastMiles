using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastMiles.API.DataBase
{
    
    public class Permission  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int permission_id  { get; set; }

        public string desc { get; set; }        

        public  ICollection<Role_Permission> list_role_permissions{get;set;}
 
    }

}