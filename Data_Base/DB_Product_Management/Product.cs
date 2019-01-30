using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Base.DB_Identity_Management;
using Data_Base.DB_Order_Management;

namespace Data_Base.DB_Product_Management
{
    
    public class Product
    {
        [Key]
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

         public  ICollection<Order_Detail> list_order_details {get;set;}

         public  List<Product_Pricing_Table_Distributor> list_product_with_special_pricing_distributor {get;set;}

         public  List<Product_Pricing_Table_Retailer> list_product_with_special_pricing_retailer {get;set;}

         public int product_Category_id { get; set; }

         public  Product_Category  product_Category{ get; set; }

         public int company_id { get; set; }
         public  Company company {get;set;}
    }
}