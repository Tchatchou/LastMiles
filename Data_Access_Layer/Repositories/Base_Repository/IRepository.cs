using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data_Base;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories.Base_Repository
{
    public interface IRepository<T> where T : class
    {
         //IQueryable ==> the filter is done in Database
        //IEnumerable ==> the filter is done in memory
        // great article to understnd the including db extention  https://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);       
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        int Count(Func<T, bool> predicate);
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

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _context.Set<T>().FindAsync(id);
        }
       
    }

}