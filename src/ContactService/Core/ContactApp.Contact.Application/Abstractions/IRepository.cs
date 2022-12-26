using System.Linq.Expressions;
using ContactApp.Contact.Domain.Abstractions;

namespace ContactApp.Contact.Application.Abstractions;

public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>, new()
{
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity> GetAync(Expression<Func<TEntity, bool>> predicate = null);
    Task<IList<TEntity>> GetListAync(Expression<Func<TEntity, bool>> predicate = null);
}
