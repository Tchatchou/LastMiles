using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastMiles.API.DataBase
{
    public class Company
    {
        [Key]
        public int company_id { get; set; }

        //fk key
        public int company_type_id { get; set; }

        // loaing related type for this entity
        public  Company_Type  company_Type {get;set;}


        public  ICollection<Distributor_Company> list_distributor_companies{get;set;}

        public  ICollection<Product> list_product {get;set;}
        public string name { get; set; }

        public string comment { get; set; }
       public List<Company_Contact> contacts { get; set; }  

    }


    public class Company_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Company_type_id { get; set; }
        public string name { get; set; } // super grossist, representant, fabricant

        public string desc { get; set; }

        public  ICollection<Company> list_Companies {get;set;}
    }

    public class  Company_Contact
    {
        [Key]
         public int company_contact_id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }
        
    }
    

}