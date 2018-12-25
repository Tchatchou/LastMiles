using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LastMiles.API.RepositoriesAndUnitOfWork.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LastMiles.API.RepositoriesAndUnitOfWork.Repositories
{
    public class RepositoriesRead <TEntity> : IRepositoryRead<TEntity> where TEntity : class
    {
        //IQueryable ==> the filter is done in Database
        //IEnumerable ==> the filter is done in memory

        protected readonly DbContext _context;
        
        public RepositoriesRead(DbContext context)
        {
            _context = context;
        }

        public TEntity FindEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindEntityWhere(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}