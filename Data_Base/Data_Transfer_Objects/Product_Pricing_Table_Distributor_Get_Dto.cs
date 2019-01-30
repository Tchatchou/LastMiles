using System.ComponentModel.DataAnnotations;

namespace Data_Base.Data_Transfer_Objects
{
    public class Product_Pricing_Table_Distributor_Get_Dto :Product_Pricing_Table_Distributor_Set_Dto
   {  
        [Required]
        public int product_pricing_table_distributor_id { get; set; }    
   }
}