using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Base.DB_Product_Management
{
   
    public class Product_Category
    {
        [Key]
        public int product_Category_id { get; set; }

        public string name { get; set; }

        public string desc { get; set; }

        public  ICollection<Product> list_product {get;set;}
    }
}