using Entity.Context;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Add<TEntity>(List<TEntity> entities) where TEntity : class
        {
            foreach (var item in entities)
            {
                _context.Add(item);
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TEntity>> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
