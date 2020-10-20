using eClinica.Infrastructure.Data;
using eClinica.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eClinica.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dataContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dataContext.Set<TEntity>().UpdateRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(long id)
        {
            return _dataContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dataContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        TEntity IBaseRepository<TEntity>.GetLastInserted()
        {
            return _dataContext.Set<TEntity>().ToList().Last();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dataContext.Set<TEntity>();
        }
    }
}
