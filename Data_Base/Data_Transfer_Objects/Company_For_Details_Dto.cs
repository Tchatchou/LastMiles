using System.Collections.Generic;

namespace Data_Base.Data_Transfer_Objects
{
    public class Company_For_Details_Dto : Company_For_Registration_Dto
    {
         public int company_id { get; set; }       

        // loaing related type for this entity
        public  Company_Type_Dto  company_Type {get;set;}

    }
    public class Company_Type_Dto
    {       
        public int Company_type_id { get; set; }
        public string name { get; set; } // super grossist, representant, fabricant

        public string desc { get; set; }
    }

    public class  Company_Contact_Dto
    {
        public int company_contact_id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }
        
    }
    
}