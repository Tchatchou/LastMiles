using Microsoft.AspNetCore.Identity;

namespace Data_Base.DB_Identity_Management
{
    public class User_Role : IdentityUserRole<int>
    {
        public User User { get; set; }

        public Role Role { get; set; }
    }
}