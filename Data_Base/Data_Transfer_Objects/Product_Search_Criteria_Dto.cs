namespace Data_Base.Data_Transfer_Objects
{
    public class Product_Search_Criteria_Dto
    {
         public string product_code { get; set; }
         public string name { get; set; }     
         public int product_Category_id { get; set; }        
         public int company_id { get; set; } 
    }
}