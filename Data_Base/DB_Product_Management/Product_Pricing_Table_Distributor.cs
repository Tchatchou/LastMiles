using System.ComponentModel.DataAnnotations;

namespace Data_Base.DB_Product_Management
{
    public class Product_Pricing_Table_Distributor
    {
         [Key]
        public int product_pricing_table_distributor_id { get; set; }

        [Required]
        public int product_id { get; set; }

        public Product product { get; set; }
        [Required]
        public int  distributor_id { get; set; }

        [Required]
        public int company_id { get; set; }
        [Required]
        public double agree_unitpricing { get; set; }

        public string comment { get; set; }
    }
}