using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Identity
{
    public interface IAccount_Update
    {
           void update_company(Distributor_For_Registration_Dto distributor);
           void update_distributor(Distributor_For_Registration_Dto distributor);

           void update_retailer_details(Retailer_For_Registration_Dto retailer);
           void update_retailer_gps_location(int retailer_id,string gps_x, string gps_y);
           void update_retailer_picture1(int retailer_id,string path1);
           void update_retailer_picture2(int retailer_id,string path2);
    }
}