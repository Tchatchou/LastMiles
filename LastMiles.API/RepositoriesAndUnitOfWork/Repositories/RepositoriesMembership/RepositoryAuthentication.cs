using System.Threading.Tasks;
using LastMiles.API.DataBase;
using LastMiles.API.RepositoriesAndUnitOfWork.IRepositories.IRepositoriesMembership;

namespace LastMiles.API.RepositoriesAndUnitOfWork.Repositories.RepositoriesMembership
{
    public class RepositoryAuthentication : IRepositoryAuthentication
    { private readonly DataContext _context;
        public RepositoryAuthentication(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
          throw new System.NotImplementedException();
        }
        public Task<User> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}