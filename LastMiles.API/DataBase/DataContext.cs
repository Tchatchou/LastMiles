using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LastMiles.API.DataBase
{
    public class DataContext : IdentityDbContext<User, Role, int,
                               IdentityUserClaim<int>, UserRole,
                               IdentityUserLogin<int>, IdentityRoleClaim<int>,
                               IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

       
    }
}