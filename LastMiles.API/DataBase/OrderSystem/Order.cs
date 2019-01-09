using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataBase
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public int order_type_id { get; set; }

        public  Order_Type  order_type { get; set; }

        public  int order_receiver_id {get;set;}
        public  Order_Receiver order_receiver {get;set;}

          public  int order_sender_id {get;set;}
        public virtual Order_Sender order_sender {get;set;}
        public DateTime date_creation { get; set; }    
        public DateTime date_requested_by { get; set; }        
        public DateTime date_shipped { get; set; }
        public string status {get;set;}
        public  ICollection<Order_Detail> list_order_details {get;set;}
    }   
}