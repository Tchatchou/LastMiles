using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LastMiles.API.DataBase
{
    public class Order_Type
    {
        [Key]
        public int order_type_id { get; set; }  

        public string name {get;set;} // if order is from retails to distributor or distributor to company
                                     // if order from Distributor to company then need to call courier api
                                     //  

        public string desc {get;set;}

        public  ICollection<Order> list_order {get;set;}
    }
}