using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LastMiles.API.RepositoriesAndUnitOfWork.IRepositories
{
    public interface IRepositoryRead <TEntity> where TEntity : class
    {
         // search
        TEntity FindEntityById(int id);
        IQueryable<TEntity> FindEntityWhere(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}