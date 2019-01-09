using System.Collections.Generic;

namespace Data_Base.Data_Transfer_Objects
{
  
 
    public class Distributor_For_Registration_Dto
    {
      
        public int distributor_id { get; set; }

     //   public  ICollection<Distributor_Company> list_distributor_companies{get;set;}

    //     public ICollection<Distributor_Retailer> list_distributor_retailer{get;set;}


        public int distributor_type_id { get; set; }

        public  Distributor_Type_dto distributor_type {get;set;}

        public string name { get; set; }

         public string comment { get; set; }

        public string contact { get; set; } // name,email,mobile store as json

        public string gps_x { get; set; }

        public string gps_y { get; set; }
    }

     public class Distributor_Type_dto 
    {
       
       public int distributor_type_id { get; set; }
       
       public string name { get; set; } 

       public string desc { get; set; }

      //   public virtual ICollection<Distributor> list_distributors {get;set;}
    }
}