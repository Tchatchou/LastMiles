namespace Data_Base.DB_Identity_Management
{
    
    public class Distributor_Retailer
    {
          
           public int distributor_id { get; set; }
           public  Distributor distributor {get;set;}

           public int retailer_id { get; set; } // most like mobile number

            public  Retailer retailer {get;set;}
    }
}