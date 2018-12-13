using Microsoft.AspNetCore.Identity;

namespace LastMiles.API.DataBase
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }

        public Role Role { get; set; }
    }
}