using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Base.DB_Identity_Management
{
    public class Retailer
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int retailer_id { get; set; } // most like mobile number

        public int retailer_type_id { get; set; }

        public virtual Retailer_Type retailer_type {get;set;}

        public virtual ICollection<Retailer_Disponibility> list_retailer_disponibility { get; set; }

        public int zone_id { get; set; }

        public int city_id { get; set; }

        public int quater_id { get; set; }

        public virtual ICollection<Distributor_Retailer> list_distributor_retailer{get;set;}

        public string code { get; set; }

        public string name { get; set; }
        public string address { get; set; }

        public string desc { get; set; }

        public string picture1 { get; set; }

        public string picture2 { get; set; }

        public string gps_x { get; set; }

        public string gps_y { get; set; }

    }

    public class Retailer_Type 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       public int retailer_type_id { get; set; }
       
       public string name { get; set; }

       public string desc { get; set; }

       public  ICollection<Retailer> list_retailer {get;set;}
    }

    public class Retailer_Disponibility
    {
        [Key]
        public int retailer_disponibility_id { get; set; }
          public int retailer_id { get; set; } // most like mobile number

        public  Retailer retailer {get;set;}

        public int opening_closing_id { get; set; }

        public string day { get; set; }

        public string comment { get; set; }

        public  ICollection<Opening_Closing> list_open_closing_time {get;set;}
    }

    public class Opening_Closing
    {
        [Key]
        public int opening_closing_id { get; set; }

         public int retailer_disponibility_id { get; set; }

         public  Retailer_Disponibility retailer_disponibility {get; set;}

        public DateTime  opening_time { get; set; }

         public DateTime  closing_time { get; set; }


    }
}