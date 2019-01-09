using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataBase
{
    public class Order_Sender
    {
     
     [Key]
        public int order_sender_id { get; set; }   
       public string order_sending_party_type { get; set; } //value ==> retailer, distributor, enterprise, end customer.
                                                              // use obj.gettype to have it

         public int id_of_order_sending_party {get;set;}
        public string name_order_sending_party {get;set;}
        
        public  ICollection<Order> list_orders {get;set;}

    }
}