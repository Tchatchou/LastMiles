using LastMiles.API.DataBase;

namespace LastMiles.API.RepositoriesAndUnitOfWork.UnitOfWorks.UnitOfWorkMembership
{
    public class UnitOfWorkMembership : IUnitOfWorkMembership
    {
         private readonly DataContext _context;

        public UnitOfWorkMembership(DataContext context)
        {
            _context = context;
    
     
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int save()
        {
            return _context.SaveChanges();
        }
    }
}