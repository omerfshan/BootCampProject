using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess;

public interface IRepository<TEntity> where TEntity : class, IEntity, new()
{
    TEntity Get(Expression<Func<TEntity, bool>> filter);
    IList<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
} 