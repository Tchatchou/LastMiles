using System.Threading.Tasks;
using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Product_Management
{
    public interface IProduct_Creation_Update
    {
         Task add_new_product_to_company(Product_Registration_Dto product_Registration_Dto);

         Task update_product(Product_Update_And_List_Dto product_Update_And_List_Dto);

         Task set_product_special_pricing_for_distributeur(Product_Pricing_Table_Distributor_Set_Dto speciale_pricing_distributor);

         Task set_product_special_pricing_for_retailer(Product_Pricing_Table_Retailer_Set_Dto special_pricing_retailer);
    }
}