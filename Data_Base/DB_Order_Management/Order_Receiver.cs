using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Base.DB_Order_Management
{
   
    public class Order_Receiver
    {
        [Key]
        public int order_receiver_id { get; set; }   
        public string order_receiving_party_type { get; set; } //value ==> retailer, distributor, enterprise, end customer.
                                                              // use obj.gettype to have it

         public int id_of_order_receiving_party {get;set;}
        public string name_order_receiving_party {get;set;}

         public  ICollection<Order> list_orders {get;set;}
    }

}