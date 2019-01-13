namespace Data_Base.Data_Transfer_Objects
{
    public class Distributor_For_Details_Dto : Distributor_For_Registration_Dto
    {
         public int distributor_id { get; set; }
           public  Distributor_Type_dto distributor_type {get;set;}
    }
}