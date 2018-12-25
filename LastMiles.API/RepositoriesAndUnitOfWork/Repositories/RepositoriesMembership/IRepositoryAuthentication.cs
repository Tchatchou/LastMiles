using System.Threading.Tasks;
using LastMiles.API.DataBase;

namespace LastMiles.API.RepositoriesAndUnitOfWork.IRepositories.IRepositoriesMembership
{
    public interface IRepositoryAuthentication
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}