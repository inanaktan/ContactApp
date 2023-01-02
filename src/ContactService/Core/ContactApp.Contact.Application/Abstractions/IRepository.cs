using System.Linq.Expressions;
using ContactApp.Contact.Domain.Abstractions;

namespace ContactApp.Contact.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : class, IEntity, new()
{
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
    Task<IList<TEntity>> GetListAync(Expression<Func<TEntity, bool>> predicate = null);
}
