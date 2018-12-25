using System.Collections.Generic;
using LastMiles.API.RepositoriesAndUnitOfWork.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LastMiles.API.RepositoriesAndUnitOfWork.Repositories
{
    public class RepositoriesWrite<TEntity> : IRepositoryWrite<TEntity> where TEntity : class
    {
        
        protected readonly DbContext _context;
        
        public RepositoriesWrite(DbContext context)
        {
            _context = context;
        }
        public void AddListOfSingleEntity(IEnumerable<TEntity> entities)
        {
            throw new System.NotImplementedException();
        }

        public void AddSingleEntity(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByIdInt(int id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteListOfEntityByIdInt(int[] ids)
        {
            throw new System.NotImplementedException();
        }
    }
}