using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Identity
{
    public interface IUser_Management
    {
        Task<User_For_Registration_Dto> get_user(string UserName);

        List<User_For_Registration_Dto> get_users_for_an_entity(int entity_id, string entity_type);

        Task<dynamic> change_user_password(Change_Password_Dto changePasswordDto,string userId);
        Task<Message_Dto> reset_user_access(string UserName);

        Task<Message_Dto> lock_user(string UserName);
        Task<Message_Dto> unlock_user(string UserName);        
        Task update_user_permission(string userId, List<Permission_Dto> permissions);

    }
}