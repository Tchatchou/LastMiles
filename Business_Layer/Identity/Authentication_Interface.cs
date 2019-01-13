


using System.Threading.Tasks;
using Data_Base.Data_Transfer_Objects;

namespace Business_Layer.Identity
{
    public interface IAuthentication
    {
          Task<User_Logged_Dto> login_user(User_For_Login_Dto user_For_Login_Dto);

          Task<dynamic> register_user(User_For_Registration_Dto userForRegistrationDto);

          Task<User_For_Registration_Dto> update_user(User_For_Registration_Dto userForRegistrationDto);
    }

   
}