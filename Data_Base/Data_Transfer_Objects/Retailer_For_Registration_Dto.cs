using System;
using System.Collections.Generic;

namespace Data_Base.Data_Transfer_Objects
{
   
    public class Retailer_For_Registration_Dto      
    {
     
        public int retailer_id { get; set; } // most like mobile number

        public int retailer_type_id { get; set; }

        public  Retailer_Type_Dto retailer_type {get;set;}

        public  ICollection<Retailer_Disponibility_Dto> list_retailer_disponibility { get; set; }

        public int zone_id { get; set; }

        public int city_id { get; set; }

        public int quater_id { get; set; }

    //    public  ICollection<Distributor_Retailer> list_distributor_retailer{get;set;}

        public string code { get; set; } // code to display for the scan

        public string name { get; set; } // represent the name of the retailer eg alimentation fostso
        public string address { get; set; } //
      
        public string desc { get; set; } // desc of the retailer place ,acitivity etc.

        public string picture1 { get; set; }

        public string picture2 { get; set; }

        public string gps_x { get; set; }

        public string gps_y { get; set; }

    }

    public class Retailer_Type_Dto 
    {
      
       public int retailer_type_id { get; set; }
       
       public string name { get; set; }

       public string desc { get; set; }

      // public virtual ICollection<Retailer> list_retailer {get;set;}
    }

    public class Retailer_Disponibility_Dto
    {
     
        public int retailer_disponibility_id { get; set; }
          public int retailer_id { get; set; } // most like mobile number

    

        public int opening_closing_id { get; set; }

        public string day { get; set; }

        public string comment { get; set; }

        public  ICollection<Opening_Closing_Dto> list_open_closing_time {get;set;}
    }

    public class Opening_Closing_Dto
    {
   
        public int opening_closing_id { get; set; }

         public int retailer_disponibility_id { get; set; }

         public  Retailer_Disponibility_Dto retailer_disponibility {get; set;}

        public DateTime  opening_time { get; set; }

         public DateTime  closing_time { get; set; }


    }
}