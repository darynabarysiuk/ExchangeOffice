using System.Linq.Expressions;

namespace ExchangeOffice.IRepositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity?> GetByAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetAllQueryable();

        IQueryable<TEntity> GetAllByQueryable(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
    }
}
