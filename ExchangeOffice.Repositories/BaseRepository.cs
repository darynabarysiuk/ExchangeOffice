using ExchangeOffice.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExchangeOffice.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly ApplicationContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var newEntity = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public IQueryable<TEntity> GetAllByQueryable(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            if(expression != null)
            {
                return query.Where(expression);
            }
            return query;
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity?> GetByAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
