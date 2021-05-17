using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;

        void Add<TEntity>(List<TEntity> entities) where TEntity : class;

        void Delete<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<List<TEntity>> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task<List<TEntity>> GetAll<TEntity>() where TEntity : class;
    }
}
