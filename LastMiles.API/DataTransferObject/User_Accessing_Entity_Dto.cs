using System.Collections.Generic;

namespace LastMiles.API.DataTransferObject
{
    public class User_Accessing_Entity_Dto
    {
        public int entity_id { get; set; }

        public string entity_name { get; set; }

        public string entity_type { get; set; } //eg. distributeur, retailer etc..
    
        public bool is_default_entity {get;set;}

        public List<Permission_Dto> list_permission_for_this_entity { get; set; }
    }
}