using System.ComponentModel.DataAnnotations;

namespace Data_Base.Data_Transfer_Objects
{
     public class Product_Pricing_Table_Retailer_Set_Dto
    {      

        [Required]
        public int product_id { get; set; }
        [Required]
        public int  distributor_id { get; set; }

        [Required]
        public int retailer_id { get; set; }
        [Required]
        public double agree_unitpricing { get; set; }

        public string comment { get; set; }
    }

    
}