namespace LastMiles.API.DataBase
{
    public class Distributor_Company
    {
     
          public int distributor_id { get; set; }
          public  Distributor distributor {get;set;}
          public int company_id { get; set; }
          public  Company  Company {get;set;}

    }
}