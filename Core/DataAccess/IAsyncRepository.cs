using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess;

public interface IAsyncRepository<TEntity> where TEntity : class, IEntity, new()
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
} 