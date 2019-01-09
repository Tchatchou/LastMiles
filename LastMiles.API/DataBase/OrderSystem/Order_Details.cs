using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataBase
{
    public class Order_Detail
    {
        [Key]
       public int  order_detail_id {get;set;}

       public int product_id { get; set; }

       public  Product product {get;set;}
    
       public int order_id { get; set; }

       public  Order order {get;set;}

       public int quantity { get; set; }
    }
}