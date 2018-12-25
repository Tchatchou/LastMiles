using System.Collections.Generic;

namespace LastMiles.API.RepositoriesAndUnitOfWork.IRepositories
{
    public interface IRepositoryWrite <TEntity> where TEntity : class
    {
          //delete
        void DeleteByIdInt(int id);
        void DeleteListOfEntityByIdInt(int[] ids);
       
        //add single 
        void AddSingleEntity(TEntity entity);
        void AddListOfSingleEntity(IEnumerable<TEntity> entities);
    }
}