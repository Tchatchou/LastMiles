using System.Collections.Generic;

namespace Data_Base.Data_Transfer_Objects
{
    public class Product_Details_Dto 
    {
        public int product_id { get; set; }

        // public double unitprice { get; set; } // field to remove

        //allow companie to control pricing by making sure that procduct pricing in pricing table 
        //it is not above the standard pricing they have set
         public double unitprice_standard_for_distributor { get; set; }
         
        //allow companie to control pricing by making sure that procduct pricing in pricing table 
        //it is not above the standard pricing they have set
         public double unitprice_standard_for_retailer { get; set; }

         public double unit { get; set; }
         public string product_code { get; set; }
         public string name { get; set; }

         public string desc { get; set; }

         public string image_1 { get; set; }

         public string image_2 { get; set; }

       
         public int product_Category_id { get; set; }

         public  Product_Category_Dto  product_Category{ get; set; }

          public int company_id { get; set; }
         public  Company_For_Registration_Dto company {get;set;}

         public List<Product_Pricing_Table_Distributor_Get_Dto> product_Pricing_Table_Distributor_Get_Dto {get;set;}
   
        public List<Product_Pricing_Table_Retailer_Get_Dto> Product_Pricing_Table_Retailer_Get_Dto {get;set;}
   

   }

    public class Product_Category_Dto
    {
        public int product_Category_id { get; set; }

        public string name { get; set; }

        public string desc { get; set; }

    }
}