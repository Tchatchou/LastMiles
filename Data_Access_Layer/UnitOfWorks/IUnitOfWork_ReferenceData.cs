using System;
using Data_Access_Layer.Repositories.Reference_Data_Repository;
using Data_Base;

namespace Data_Access_Layer.UnitOfWorks
{
    public interface IUnitOfWork_ReferenceData: IDisposable
    {
        ICompany_Type_Repository companies_type { get; }
        IDistributor_Type_Repository  distributors_type { get; }    
        IRetailer_Type_Repository retailers_type {get;} 
        IRole_Permission_Repository role {get;}  
        int save();
    }

     public class UnitOfWork_ReferenceData : IUnitOfWork_ReferenceData
    {
      
        private readonly DataContext _context;

        public ICompany_Type_Repository companies_type {get;}

        public IDistributor_Type_Repository distributors_type {get;}

        public IRetailer_Type_Repository retailers_type {get;}

        public IRole_Permission_Repository role {get;}

        public UnitOfWork_ReferenceData(DataContext context)
        {
            _context = context;

            companies_type = new Company_Type_Repository(_context);
            distributors_type = new Distributor_Type_Repository(_context);
            retailers_type = new Retailer_Type_Repository(_context);
            role = new Role_Permission_Repository(_context);
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