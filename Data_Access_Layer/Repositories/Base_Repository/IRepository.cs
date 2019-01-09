using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data_Base;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories.Base_Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
         //IQueryable ==> the filter is done in Database
        //IEnumerable ==> the filter is done in memory
        // great article to understnd the including db extention  https://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
        void Add(TEntity entity);
        void Delete(int id);

        void Update(TEntity entity);
       
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(int id);

        int Count(Func<TEntity, bool> predicate);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().FindAsync(id);
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
       
    }

}