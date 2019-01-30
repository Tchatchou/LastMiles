namespace Data_Base.Data_Transfer_Objects
{
    public class Product_Registration_Dto
    {
         public double unitprice_standard_for_distributor { get; set; }
         
        //allow companie to control pricing by making sure that procduct pricing in pricing table 
        //it is not above the standard pricing they have set
         public double unitprice_standard_for_retailer { get; set; }

         public double unit { get; set; }
         public string product_code { get; set; }
         public string name { get; set; }

         public string desc { get; set; }

        // public string image_1 { get; set; }

        // public string image_2 { get; set; }
        
         public int product_Category_id { get; set; }
        
          public int company_id { get; set; }

    }
}