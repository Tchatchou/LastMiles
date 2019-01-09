using System;
using Data_Access_Layer.Repositories.Identity_Repository;
using Data_Base;

namespace Data_Access_Layer.UnitOfWorks
{
   
     public interface IUnitOfWork_Identity : IDisposable
    {
        ICompany_Repository companies { get; }
        IDistributor_Repository  distributors { get; }    
        IRetailer_Repository retailers {get;}   
        int save();
    }

     public class UnitOfWork_Identity : IUnitOfWork_Identity
    {
      
        public ICompany_Repository companies { get; }
        public IDistributor_Repository  distributors { get; }    
        public IRetailer_Repository retailers {get;}   
        private readonly DataContext _context;

        public UnitOfWork_Identity(DataContext context)
        {
            _context = context;

            companies = new Company_Repository(_context);
            distributors = new Distributor_Repository(_context);
            retailers = new Retailer_Repository(_context);

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