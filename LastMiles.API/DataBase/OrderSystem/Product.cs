using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataBase
{
    public class Product
    {
        [Key]
         public int product_id { get; set; }

         public double unitprice { get; set; }

         public string name { get; set; }

         public string desc { get; set; }

         public string image_1 { get; set; }

         public string image_2 { get; set; }

         public  ICollection<Order_Detail> list_order_details {get;set;}

         public int product_Category_id { get; set; }

         public  Product_Category  product_Category{ get; set; }

          public int company_id { get; set; }
         public  Company company {get;set;}
    }
}